using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public float health = 100;

    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        //Set target equal to the first wavepoint
        target = Waypoints.points[0];
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        Destroy(gameObject);
    }

    private void Update()
    {
        //Target move towards waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Target reaches waypoint distance and will then gets the position of next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.02f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length -1)
        {
            EndPath();
            return;
        }


        //This will gather the next waypoint plus an additional 1 and will then assign the next waypoint as current waypoint
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
