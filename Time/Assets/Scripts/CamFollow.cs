using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform targuet;
    public Vector3 offset;
    public float smoothness = 25,xoffset,yoffset;
    public bool clamp;
    public float limit;
    float dx, dy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        dx = targuet.position.x + offset.x - transform.position.x;
        dy = targuet.position.y + offset.y - transform.position.y;
        if (xoffset != 0 && yoffset != 0)
        {
            Debug.DrawRay(new Vector2(transform.position.x-offset.x - xoffset, transform.position.y - offset.y - yoffset), new Vector2(0, yoffset * 2));
            Debug.DrawRay(new Vector2(transform.position.x - offset.x + xoffset, transform.position.y - offset.y - yoffset), new Vector2(0, yoffset * 2));
            Debug.DrawRay(new Vector2(transform.position.x - offset.x - xoffset, transform.position.y - offset.y + yoffset), new Vector2(xoffset * 2, 0));
            Debug.DrawRay(new Vector2(transform.position.x - offset.x - xoffset, transform.position.y - offset.y - yoffset), new Vector2(xoffset * 2, 0));

            if (-xoffset > dx) transform.position = new Vector3(targuet.position.x + offset.x + xoffset, transform.position.y, transform.position.z);
            if (xoffset < dx) transform.position = new Vector3(targuet.position.x + offset.x - xoffset, transform.position.y, transform.position.z);
            if (-yoffset > dy) transform.position = new Vector3(transform.position.x, targuet.position.y + offset.y + xoffset, transform.position.z);
            if (yoffset < dy) transform.position = new Vector3(transform.position.x, targuet.position.y + offset.y - xoffset, transform.position.z);
        }
        transform.position += new Vector3(dx, dy, 0) / smoothness;
        if(clamp)
        if (limit > transform.position.x)
        {
            transform.position = new Vector3(limit, transform.position.y, transform.position.z);
        }
    }
}
