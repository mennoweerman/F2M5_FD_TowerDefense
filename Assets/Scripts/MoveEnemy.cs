using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

    public GameObject Enemy;

    void Start()
    {

        transform.position = wayPoints[waypointIndex].transform.position;
    }

    void Update()
    {


        // attack


        Move();
    }



    void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == wayPoints.Length)
        {
            Destroy(Enemy);
        }



    }
}
