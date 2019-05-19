using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 mousePos;
	
	void Update ()
    {
        MouseFollow();
	}

    void MouseFollow()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        transform.position = Vector3.Lerp(transform.position, mousePos, 0.05f);
    }
}
