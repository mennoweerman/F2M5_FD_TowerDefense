using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;

    private Path _path;
    private Waypoint _currentWaypoint;

    private void Start()
    {
        SetUpPath();
    }

    private void SetUpPath()
    {
        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
    }

    private void PathComplete()
    {
        _speed = 0;
    }
    private void Update()
    {
        transform.LookAt(_currentWaypoint.GetPosition());
        transform.Translate(new Vector3(Vector3.forward.x, transform.position.y, Vector3.forward.z)* _speed * Time.deltaTime);

        float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.GetPosition());
        if (distanceToWaypoint <= _arrivalThreshold)
        {
            print("ik ben bij de waypoint");

            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }

            else
            {
                _currentWaypoint = _path.GetNextWayPoint(_currentWaypoint);
                transform.LookAt(new Vector3(_currentWaypoint.GetPosition().x, transform.position.y, _currentWaypoint.GetPosition().z));
            }
        }
    }
}
