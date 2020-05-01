using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // variable that calculate the health
    public int health;
    
    // reference the player but hiding this variable in the inspector
    [HideInInspector]
    public Transform player;
    public float speed;
    // useful to define the time between attacks declared by the Enemy scripts
    public float timeBetweenAttacks;
    // usefull to calculate the damage amount
    public int damage;
    public int pickupChance;
    public GameObject[] pickups;

    public GameObject deathEffect;

    //virtual so it will be the start for all other scripts 
    public virtual void Start()
    {
        // find the game object with the player tag, and get a transform component in the player object
        // so that the player will be = to the tag of player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // this calculate the damege taken by the enemy
    public void TakeDamage(int amount) 
    {
        // subtract damage amount from the health
        health -= amount;
        
        // how much damage has beel applied?
        // if enemy is dead -> destroy enemy object
        if (health <= 0)
        {
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
