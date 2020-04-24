using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Crowd : MonoBehaviour
{
    //to adjust the movement speed from one point to another 
    public float speed;
    //making the ai wait
    private float waitTime;
    //when the wait time will start
    public float startWaitTime;
    //potaniol red spots can move to
    public Transform[] moveSpots;
    //to pick a random red spot postion
    private int randomSpot;
    void Start() 
    {
        waitTime= startWaitTime;
        //inter variable can be equal to a number between zero and the number of elements in the array
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update() 
    {
        //make the AI move from to where(random postion in the array) and at what speed
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed *Time.deltaTime);
    
        //if reached that spot will wait few seconds before moving to a random location by checking the distance then the if stament can return true
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position)< 0.2f)
        {
            //to check the time to characther to start moving again to a new random postion
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            //if it isn't it will decrasse the time            
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }


}
