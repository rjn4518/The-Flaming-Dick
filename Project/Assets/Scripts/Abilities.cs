using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : PlayerController
{
    protected override void GrapplingHook()
    {
        base.GrapplingHook();

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePoint = new Vector2(rb.transform.position.x, rb.transform.position.y);

        Ray2D grapplingHook = new Ray2D(firePoint, mousePosition - firePoint); 
        Debug.DrawRay(firePoint, mousePosition - firePoint);
        Debug.Log(mousePosition - firePoint);
    }
}