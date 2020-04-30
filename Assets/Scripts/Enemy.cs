using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    
    [HideInInspector]
    public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;
    public int pickupChance;
    public GameObject[] pickups;

    //virtual so it will be the start for all other scripts 
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
