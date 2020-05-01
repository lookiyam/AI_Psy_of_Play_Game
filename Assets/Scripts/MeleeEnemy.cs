using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// instead of monobehavior recall the Enemy script that inclueds health and take damage funcion so that every type of enemy will have the same base
public class MeleeEnemy : Enemy
{
    // i want that the melle enemy follows the player 
    // so I need a stop distance
    // attack time schedule
    // and define the attak speed within the time frame
    public float stopDistance;
    private float attackTime;
    public float attackSpeed;
    
    private void Update()
    {
        // if the player is not dead
        // check if the distance is more than the stop distance (if the enemy is too far) -> move towards the player (until enemy reach the stop distance)
        // if enemy reachs the stop distance
        // if the attack time is greater than the game time -> set the atack time + time between attacks and start attack coroutine
        if (player != null)
        {
            if(Vector2.Distance(transform.position, player.position) > stopDistance) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if(Time.time >= attackTime)
                {
                    // attack starting coroutine and reset timer
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }
    //coroutine for attacks
    IEnumerator Attack()
    {
        // get the player component that has the take damage function and deal the damage argument referring to the enemy script
        player.GetComponent<Player>().TakeDamage(damage);

        //animate the leap
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        // when the float is set to 0 means that we have to astart the animation
        // when is set to 1 means that we have compleated the animation
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
