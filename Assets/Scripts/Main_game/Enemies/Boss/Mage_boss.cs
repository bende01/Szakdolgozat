using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_boss : StateMachineBehaviour
{
    private GameObject mage;

    private float time = 0;
    private Boss_Behaviour boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        time = 0;
        animator.SetFloat("time", time);


        boss = animator.GetComponent<Boss_Behaviour>();

        mage = boss.mage;
        mage.transform.position = new Vector3(animator.GetFloat("x"), animator.GetFloat("y"), 0);

        mage.SetActive(true);


    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        if (boss.player == null)
        {
            return;
        }   
        time += Time.deltaTime;
        animator.SetFloat("time", time);

        animator.SetFloat("distance", Vector3.Distance(mage.transform.position, boss.player.transform.position));


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("x", mage.transform.position.x);
        animator.SetFloat("y", mage.transform.position.y+0.5f);

        mage.SetActive(false);

    }
}
