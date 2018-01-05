using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    private void Awake()
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMaster>();
    }

    public Transform playerPrefab;
}
