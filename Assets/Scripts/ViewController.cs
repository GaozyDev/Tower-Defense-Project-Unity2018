using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{

    public float speed = 80;
    public float mouseSpeed = 100;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h * speed, -mouse * mouseSpeed * speed, v * speed) * Time.deltaTime, Space.World);
    }
}
