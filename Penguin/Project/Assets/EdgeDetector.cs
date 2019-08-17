using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetector : MonoBehaviour
{
    protected static bool edge;
    protected static bool onEdge;

    public static bool GetEdge()
    {
        return edge;
    }

    public static bool GetOnEdge()
    {
        return onEdge;
    }

    public static void SetOnEdge(bool ass)
    {
        onEdge = ass;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        edge = true;
        onEdge = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        edge = false;
    }
}
