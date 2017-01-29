using UnityEngine;
using System.Collections;

public class SimpleLerp : MonoBehaviour {


    public Transform pointOne;
    public Transform pointTwo;
    public float speed = 1.0f;

    float startTime;
    float journeyLength;

    bool direction = false;
	
    void Start()
    {
        makePos();
    }

	// Update is called once per frame
	void Update ()
    {
        float dist = (Time.time - startTime) * speed;
        float journeyLengthfrac = dist / journeyLength;

        if (direction)
        {
            transform.position = Vector3.Lerp(pointOne.position, pointTwo.position, journeyLengthfrac);
        }
        else
        {
            transform.position = Vector3.Lerp(pointTwo.position, pointOne.position, journeyLengthfrac);
        }

        if(((transform.position == pointOne.position)||(transform.position == pointTwo.position)))
        {
            direction = !direction;
            makePos();
        }


    }

    void makePos()
    {
        startTime = Time.time;
        if (direction)
        {
            journeyLength = Vector3.Distance(pointOne.position, pointTwo.position);
        }
        else
        {
            journeyLength = Vector3.Distance(pointTwo.position, pointOne.position);
        }
    }
}
