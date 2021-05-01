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
    // Start is called before the first frame update
    void Start()
    {
        attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = -1;
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
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfFirstAttack);
                    //Do The animation call in this line
                    
                    statusSciptOfEnemy = null;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 1)
                {
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfSecondAttack);
                    statusSciptOfEnemy = null;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 2)
                {
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfThirdAttack);
                    statusSciptOfEnemy = null;
                }


            }
        }
    }
}
