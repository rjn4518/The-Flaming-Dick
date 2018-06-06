using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelChangerAnim : LevelChangerTrigger
{
    public bool transition;
    public Animator animator;

    private int levelToLoad;

    private void Start()
    {
        transition = false;
    }

    public override void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
