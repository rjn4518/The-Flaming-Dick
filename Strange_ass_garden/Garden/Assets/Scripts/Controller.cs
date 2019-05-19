using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 mousePos;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MouseFollow();
	}

    void MouseFollow()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
       // mousePos.z = mousePos.z - Camera.main.transform.position.z;

        Debug.Log(mousePos);

        transform.position = Vector3.Lerp(transform.position, mousePos, 0.05f);
    }
        
}
