using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public float pushBackForceOfFirstAttack;

    public bool isAttackButtonPressed;

    public bool DoPushAttackBooleanForTheWholeScript = true;


    public BoxCollider2D myAtackBoxCollider;
    public float playerFacingDirection;
    public Rigidbody2D enemyRigidBody;
    


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DoPushAttackBooleanForTheWholeScript)
        {
            CheckPlayerFacingDirection();
            CheckIfAttackButtonIsPressedSinceInputCanOnlyBeTakenThroughUpdateMethod();
            IfAttackButtonIsPressedAndEnemyHasBeenDetectedThenPushTheEnemy();
        }

    }

    void IfAttackButtonIsPressedAndEnemyHasBeenDetectedThenPushTheEnemy()
    {
        if (enemyRigidBody)
        {
            Debug.Log("Enemy rigidbody attached");

            if (isAttackButtonPressed == true)
            {
                
                Vector2 pushBackForceToAddAsVector = new Vector2(playerFacingDirection * pushBackForceOfFirstAttack, 0f);
                
                enemyRigidBody.AddForce(pushBackForceToAddAsVector, ForceMode2D.Impulse);
                
                Debug.Log("pushed");
                
                enemyRigidBody = null; // to free up the rigidbody reference
            }
        }
    }

    void CheckIfAttackButtonIsPressedSinceInputCanOnlyBeTakenThroughUpdateMethod()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            isAttackButtonPressed = true;
            animator.Play("attack_Kick");
        }
        else
        {
            isAttackButtonPressed = false;
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
}
