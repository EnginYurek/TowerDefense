using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    public int health = 100;
    public int value = 50;

    private Transform target;
    private int wayPointIndex = 0;
    public GameObject deathEffect;

    void Start()
    {

        target = WayPoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextWayPoint();
        }


    }

    public void takeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Health == " +  health);
        if (health <= 0)
        {
            die();
        }


    }

    void die()
    {
        PlayerStats.money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
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
        Destroy(gameObject);

    }
}
