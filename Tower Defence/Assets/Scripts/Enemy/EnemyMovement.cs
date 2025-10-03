using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    public float rotationSpeed = 5f;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

        //Set target equal to the first wavepoint
        target = Waypoints.points[0];
    }

    private void Update()
    {
        //Target move towards waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //Remove if enemy rotation doesn't work
        RotateTowardsWaypoint();
        //Remove end here

        //Target reaches waypoint distance and will then gets the position of next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.02f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }


        //This will gather the next waypoint plus an additional 1 and will then assign the next waypoint as current waypoint
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    //Remove if doesnt work for enemy roation
    private void RotateTowardsWaypoint()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
    }

    // Ends here for removal 
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
