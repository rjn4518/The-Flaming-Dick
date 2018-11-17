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

    private int fuckFace = 1;
    private int shitHead = 1;

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

        // Chooses the tile based on string created by NeighborTile method

        if (composition == "TrueTrueFalseTrueFalseTrueTrueFalse" || composition == "FalseFalseFalseTrueFalseTrueTrueFalse" ||
            composition == "TrueTrueFalseTrueFalseFalseFalseFalse")
        {
            switch (fuckFace)
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

            fuckFace = fuckFace * -1;
        }
        else
        {
            switch (shitHead)
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

            shitHead = shitHead * -1;
        }
        // Basically just chooses a tile based on what composition is

        tileData.colliderType = ColliderType.Sprite;
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
