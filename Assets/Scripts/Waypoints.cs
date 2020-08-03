using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] positions;

    void Start()
    {
        positions = new Transform[transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
