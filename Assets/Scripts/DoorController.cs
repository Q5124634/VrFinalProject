using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorController : MonoBehaviour {
    public float speed = 0.005F;
    public GameObject Door;
    public GameObject DoorEnd;
    public GameObject DoorStart;
    private float startTime;
    private float journeyLength;
    public bool DoorIsOpen;
    public bool StartTimer = false;
    public Text TimerText;
    private float TimerStart;
    public float StartedTimer = 0;
    private float NewTime;
    public string SavedTime;
    public GameObject EndButton;


    void Start()
    {
     float XValue = Door.transform.position.x;
     float YValue = Door.transform.position.y;
     float ZValue = Door.transform.position.z;

        
        startTime = Time.time;
        journeyLength = Vector3.Distance(Door.transform.position, DoorEnd.transform.position);
    }



    void Update () {
        if(DoorIsOpen)
        {
            //TimerStart = Time.time;
            float distCovered = (Time.deltaTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorEnd.transform.position, fracJourney);
            StartTimer = true;
             StartCoroutine(WaitOneSecond());
           
        }

        if (!DoorIsOpen)
        {
            //TimerStart = Time.time;
            float distCovered = (Time.deltaTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorStart.transform.position, fracJourney);

        }

        if (StartTimer == true)
        {
            StartTiming();
        }

        if (StartTimer == false)
        {
            EndTiming();
            return;
        }

    }


    void EndTiming()
    {
        SavedTime = TimerText.text;
        TimerText.color = Color.cyan;
    }

    void StartTiming()
    {
        if (StartedTimer >= 0)
        {
            NewTime += Time.deltaTime;
            float minuites = NewTime / 60;
            float seconds = NewTime % 60;
            float millSecs = (NewTime * 100) % 100;

            TimerText.text = string.Format ("{0:00} : {1:00} : {2:00}", minuites, seconds , millSecs);
        }
        else
        {

        }

        
    }

    void OnMouseDown()
    {
        DoorIsOpen = true;
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(5);
        DoorIsOpen = false;
    }

}
