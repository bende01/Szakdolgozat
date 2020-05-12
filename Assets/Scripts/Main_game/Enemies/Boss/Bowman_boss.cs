using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowman_boss : StateMachineBehaviour
{
    private GameObject bowman;

    private float time = 0;
    private Boss_Behaviour boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        time = 0;
        animator.SetFloat("time", time);


        boss = animator.GetComponent<Boss_Behaviour>();

        bowman = boss.bowman;
        bowman.transform.position = new Vector3(animator.GetFloat("x"), animator.GetFloat("y"), 0);

        bowman.SetActive(true);
        

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {

        if (boss.player == null)
        {
            return;
        }
        time += Time.deltaTime;
        animator.SetFloat("time", time);

        animator.SetFloat("distance", Vector3.Distance(bowman.transform.position, boss.player.transform.position));


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(bowman != null)
        {
            animator.SetFloat("x", bowman.transform.position.x);
            animator.SetFloat("y", bowman.transform.position.y);
            bowman.SetActive(false);
        }
       

        

    }

}
