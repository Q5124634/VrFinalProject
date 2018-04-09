using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWVR_SpecialObjectSpawner : RWVR_InteractionObject
{

    public GameObject SetPrefabAk47; // 1
    public List<GameObject> randomPrefabs = new List<GameObject>(); // 2
    private void SpawnObjectInHand(GameObject prefab, RWVR_InteractionController controller) // 1
    {
        GameObject spawnedObject = Instantiate(prefab, controller.snapColliderOrigin.position, controller.transform.rotation); // 2
        controller.SwitchInteractionObjectTo(spawnedObject.GetComponent<RWVR_InteractionObject>()); // 3
        OnTriggerWasReleased(controller); // 4
    }
    public override void OnTriggerWasPressed(RWVR_InteractionController controller) // 1
    {
        base.OnTriggerWasPressed(controller); // 2

        //this is the bool to spawn a specific object if the object in the hand is a specific gun, this will be used to do magazines and other things.
        if (RWVR_ControllerManager.Instance.Gun1)// 3
        {
            SpawnObjectInHand(SetPrefabAk47, controller);
        }
        else
        {
            SpawnObjectInHand(randomPrefabs[UnityEngine.Random.Range(0, randomPrefabs.Count)], controller);
        }
    }
}
