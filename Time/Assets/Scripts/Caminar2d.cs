using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar2d : MonoBehaviour
{
    public float spd = 20,jspd = 50, distancedown = 0.5f, derrape;
    public int maxspd = 8;
    public Rigidbody2D thisonerbg;
    public bool noderrape, infloor,l,r;
    int moving;
    // Use this for initialization
    void Start()
    {
        thisonerbg = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        infloor = Coldown();
        moving = 0;
        if (thisonerbg.velocity.x > maxspd) thisonerbg.velocity = new Vector2(maxspd, thisonerbg.velocity.y);
        if (thisonerbg.velocity.x < -maxspd) thisonerbg.velocity = new Vector2(-maxspd, thisonerbg.velocity.y);
        if (Input.GetKeyDown("space"))
        {
            if(Coldown())
            thisonerbg.AddForce(Vector2.up * jspd);
        }
        if (Input.GetKey("a"))
        {
            l = true;
            if (noderrape)
            {
                if (thisonerbg.velocity.x > 0) thisonerbg.velocity *= new Vector2(0, 1);
            }
            thisonerbg.AddForce(Vector2.left * spd);
        }
        else
        {
            moving++;
            l = false;
        }

        if (Input.GetKey("d"))
        {
            r = true;
            if (noderrape)
            {
                if (thisonerbg.velocity.x < 0) thisonerbg.velocity *= new Vector2(0, 1);
            }
            thisonerbg.AddForce(Vector2.right * spd);
        }
        else
        {
            r = false;
            moving++;
        }
        if (moving == 2)
        {
            if(thisonerbg.velocity.x!= 0)
                thisonerbg.velocity = new Vector2(thisonerbg.velocity.x / derrape, thisonerbg.velocity.y);
        }
    }
    bool Coldown()
    {
        foreach(RaycastHit2D col in Physics2D.RaycastAll(transform.position, Vector2.down,distancedown))
        {
            if (col.transform != transform)
            {
                return true;
            }
        }
        return false;
    }
}
