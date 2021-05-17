using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformMainScript : MonoBehaviour
{

    public Rigidbody2D rigidbody2DOfThisPlatform;

    public float lowerYAxisLimitOfPlatform;
    public float velocityOfPlatform;
    [SerializeField] private float upperYAxisLimitOfPlatform;


    // Start is called before the first frame update
    void Start()
    {
        upperYAxisLimitOfPlatform = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlatformBySettingAndChangingTheVelocityAccordingToTheYLimits();
    }

    private void MoveThePlatformBySettingAndChangingTheVelocityAccordingToTheYLimits()
    {
        if (transform.position.y >= upperYAxisLimitOfPlatform)
        {
            rigidbody2DOfThisPlatform.velocity = new Vector2(0f, -velocityOfPlatform);
        }

        else if (transform.position.y <= (upperYAxisLimitOfPlatform - lowerYAxisLimitOfPlatform))
        {
            rigidbody2DOfThisPlatform.velocity = new Vector2(0f, velocityOfPlatform);
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
