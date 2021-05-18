using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformMainScript : MonoBehaviour
{

    

    
    public float speedOfPlatform;
    

    public Transform waypointUpper;
    public Transform waypointLower;

    public Vector2 theVector2OfLowerWaypoint;
    public Vector2 theVector2OfUpperWaypoint;

    public bool moveDownwards;
    public bool moveUpwards;

    // Start is called before the first frame update
    void Start()
    {

        moveUpwards = true;

    }



    // Update is called once per frame
    void Update()
    {
        MoveThePlatformBySettingAndChangingTheVelocityAccordingToTheYLimits();
        
        if(moveUpwards == true)
        {
            MoveUpwards();
        }

        else if(moveDownwards == true)
        {
            MoveDownwards();
        }
    }

    private void MoveThePlatformBySettingAndChangingTheVelocityAccordingToTheYLimits()
    {
        if (transform.position.y > waypointUpper.position.y)
        {
            moveUpwards = false;
            moveDownwards = true;
        }

        else if (transform.position.y < waypointLower.position.y)
        {
            moveDownwards = false;
            moveUpwards = true;
        }
    }

    private void MoveUpwards()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speedOfPlatform);
    }

    private void MoveDownwards()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speedOfPlatform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }

    
}
