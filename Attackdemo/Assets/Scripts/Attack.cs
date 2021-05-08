using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;

    public float pushBackForceOfFirstAttack;

    public bool doThePush;

    


    public BoxCollider2D myAtackBoxCollider;
    public float playerFacingDirection;
    public Rigidbody2D enemyRigidBody;

    public bool isGrounded;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckR;
    [SerializeField]
    Transform groundCheckL;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        
        
        CheckPlayerFacingDirection();
        IfDoThePushBooleanIsActivatedAndEnemyHasBeenDetectedThenPushTheEnemy();
        

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
                    animator.Play("attack_JumpKick");
                }
                else
                {
                    animator.Play("attack_Kick");
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
}

    
