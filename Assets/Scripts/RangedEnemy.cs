using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    // this ranged enemy will follow the player and shoot projectiles
    // I need to know when the enemy will stop
    // how many time it has to attack within a frame of time
    public float stopDistance;
    private float attackTime;

    // get access to the animator in order to change between Idle and attack animatons
    private Animator anim;

    // basically is the crossbow of the enemy 
    public Transform shotPoint;
    public GameObject enemyBullet;

    // override the enemy script start function but still getting the base of the general enemy script
    public override void Start() 
    {
        base.Start();
        // recall the animator componend attached to the ranged enemy
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // if the player is not dead
        //check if the vector between tha player and the enemy is greater than the stop distance
        // if it is -> move towards the player
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            // if the current time is equal or great of the attack time
            // if it is -> set the attack time = to current time in the game + the time between attacks
            // and play attack animation
            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                anim.SetTrigger("Attack");
            }
        }
    }

    // after the tag inside the animation has been set up
    // calculate the direction of the player and the shotpoint
    // after instantiate the bullet in the shotpoint position
    public void RangedAttack()
    {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
    }
}
