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

        if (composition == "TrueTrueTrueTrueTrueTrueTrueTrue" || composition == "FalseFalseFalseTrueTrueTrueTrueTrue")
            //|| composition == "TrueTrueTrueTrueTrueTrueTrueFalse")
        {
            tileData.sprite = groundSprites[13];
        }
        else if (composition == "FalseTrueTrueFalseTrueFalseTrueTrue" || composition == "TrueTrueTrueTrueTrueFalseFalseFalse")
        {
            tileData.sprite = groundSprites[14];
        }
        else if (composition == "FalseFalseFalseFalseTrueFalseTrueTrue")
        {
            tileData.sprite = groundSprites[6];
        }
        else if (composition == "FalseTrueTrueFalseTrueFalseFalseFalse")
        {
            tileData.sprite = groundSprites[11];
        }
        else if (composition == "TrueTrueFalseTrueTrueFalseFalseFalse" || composition == "TrueTrueFalseTrueTrueTrueTrueTrue" || 
                 composition == "TrueTrueFalseTrueTrueTrueFalseFalse")
        {
            tileData.sprite = groundSprites[5];
        }
        else if (composition == "TrueFalseFalseTrueFalseTrueTrueTrue" || composition == "TrueFalseFalseTrueFalseTrueTrueFalse")
        {
            tileData.sprite = groundSprites[4];
        }
        else if (composition == "TrueFalseFalseTrueFalseFalseFalseFalse")
        {
            tileData.sprite = groundSprites[1];
        }
        else if (composition == "TrueTrueTrueTrueFalseTrueFalseFalse" || composition == "TrueTrueFalseTrueFalseTrueFalseFalse")
        {
            tileData.sprite = groundSprites[3];
        }
        else if (composition == "FalseFalseFalseTrueFalseTrueFalseFalse")
        {
            tileData.sprite = groundSprites[0];
        }
        else if (composition == "FalseFalseFalseTrueTrueTrueTrueFalse" || composition == "TrueFalseFalseTrueTrueTrueTrueFalse" ||
                 composition == "TrueTrueTrueTrueTrueTrueTrueFalse")
        {
            tileData.sprite = groundSprites[2];
        }
        else
        {
            tileData.sprite = groundSprites[8];
        }

        tileData.colliderType = ColliderType.Sprite;

        //if (composition == "_x_x_x_2_x_3_x_x" || composition == "_x_x_x_2_x_8_x_x")
        //{
        //    tileData.sprite = groundSprites[0];
        //}
        //else if (composition == "_x_x_4_5_x_x_x_x" || composition == "_x_x_9_5_x_x_x_x")
        //{
        //    tileData.sprite = groundSprites[1];
        //}
        //else if (composition[5] == 'x' && composition[1] == 'x' && composition[3] == 'x' && (composition[7] == 'D' || composition[7] == 'E') && composition[9] == '0' &&
        //         (composition[11] == '7' || composition[11] == 'D' || composition[11] == 'E') && (composition[13] == '3' || composition[13] == '8') && composition[15] == 'x')
        //{
        //    tileData.sprite = groundSprites[2];
        //}
        //else if ((composition[5] == '3' || composition[5] == '0') && (composition[3] == '8' || composition[3] == 'D' || composition[3] == 'E') &&
        //         (composition[1] == 'D' || composition[1] == 'E') && composition[7] == '7' && composition[9] == 'x' && (composition[11] == '3' ||
        //         composition[11] == '8') && composition[13] == 'x' && composition[15] == 'x')
        //{
        //    tileData.sprite = groundSprites[3];
        //}
        //else if ((composition[1] == '4' || composition[1] == '9') && composition[3] == 'x' && composition[5] == 'x' && (composition[7] == 'E' || composition[7] == 'D')
        //         && composition[9] == 'x' && (composition[11] == 'E' || composition[11] == 'D') && (composition[13] == '9' || composition[13] == 'E'
        //         || composition[13] == 'D') && (composition[15] == '1' || composition[15] == '4'))
        //{
        //    tileData.sprite = groundSprites[4];
        //}
        //else if ((composition[1] == 'A' || composition[1] == 'E' || composition[1] == 'D') && (composition[3] == '4' || composition[3] == '9') &&
        //         composition[5] == 'x' && (composition[7] == 'E' || composition[7] == 'D') && composition[9] == '1' && composition[11] == 'x' &&
        //         composition[13] == 'x' && composition[15] == 'x')
        //{
        //    tileData.sprite = groundSprites[5];
        //}
        //else if (composition == "_x_x_x_x_D_x_D_D" || composition == "_x_x_x_x_D_x_D_D")
        //{
        //    tileData.sprite = groundSprites[6];
        //}
        //else if ((composition[1] == 'D' || composition[1] == 'E') && (composition[3] == 'D' || composition[3] == 'E') && (composition[5] == '2' ||
        //         composition[5] == '7' || composition[5] == '8') && (composition[7] == 'D' || composition[7] == 'E') && composition[9] == '3' &&
        //         (composition[11] == '7' || composition[11] == 'D' || composition[11] == 'E') && (composition[13] == '3' || composition[13] == '8') &&
        //         composition[15] == 'x')
        //{
        //    tileData.sprite = groundSprites[7];
        //}
        //else if ((composition[1] == 'D' || composition[1] == 'E') && (composition[3] == 'x' || composition[3] == '2' || composition[3] == '7' ||
        //         composition[3] == '8') && (composition[5] == 'x' || composition[5] == 'x' || composition[5] == '0' || composition[5] == '3') &&
        //         (composition[7] == 'D' || composition[7] == 'E') && composition[9] == 'x' && (composition[11] == 'D' || composition[11] == 'E') &&
        //         (composition[13] == '8' || composition[13] == '9') && composition[15] == 'x')
        //{
        //    tileData.sprite = groundSprites[8];
        //}
        //else if ((composition[1] == 'E' || composition[1] == 'D') && (composition[3] == '8' || composition[3] == '9') && composition[5] == 'x' &&
        //         (composition[7] == 'E' || composition[7] == 'D') && composition[9] == 'x' && (composition[11] == 'E' || composition[11] == 'D') &&
        //         (composition[13] == 'x' || composition[13] == '5' || composition[13] == 'A') && (composition[15] == 'x' || composition[15] == '1' ||
        //         composition[15] == '4'))
        //{
        //    tileData.sprite = groundSprites[9];
        //}
        //else if ((composition[1] == 'E' || composition[1] == 'A' || composition[1] == 'D') && (composition[3] == '4' || composition[3] == '9') &&
        //         composition[5] == 'x' && (composition[7] == 'E' || composition[7] == 'D') && composition[9] == '4' && (composition[11] == 'E' ||
        //         composition[11] == 'D') && (composition[13] == 'E' || composition[13] == 'E') && (composition[15] == '5' || composition[15] == '9' ||
        //         composition[15] == 'A'))
        //{
        //    tileData.sprite = groundSprites[10];
        //}
        //else if (composition == "_x_E_E_x_E_x_x_x" || composition == "_x_D_D_x_D_x_x_x")
        //{
        //    tileData.sprite = groundSprites[11];
        //}
        //else if (composition == "_x_x_x_x_E_x_E_E" || composition == "_x_x_x_x_D_x_D_D")
        //{
        //    tileData.sprite = groundSprites[12];
        //}
        //else if (composition == "_x_E_E_x_E_x_x_x" || composition == "_x_D_D_x_D_x_x_x")
        //{
        //    tileData.sprite = groundSprites[15];
        //}
        //else
        //{
        //    tileData.sprite = groundSprites[13];
        //}
    }

    private bool NeighborTile(ITilemap tileMap, Vector3Int position)
    {
        if (tileMap.GetTile(position) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        
        //Debug.Log(tileMap.GetTile(position));

        //if (tileMap.GetTile(position) == groundSprites[0])
        //{
        //    return "_0";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[1])
        //{
        //    return "_1";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[2])
        //{
        //    return "_2";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[3])
        //{
        //    return "_3";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[4])
        //{
        //    return "_4";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[5])
        //{
        //    return "_5";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[6])
        //{
        //    return "_6";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[7])
        //{
        //    return "_7";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[8])
        //{
        //    return "_8";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[9])
        //{
        //    return "_9";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[10])
        //{
        //    return "_A";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[11])
        //{
        //    return "_B";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[12])
        //{
        //    return "_C";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[13])
        //{
        //    return "_D";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[14])
        //{
        //    return "_E";
        //}
        //else if (tileMap.GetTile(position) == groundSprites[15])
        //{
        //    return "_F";
        //}
        //else
        //{
        //    return "_x";
        //}
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
