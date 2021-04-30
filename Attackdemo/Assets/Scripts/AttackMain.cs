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
    // Start is called before the first frame update
    void Start()
    {
        attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackWhenAttackButtonIsPressed()
    {
        if(pushBackScript.enemyRigidBody)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted++;

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted > 2)
                {
                    attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = 0;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 0)
                {

                }


            }
        }
    }
}
