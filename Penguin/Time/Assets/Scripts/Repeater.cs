using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{
    float bc,sca;
    public Transform targuet;
    public List<Transform> repGo;
    public float spd = 0;
    float lastx;
    // Start is called before the first frame update
    void Start()
    {
        bc = repGo[0].GetComponent<BoxCollider2D>().size.x;
        sca = repGo[0].localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastx != targuet.position.x)
        {
            repGo[0].position = new Vector3(repGo[0].position.x + (targuet.position.x - lastx )* spd, repGo[0].position.y, repGo[0].position.z);
            repGo[1].position = new Vector3(repGo[1].position.x + (targuet.position.x - lastx) * spd, repGo[1].position.y, repGo[1].position.z);
            lastx = targuet.position.x;
        }

        if (repGo[0].position.x > targuet.position.x- bc * sca )
        {
            repGo[0].Translate(bc * sca * Vector2.left * 2);
        }
        if (repGo[0].position.x < targuet.position.x - bc * sca )
        {
            repGo[0].Translate(bc * sca * Vector2.right * 2);
        }
        if (repGo[1].position.x > targuet.position.x - bc * sca )
        {
            repGo[1].Translate(bc * sca * Vector2.left * 2);
        }
        if (repGo[1].position.x < targuet.position.x - bc * sca)
        {
            repGo[1].Translate(bc * sca * Vector2.right * 2);
        }
    }
}
