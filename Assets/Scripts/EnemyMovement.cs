using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wayPointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void getNextWayPoint()
    {
        if (wayPointIndex >= WayPoints.points.Length - 1)
        {
            endPath();
            return;
        }

        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

    void endPath()
    {
        PlayerStats.lives -= 1;
        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);

    }
}
