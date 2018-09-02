using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;
    public int worth = 50;

    public GameObject deathEffect;


    private void Start()
    {
        speed = startSpeed;
    }
    public void takeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Health == " +  health);
        if (health <= 0)
        {
            die();
        }
    }

    public void slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }

    void die()
    {
        PlayerStats.money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
}
