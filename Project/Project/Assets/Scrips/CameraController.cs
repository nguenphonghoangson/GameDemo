using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    public Vector3 maxvalue, minvalue;

    private float smoothing = 5f;

    void Start()
    {
        offset = new Vector3(0.3f, 0.3f, transform.position.z);
        transform.position = target.position + offset;
    }
    void FixedUpdate()
    {
        Vector3 positon = target.position + offset;
        Vector3 targetpositon = new Vector3(Mathf.Clamp(positon.x, minvalue.x, maxvalue.x), Mathf.Clamp(positon.y, minvalue.y, maxvalue.y), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetpositon, smoothing * Time.deltaTime);
        

    }
}
