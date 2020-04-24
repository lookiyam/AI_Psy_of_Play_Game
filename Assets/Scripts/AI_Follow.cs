using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Follow : MonoBehaviour
{
// speed  variables of how fast the ai to reach the player 
public float speed;
//how far the AI can reach the target (variable)
public float stoppingDistance;
//what game object the AI will go after 
private Transform target;


void Start () 
    {
        //find the game object that has the player tag 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

void Update()
    {
        //checking if the target which is the player is alive
        if (target != null)
            {
               //checking the distance between the player and the AI if the disatnce greater then number the AI can keep moving near the player
            if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                //move the AI to the target postion (the player) at a certain speed
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            }
            else
            {
                //if death destory the AI
                Destroy(this.gameObject);
            }
    }
}
