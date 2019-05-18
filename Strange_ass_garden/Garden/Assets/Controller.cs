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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = mousePos.z - Camera.main.transform.position.z;

        transform.position = Vector3.Lerp(transform.position, mousePos, 0.1f);

        Debug.Log(Input.mousePosition);
    }
        
}
