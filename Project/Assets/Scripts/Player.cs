using UnityEngine;

[System.Serializable]
public class Sprites  //Creates a class to store the sprite and actvate/disacvtivate it
{
    public string name;
    public GameObject sprite;
    public bool isActive;

    public void Activate (GameObject _sprite)
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
	void Start ()  //Activates first sprite and then deactivates all the others
    {
        sprites[0].Activate(sprites[0].sprite);

        for(int i = 1; i < sprites.Length; i++)
        {
            sprites[i].Deactivate(sprites[i].sprite);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Backspace))  //If spacebar is pressed, activate next sprite
        {
            for(int i = 0; i < sprites.Length; i++)
            {
                if (sprites[sprites.Length - 1].isActive == true)  //If the last sprite is active, deactivate it and then activate the first one
                {
                    sprites[sprites.Length - 1].Deactivate(sprites[sprites.Length - 1].sprite);

                    sprites[0].Activate(sprites[0].sprite);
                    break;
                }
                else if (sprites[i].isActive == true)  //Deactivate the current sprite and activate to next one
                {
                    sprites[i].Deactivate(sprites[i].sprite);

                    sprites[i + 1].Activate(sprites[i + 1].sprite);
                    break;
                }
            }
        }
	}
}
