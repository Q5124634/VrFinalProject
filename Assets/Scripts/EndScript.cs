using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public float speed = 0.005F;
    public GameObject Door;
    public GameObject DoorEnd;
    private float startTime;
    private float journeyLength;
    public bool DoorIsOpen;
    public bool EndGame = false;


    void Start()
    {
        float XValue = Door.transform.position.x;
        float YValue = Door.transform.position.y;
        float ZValue = Door.transform.position.z;

        startTime = Time.time;
        journeyLength = Vector3.Distance(Door.transform.position, DoorEnd.transform.position);
    }



    void Update()
    {
        if (DoorIsOpen)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorEnd.transform.position, fracJourney);
            EndGame = true;
        }


    }
    void OnMouseDown()
    {
        DoorIsOpen = true;
    }

}
