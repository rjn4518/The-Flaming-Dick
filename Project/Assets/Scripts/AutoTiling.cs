using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoTiling : Tile
{
    [SerializeField]
    private Sprite[] groundSprites;

    [SerializeField]
    private Sprite preview;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
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
    }

    private string NeighborTile(ITilemap tileMap, Vector3Int position)
    {
        if (tileMap.GetTile(position) == groundSprites[0])
        {
            return "_0000";
        }
        else if (tileMap.GetTile(position) == groundSprites[1])
        {
            return "_0001";
        }
        else if (tileMap.GetTile(position) == groundSprites[2])
        {
            return "_0010";
        }
        else if (tileMap.GetTile(position) == groundSprites[3])
        {
            return "_0011";
        }
        else if (tileMap.GetTile(position) == groundSprites[4])
        {
            return "_0100";
        }
        else if (tileMap.GetTile(position) == groundSprites[5])
        {
            return "_0101";
        }
        else if (tileMap.GetTile(position) == groundSprites[6])
        {
            return "_0110";
        }
        else if (tileMap.GetTile(position) == groundSprites[7])
        {
            return "_0111";
        }
        else if (tileMap.GetTile(position) == groundSprites[8])
        {
            return "_1000";
        }
        else if (tileMap.GetTile(position) == groundSprites[9])
        {
            return "_1001";
        }
        else if (tileMap.GetTile(position) == groundSprites[10])
        {
            return "_1010";
        }
        else if (tileMap.GetTile(position) == groundSprites[11])
        {
            return "_1011";
        }
        else if (tileMap.GetTile(position) == groundSprites[12])
        {
            return "_1100";
        }
        else if (tileMap.GetTile(position) == groundSprites[13])
        {
            return "_1101";
        }
        else if (tileMap.GetTile(position) == groundSprites[14])
        {
            return "_1110";
        }
        else if (tileMap.GetTile(position) == groundSprites[15])
        {
            return "_1111";
        }
        else
        {
            return "_xxxx";
        }
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/Ground")]

    public static void CreateGround()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Ground", "New Ground", "asset", "Save Ground", "Assets");

        if (path == "")
        {
            return;
        }

        AssetDatabase.CreateAsset(CreateInstance<AutoTiling>(), path);
    }
#endif
}
