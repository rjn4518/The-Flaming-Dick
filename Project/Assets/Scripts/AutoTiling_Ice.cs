using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoTiling_Ice : Tile
{
    [SerializeField]
    private Sprite[] iceSprites;  // Creates and array of all ground sprites

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

        if (composition == "TrueTrueTrueTrueTrueTrueTrueTrue" || composition == "FalseFalseFalseTrueTrueTrueTrueTrue")
        //|| composition == "TrueTrueTrueTrueTrueTrueTrueFalse")
        {
            tileData.sprite = iceSprites[13];
        }
        else if (composition == "FalseTrueTrueFalseTrueFalseTrueTrue" || composition == "TrueTrueTrueTrueTrueFalseFalseFalse")
        {
            tileData.sprite = iceSprites[14];
        }
        else if (composition == "FalseFalseFalseFalseTrueFalseTrueTrue")
        {
            tileData.sprite = iceSprites[6];
        }
        else if (composition == "FalseTrueTrueFalseTrueFalseFalseFalse")
        {
            tileData.sprite = iceSprites[11];
        }
        else if (composition == "TrueTrueFalseTrueTrueFalseFalseFalse" || composition == "TrueTrueFalseTrueTrueTrueTrueTrue" ||
                 composition == "TrueTrueFalseTrueTrueTrueFalseFalse")
        {
            tileData.sprite = iceSprites[5];
        }
        else if (composition == "TrueFalseFalseTrueFalseTrueTrueTrue" || composition == "TrueFalseFalseTrueFalseTrueTrueFalse")
        {
            tileData.sprite = iceSprites[4];
        }
        else if (composition == "TrueFalseFalseTrueFalseFalseFalseFalse")
        {
            tileData.sprite = iceSprites[1];
        }
        else if (composition == "TrueTrueTrueTrueFalseTrueFalseFalse" || composition == "TrueTrueFalseTrueFalseTrueFalseFalse")
        {
            tileData.sprite = iceSprites[3];
        }
        else if (composition == "FalseFalseFalseTrueFalseTrueFalseFalse")
        {
            tileData.sprite = iceSprites[0];
        }
        else if (composition == "FalseFalseFalseTrueTrueTrueTrueFalse" || composition == "TrueFalseFalseTrueTrueTrueTrueFalse" ||
                 composition == "TrueTrueTrueTrueTrueTrueTrueFalse")
        {
            tileData.sprite = iceSprites[2];
        }
        else
        {
            tileData.sprite = iceSprites[8];
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
    [MenuItem("Assets/Create/Tiles/Ice")]

    public static void CreateIce()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Ice", "New Ice", "asset", "Save Ice", "Assets");

        if (path == "")
        {
            return;
        }

        AssetDatabase.CreateAsset(CreateInstance<AutoTiling>(), path);
    }
#endif
}
