using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float pushBackForceOfFirstAttack;

    public bool isAttackButtonPressed;
    public BoxCollider2D myAtackBoxCollider;
    public float playerFacingDirection;
    public Rigidbody2D enemyRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerFacingDirection();
        CheckIfAttackButtonIsPressedSinceInputCanOnlyBeTakenThroughUpdateMethod();
    }


    void CheckIfAttackButtonIsPressedSinceInputCanOnlyBeTakenThroughUpdateMethod()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            isAttackButtonPressed = true;
        }
        else
        {
            isAttackButtonPressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Collision with enemy successfully detected");

            enemyRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidBody)
            {
                Debug.Log("Enemy rigidbody attached");
                
                if(isAttackButtonPressed == true)
                {
                    Vector2 pushBackForceToAddAsVector = new Vector2(playerFacingDirection * pushBackForceOfFirstAttack, 0f);
                    enemyRigidBody.AddForce(pushBackForceToAddAsVector, ForceMode2D.Impulse);
                    Debug.Log("pushed");
                }
            }
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
