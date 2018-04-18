using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

    Light testLight;

	// Use this for initialization
	void Start ()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
	}
	
    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            testLight.enabled = !testLight.enabled;
        }
    }
}
