using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatterAbleObject : MonoBehaviour
{
    public int id,u;
    public bool cc;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GameController.GC.Items[id];
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (u == 0)
            {
                u ++;
                GameController.GC.ep++;
                GameController.GC.gao = this;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (u != 0)
            {
                u = 0;
                GameController.GC.ep--;
            }
        }
    }
    public void Bye()
    {
        Destroy(gameObject);
    }
}
