using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    //this script will work for the first boss stage, the patrol stage
// this creates an arrey of control points where the boss will move in his first state
public GameObject [] patrolPoints;
// select a random point in the arrey
int randomPoint;
// the speed witch the boss will move within the patrol points
public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // it acts like the Start function
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // use the function with the tag of patrol Points
        patrolPoints = GameObject.FindGameObjectsWithTag("patrolPoints");
        // select a random nummber between 0 and the patrol points number (17)
        randomPoint = Random.Range (0, patrolPoints.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // similar to the Update function
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // move the boss around the patrol points
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolPoints[randomPoint].transform.position, speed * Time.deltaTime);

        //detect how close the boss must be before he moves to another patrol point
        // if the vector between the boss and the patrol point is less than 0.1f
        // recalculate the random point variable by getting a new random number
        if (Vector2.Distance(animator.transform.position, patrolPoints[randomPoint].transform.position) <0.1f)
        {
            randomPoint = Random.Range(0, patrolPoints.Length);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // this function will be called when the bos will stop his walking animation
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
