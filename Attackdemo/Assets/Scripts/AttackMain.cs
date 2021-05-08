using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMain : MonoBehaviour
{

    public playerController2D playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean;
    public Animator animatorOfThePlayer;
    public BoxCollider2D myAtackBoxCollider;

    private Statuses statusSciptOfEnemy;
    private Rigidbody2D enemyRigidBody;
    private bool doThePush;
    private bool isGrounded;
    private bool canAttack = true;
    private int attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted;
    private float playerFacingDirection;

         
    
    public Transform groundCheck;
    public Transform groundCheckR;
    public Transform groundCheckL;

    public float pushBackForceOfFirstAttack;
    public int damageOfFirstAttack;
    public float windingUpTimeOfFirstAttack;
    public int damageOfSecondAttack;
    public float windingUpTimeOfSecondAttack;
    public int damageOfThirdAttack;
    public float windingUpTimeOfThirdAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = 10;// any number greater than the topmost number
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerIsGrounded();

        CheckPlayerFacingDirection();
        IfDoThePushBooleanIsActivatedAndEnemyHasBeenDetectedThenPushTheEnemy();

        if (canAttack)
        {
            StartCoroutine(AttackWhenAttackButtonIsPressed());
        }
    }


    public void CheckIfPlayerIsGrounded()
    {
        if ((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                 (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                  (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }

    void IfDoThePushBooleanIsActivatedAndEnemyHasBeenDetectedThenPushTheEnemy()
    {
        if (enemyRigidBody)
        {
            Debug.Log("Enemy rigidbody attached");

            if (doThePush == true)
            {

                Vector2 pushBackForceToAddAsVector = new Vector2(playerFacingDirection * pushBackForceOfFirstAttack, 0f);

                enemyRigidBody.AddForce(pushBackForceToAddAsVector, ForceMode2D.Impulse);

                Debug.Log("pushed");
                if (!isGrounded)
                {
                    animatorOfThePlayer.Play("attack_JumpKick");
                }
                else
                {
                    animatorOfThePlayer.Play("attack_Kick");
                }
                doThePush = false;

                enemyRigidBody = null; // to free up the rigidbody reference
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Collision with enemy successfully detected");

            enemyRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();

        }
    }

    void CheckPlayerFacingDirection()
    {
        if (gameObject.transform.rotation.y == 0)
        {
            playerFacingDirection = 1; // 1 means right

        }
        else if (gameObject.transform.rotation.y == -1)
        {
            playerFacingDirection = -1;

        }

    }











    public IEnumerator AttackWhenAttackButtonIsPressed()
    {
        if(enemyRigidBody)
        {
            statusSciptOfEnemy = enemyRigidBody.gameObject.GetComponent<Statuses>();
            


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                
                attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted += 1;

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted > 2)
                {
                    attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted = 0;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 0)
                {
                    playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean.canMove = false;
                    canAttack = false;
                    yield return new WaitForSeconds(windingUpTimeOfFirstAttack);
                    doThePush = true;
                    Debug.Log("Attack button pressed part");
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfFirstAttack);

                    
                    
                    statusSciptOfEnemy = null;
                    playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean.canMove = true;
                    canAttack = true;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 1)
                {
                    canAttack = false;
                    playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean.canMove = false;
                    yield return new WaitForSeconds(windingUpTimeOfSecondAttack);
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfSecondAttack);
                    animatorOfThePlayer.Play("attack_leftPunch");
                    Debug.Log("Doing second attack");
                    statusSciptOfEnemy = null;
                    playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean.canMove = true;
                    canAttack = true;
                }

                if(attackIDCounterWhichIsUsedToControlWhichAttackIsToBeExecuted == 2)
                {
                    canAttack = false;
                    playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean.canMove = false;
                    yield return new WaitForSeconds(windingUpTimeOfThirdAttack);
                    statusSciptOfEnemy.DecreaseHealthByTheNumber(damageOfThirdAttack);
                    animatorOfThePlayer.Play("attack_rightPunch");
                    Debug.Log("Doing third attack");
                    statusSciptOfEnemy = null;
                    playerControllerReferenceWhichHasATurnOnAndTurnOffBoolean.canMove = true;
                    canAttack = true;
                }


            }
        }
    }
}
