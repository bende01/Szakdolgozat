using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher_boss : StateMachineBehaviour
{
    private GameObject dasher;
    private float time;
    private Boss_Behaviour boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        
        animator.SetFloat("time", time);
        
        boss = animator.GetComponent<Boss_Behaviour>();
        
        dasher = boss.dasher;
      
        dasher.transform.position = new Vector3(animator.GetFloat("x"), animator.GetFloat("y"), 0);
        dasher.SetActive(true);
       

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.player == null)
        {
            return;
        }
        time += Time.deltaTime;
        animator.SetFloat("time", time);

        animator.SetFloat("distance", Vector3.Distance(dasher.transform.position, boss.player.transform.position));


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        animator.SetFloat("x", dasher.transform.position.x);
        animator.SetFloat("y", dasher.transform.position.y);

        dasher.SetActive(false);

        

    }
}
