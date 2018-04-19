using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorController : MonoBehaviour
{
    public float speed = 0.005F;
    public GameObject Door;
    public GameObject DoorEnd;
    public GameObject DoorStart;
    public GameObject[] Known_Prefabs;
    public GameObject[] Known_Prefabs_Target;
    private float startTime;
    private float journeyLength;
    public bool DoorIsOpen;
    public bool StartTimer = false;
    public Text TimerText;
    public float StartedTimer = 0;
    private float NewTime;
    public string SavedTime;
    public GameObject EndButton;
    public bool firstinitialise = false;
    public GameObject[] EnemiesSpawned;


    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(Door.transform.position, DoorEnd.transform.position);

    }

    void Update()
    {

        if (DoorIsOpen)
        {
            float distCovered = (Time.deltaTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorEnd.transform.position, fracJourney);
            StartTimer = true;
            StartCoroutine(WaitOneSecond());
        }

        if (gameObject.tag == ("CanClose"))
        {
            if (!DoorIsOpen)
            {
                float distCovered = (Time.deltaTime) * speed;
                float fracJourney = distCovered / journeyLength;
                Door.transform.position = Vector3.Lerp(Door.transform.position, DoorStart.transform.position, fracJourney);
            }
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

            TimerText.text = string.Format("{0:00} : {1:00} : {2:00}", minuites, seconds, millSecs);
        }
    }

    void OnTriggerEnter(Collider Col)
    {


        if (Col.gameObject.transform.CompareTag("Controller"))
        {
            DoorIsOpen = true;

            GameObject[] clonecheck;
            clonecheck = GameObject.FindGameObjectsWithTag("Clone");

            if (clonecheck.Length != 0)
            {
                EnemiesSpawned = GameObject.FindGameObjectsWithTag("Clone");
                for (int i = 0; i < EnemiesSpawned.Length; i++)
                    Destroy(EnemiesSpawned[i]);
                NewTime = 0;

                for (int i = 0; i < Known_Prefabs.Length; i++)
                {

                    CLoneTag(i);


                }
            }
            if (clonecheck.Length == 0)
            {
                for (int i = 0; i < Known_Prefabs.Length; i++)
                {

                    CLoneTag(i);

                }


            }
        }
    }
    private void CLoneTag(int i)
    {
        Known_Prefabs[i].tag = "Clone";
        Instantiate(Known_Prefabs[i], Known_Prefabs_Target[i].transform.position, Known_Prefabs_Target[i].transform.rotation);
    }


    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(5);
        DoorIsOpen = false;
    }

}
