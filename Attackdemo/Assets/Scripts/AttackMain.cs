using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMain : MonoBehaviour
{


    public int attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted;
    public Attack pushBackScript;
    public int damageOfFirstAttack;
    public int damageOfSecondAttack;
    public int damageOfThirdAttack;
    public Statuses statusSciptOfEnemy;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = 10;// any number greater than the topmost number
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        AttackWhenAttackButtonIsPressed();
    }

    public void AttackWhenAttackButtonIsPressed()
    {
        if(pushBackScript.enemyRigidBody)
        {
            statusSciptOfEnemy = pushBackScript.enemyRigidBody.gameObject.GetComponent<Statuses>();
            Debug.Log("Entered the main attack script");


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Main attack script is working");
                attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted += 1;

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted > 2)
                {
                    attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = 0;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 0)
                {
                    pushBackScript.isAttackButtonPressed = true;
                    Debug.Log("Attack button pressed part");
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfFirstAttack);
                    
                    
                    statusSciptOfEnemy = null;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 1)
                {
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfSecondAttack);
                    animator.Play("attack_leftPunch");
                    statusSciptOfEnemy = null;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 2)
                {
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfThirdAttack);
                    animator.Play("attack_rightPunch");
                    statusSciptOfEnemy = null;
                }


            }
        }
    }
}
