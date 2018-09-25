/* Ideas:
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : PlayerController
{
    public LayerMask layerMask;
    public float distance = 5f;
    public float minHookDist = 0.5f;

    private Vector3 mousePos;
    private Vector3 firePoint;
    private RaycastHit2D hit;
    private Vector2 contactPoint;

    protected override void GrapplingHook()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        firePoint = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);

        hit = Physics2D.Raycast(firePoint, mousePos - firePoint, distance, layerMask);
        Debug.DrawRay(firePoint, mousePos - firePoint, Color.red, 0.2f);
        Debug.Log(hit.collider);

        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            joint.enabled = true;

            contactPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
            contactPoint.x = contactPoint.x / hit.collider.transform.localScale.x;
            contactPoint.y = contactPoint.y / hit.collider.transform.localScale.y;
            Debug.Log(hit.point);

            joint.anchor = (Vector2)player.transform.position;
            joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            joint.connectedAnchor = contactPoint - (Vector2)player.transform.position;
            joint.distance = Vector2.Distance(transform.position, hit.point);
        }
    }
}