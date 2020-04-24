using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//getting information from the enemy script th
public class Summoner : Enemy
{
    //variables taking random postions from the map between set min and max Y and X
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    //refernce to the animator atteched to the Summoner to change animations from idle, moving and summon
    private Animator anim;

    //selects the area of the map where it starts to spawn it's minions(other enemy AI)
    private Vector2 targetPosition;

    // time between each summon to spawn
    public float timeBetweenSummons;
    //how long will take to summon
    private float summonTime;
    //what enemy will be summoned
    public Enemy enemyToSummon;

    //it overides the other start funcition from the enemy script
    public override void Start()
    {
        //calls the function start from the enemy script
        base.Start();
        //creating random number from x asixs and y asixs
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        //target postion from the two new random numbers
        targetPosition = new Vector2 (randomX, randomY);
        //get refernce from the animator to change animation
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //if player is alive
        if (player !=null)
        {
            //if the new target postion is greater then 0.5 that means they are to far away that means the AI needs to mover more
            if (Vector2.Distance(transform.position, targetPosition)> .5f)
            {
                //to move AI to that new position 
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                //tells to play the run annimation 
                anim.SetBool("Run", true);
            }
            else
            {
                //if the AI reached the position it stops the animation
                anim.SetBool("Run", false);

                //it triggers the summon animation and summons other AI where the triger is
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
            }
        }
    }
    public void Summon()
    {
        //if player is alive
        if (player != null)
        {
            //starts summoning the enemy selected
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }

}


