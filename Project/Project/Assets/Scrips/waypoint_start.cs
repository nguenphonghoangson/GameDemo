using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class waypoint_start : MonoBehaviour
{
    private Collider2D coll;
    [SerializeField] Transform[] waypoints;
    [SerializeField] private float movespeed = 2f;

    int waypointIndex = 0;
    public static bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move(check);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Move(true);
        }

    }
    public void Move(bool ply)
    {
        if (ply == true)
        {
            transform.position = Vector2.MoveTowards(
            transform.position, waypoints[waypointIndex].transform.position, movespeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
            if (waypointIndex == waypoints.Length)
                waypointIndex = 0;
            check = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(
           transform.position, waypoints[waypointIndex].transform.position, movespeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 0;
            }
            if (waypointIndex == waypoints.Length)
                waypointIndex = 0;
            check = false;
        }

    }
}
