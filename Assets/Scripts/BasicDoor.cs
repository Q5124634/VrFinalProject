using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour {

    public float speed = 0.005F;
    public GameObject Door;
    public GameObject DoorEnd;
    public GameObject DoorStart;
    private float startTime;
    private float journeyLength;
    public bool DoorIsOpen;
    public bool StartTimer = false;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(Door.transform.position, DoorEnd.transform.position);
    }

    void Update ()
    {

        if (DoorIsOpen)
        {
            float distCovered = (Time.deltaTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorEnd.transform.position, fracJourney);
            StartTimer = true;
            StartCoroutine(WaitOneSecond());

        }

        if (!DoorIsOpen)
        {
            float distCovered = (Time.deltaTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorStart.transform.position, fracJourney);

        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.transform.CompareTag("Controller"))
        {
            DoorIsOpen = true;
        }

    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(5);
        DoorIsOpen = false;
    }
}
