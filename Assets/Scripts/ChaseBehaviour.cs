using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    // this script will work for the second boss syage, the chase stage
    // create a variable that represent the player
    private GameObject player;

    // create a variable that represent the speed of the boss
    public float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // this works as Start function
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // recognise the player via tag Player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // this works a supdate function
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if the player is not dead
        // move towards the player
        if (player != null)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
