using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoTiling_Water : Tile
{
    [SerializeField]
    private Sprite[] waterSprites;  // Creates and array of all ground sprites

    [SerializeField]
    private Sprite preview;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        // Checks all surrounding tiles and refreshes their sprites accordingly

        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                Vector3Int nPosition = new Vector3Int(position.x + x, position.y + y, position.z);
                tilemap.RefreshTile(nPosition);
            }
        }
    }

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;

        int fuckFace = 1;

        // Checks surrounding spaces for tiles and updates composition accordingly
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x != 0 || y != 0)
                {
                    composition += NeighborTile(tilemap, new Vector3Int(location.x + x, location.y + y, location.z));
                }
            }
        }

        // Good luck tring to understand this shit lol

        if (composition == "FalseTrueTrueFalseTrueFalseTrueTrue" || composition == "FalseFalseFalseFalseTrueFalseTrueTrue" ||
            composition == "FalseTrueTrueFalseTrueFalseFalseFalse")
        {
            switch(fuckFace)
            {
                case 1:
                    tileData.sprite = waterSprites[0];
                    break;

                case -1:
                    tileData.sprite = waterSprites[1];
                    break;

                default:
                    break;
            }
        }
        if(composition == "TrueTrueTrueTrueTrueTrueTrueTrue" || composition == "TrueTrueFalseTrueFalseTrueTrueFalse" ||
           composition == "FalseFalseFalseTrueFalseTrueTrueTrue" || composition == "TrueTrueFalseTrueFalseFalseFalseFalse")
        {
            switch (fuckFace)
            {
                case 1:
                    tileData.sprite = waterSprites[2];
                    break;

                case -1:
                    tileData.sprite = waterSprites[3];
                    break;

                default:
                    break;
            }
        }
        else
        {
            tileData.sprite = waterSprites[2];
        }
        // Basically just chooses a tile based on what composition is

        tileData.colliderType = ColliderType.Sprite;

        fuckFace = fuckFace * -1;
    }

    private bool NeighborTile(ITilemap tileMap, Vector3Int position)
    {
        // If there is a neighboring tile, return true
        // If not, return false

        if (tileMap.GetTile(position) != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    // This is some weird ass shit I found on YouTube that automatically creates a new asset for this ground pallete I don't even know

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/Water")]

    public static void CreateWater()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Water", "New Water", "asset", "Save Water", "Assets");

        if (path == "")
        {
            return;
        }

        AssetDatabase.CreateAsset(CreateInstance<AutoTiling_Water>(), path);
    }
#endif
}
