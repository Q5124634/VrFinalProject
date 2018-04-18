﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightAndSiren : MonoBehaviour
{
    public GameObject[] EnemiesArray;
    public AudioClip WindDown;
    public AudioSource myAudioSource;
    bool EnemiesAlive = true;

    private void Start()
    {


    }

    void FixedUpdate()
    {
        EnemiesAlive = false;

        for (int i = 0; i < EnemiesArray.Length; i++)
        {
            if (EnemiesArray[i] != null)
            {
                EnemiesAlive = true;

            }
        }

        if (EnemiesAlive == false)
        {
            myAudioSource.PlayOneShot(WindDown);
            GetComponent<ScoreSystem>().TotalScore += 100;
            Destroy(gameObject);
        }
    }
}
