using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : PlayerController
{
    public LayerMask layerMask;
    public float distance = 5f;
    public float step = 0.02f;
    public DistanceJoint2D joint;

    private Vector3 mousePos;
    private Vector3 firePoint;
    private RaycastHit2D hit;
    private Vector2 contactPoint;

    private void Start()
    {
        if (joint == null)
        {
            joint = GetComponent<DistanceJoint2D>();
            joint.enabled = false;

        }
    }

    protected override void GrapplingHook()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        firePoint = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);

        hit = Physics2D.Raycast(firePoint, mousePos - firePoint, distance, layerMask);
        Debug.DrawRay(firePoint, mousePos - firePoint);
        Debug.Log(hit.collider);
        Debug.Log(Input.GetAxis("Vertical"));

        if (joint.distance > 0.5f && Input.GetAxis("Vertical") != 0)
        {
            joint.distance -= step * Input.GetAxis("Vertical");
        }

        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            joint.enabled = true;

            contactPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
            contactPoint.x = contactPoint.x / hit.collider.transform.localScale.x;
            contactPoint.y = contactPoint.y / hit.collider.transform.localScale.y;
            Debug.Log(hit.point);

            joint.anchor = Vector2.zero;
            joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            joint.connectedAnchor = contactPoint;
        }

        if (Input.GetButtonDown("Jump"))
        {
            joint.enabled = false;
        }
    }
}