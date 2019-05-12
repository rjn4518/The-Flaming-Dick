using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterH : MonoBehaviour
{
    public List<Transform> repeat; // 4
    public float leng = 5;
    public Transform fool;
    float dif;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //0
        foreach (Transform o in repeat)
        {
            dif = fool.position.x - o.position.x;
            if (dif > leng * 4)
            {
                o.Translate(leng * 8 * Vector2.right);
            }
            if (dif < leng * -4)
            {
                o.Translate(leng * 8 * Vector2.left);
            }
            dif = fool.position.y - o.position.y;
            if (dif > leng * 4)
            {
                o.Translate(leng * 8 * Vector2.up);
            }
            if (dif < leng * -4)
            {
                o.Translate(leng * 8 * Vector2.down);
            }
        }

    }
}
