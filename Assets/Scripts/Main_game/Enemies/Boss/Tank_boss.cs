using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_boss : StateMachineBehaviour
{
    private GameObject tank;
    private float time;
    private Boss_Behaviour boss;
    private float cd;

    public int switchCooldownRange = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = 0;
        cd = Random.Range(3, 3 + switchCooldownRange);

        animator.SetFloat("time", time);

        boss = animator.GetComponent<Boss_Behaviour>();

        tank = boss.tank;

        tank.transform.position = new Vector3(animator.GetFloat("x"), animator.GetFloat("y"), 0);
        tank.SetActive(true);
        

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

        animator.SetFloat("distance", Vector3.Distance(tank.transform.position, boss.player.transform.position));

        if (time > cd)
        {
            animator.SetTrigger("switch");
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        animator.SetFloat("x", tank.transform.position.x);
        animator.SetFloat("y", tank.transform.position.y+0.2f);

        tank.SetActive(false);



    }
}
