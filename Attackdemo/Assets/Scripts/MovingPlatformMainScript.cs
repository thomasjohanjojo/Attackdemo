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


    // Start is called before the first frame update
    void Start()
    {
        
        theVector2OfUpperWaypoint = new Vector2(waypointUpper.position.x, waypointUpper.position.y);
        transform.position = Vector2.MoveTowards(transform.position, theVector2OfUpperWaypoint, speedOfPlatform * Time.deltaTime);

    }



    // Update is called once per frame
    void Update()
    {
        MoveThePlatformBySettingAndChangingTheVelocityAccordingToTheYLimits();
    }

    private void MoveThePlatformBySettingAndChangingTheVelocityAccordingToTheYLimits()
    {
        if (transform.position.y >= waypointUpper.position.y)
        {
            theVector2OfLowerWaypoint = new Vector2(waypointLower.position.x, waypointLower.position.y);
            transform.position = Vector2.MoveTowards(transform.position, theVector2OfLowerWaypoint, speedOfPlatform * Time.deltaTime);
        }

        else if (transform.position.y <= waypointLower.position.y)
        {
            theVector2OfUpperWaypoint = new Vector2(waypointUpper.position.x, waypointUpper.position.y);
            transform.position = Vector2.MoveTowards(transform.position, theVector2OfUpperWaypoint, speedOfPlatform * Time.deltaTime);
        }
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
