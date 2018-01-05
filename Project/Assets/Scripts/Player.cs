using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sprites  //Creates a class to store the sprite and actvate/disacvtivate it
{
    public string name;
    public GameObject sprite;
    public bool isActive;

    public void Activate(GameObject _sprite)
    {
        sprite = _sprite;
        isActive = true;
        sprite.SetActive(isActive);

    }

    public void Deactivate(GameObject _sprite)
    {
        sprite = _sprite;
        isActive = false;
        sprite.SetActive(isActive);

    }
}

public class Player : MonoBehaviour
{
    [SerializeField]
    Sprites[] sprites;  //Creates an array of all our sprites. Size of array can be set in the inspector

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
