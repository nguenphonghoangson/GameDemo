using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public int speed;
    public bool clockwise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * speed);
        }
        else
        {
            transform.Rotate(Vector3.back, Time.deltaTime * speed);
        }
    }
}
