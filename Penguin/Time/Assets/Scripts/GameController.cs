using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GatterAbleObject gao;
    public List<Sprite> Items;
    public GameObject e, PressS;
    public Material hm, em, fm;
    public float hpd = 100, maxhp = 100, energyd = 100, maxenergy = 100, foodd = 100;
    float hp, energy, food,tf;
    public int ep;
    public static GameController GC;
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameController.GC == null)
        {
            GameController.GC = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time();
        if (ep > 0)
            if (Input.GetKey("e"))
            {
                if (FindObjectOfType<PlayerS>().objects < 10)
                {
                    FindObjectOfType<PlayerS>().AddEqup(gao.id);
                    gao.Bye();
                }
            }
        if (ep > 0)
        {
            e.SetActive(true);
        }
        else e.SetActive(false);
        Lmt();
        Clamps();
        UIM();
    }
    void Time()
    {

    }
    void Lmt()
    {
        hp += (hpd - hp) / 25;
        energy += (energyd - energy) / 25;
        food += (foodd - food) / 25;
    }
    void Clamps()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        maxhp = Mathf.Clamp(maxhp, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);
        maxenergy = Mathf.Clamp(maxenergy, 0, 100);
        food = Mathf.Clamp(food, 0, 100);
    }
    void UIM()
    {
        hm.SetFloat("_Percent", hp / 100);
        hm.SetFloat("_Norecover", maxhp / 100);
        em.SetFloat("_Percent", energy / 100);
        em.SetFloat("_Norecover", maxenergy / 100);
        fm.SetFloat("_Percent", food / 100);
    }
    public void InDoors(GameObject Room)
    {
        if (Room.activeInHierarchy)
        {
            Room.SetActive(true);
            FindObjectOfType<PlayerS>().gameObject.layer = 8;
        }
        else
        {
            Room.SetActive(false);
            FindObjectOfType<PlayerS>().gameObject.layer = 9;
        }
    }
}
