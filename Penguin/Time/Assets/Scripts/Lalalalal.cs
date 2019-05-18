using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lalalalal : MonoBehaviour
{
    public Transform barhp;
    public float hp,tiempoEntreGolpe;
    float t, inis;//,iniy;
    // Start is called before the first frame update
    void Start()
    {
        inis = barhp.localScale.y;
        //iniy = barhp.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp,0,100);
        t += Time.deltaTime;
        barhp.localScale = new Vector2(barhp.localScale.x, hp / 100 * inis);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            if(t>tiempoEntreGolpe)
            hp--;
        }
    }
}
