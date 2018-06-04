using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelChangerTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerSprite")
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public virtual void FadeToLevel(int levelIndex)
    {

    }
}
