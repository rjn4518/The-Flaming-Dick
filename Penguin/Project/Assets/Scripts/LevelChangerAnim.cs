using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelChangerAnim : LevelChangerTrigger
{
    public bool transition;
    public Animator animator;

    private int levelToLoad;
    private static int fish = 0;

    private void Start()
    {
        transition = false;
    }

    public override void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public static int Fish()
    {
        return fish;
    }

    public void OnFadeComplete()
    {
        fish = PlayerPrefs.GetInt("fish", GameMaster.GetFishCount());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
