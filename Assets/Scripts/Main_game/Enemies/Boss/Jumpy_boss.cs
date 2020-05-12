using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy_boss : StateMachineBehaviour
{
    private float time;
    private GameObject jumpy;
    private Boss_Behaviour boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss_Behaviour>();
        jumpy = boss.jumpy;

        time = 0;

        animator.SetFloat("time", time);

        jumpy.transform.position = new Vector3(animator.GetFloat("x"), animator.GetFloat("y"), 0);

        jumpy.SetActive(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        animator.SetFloat("time", time);

        if (boss.player == null)
        {
            return;
        }
        if (jumpy.GetComponentInChildren<Jumpy_Jump>().ended)
       {
            animator.SetTrigger("jumpyAttack");
       }

        animator.SetFloat("distance", Vector3.Distance(jumpy.transform.position, boss.player.transform.position));

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("x", jumpy.transform.position.x);
        animator.SetFloat("y", jumpy.transform.position.y);
        jumpy.GetComponentInChildren<Jumpy_Jump>().ended = false;
        animator.ResetTrigger("jumpyAttack");
        jumpy.SetActive(false);
    }


}
