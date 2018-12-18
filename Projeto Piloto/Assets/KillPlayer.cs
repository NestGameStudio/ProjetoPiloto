using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Vector3 SpawnPoint = new Vector3(73.77f, 5.770084f, -719.23f);
    public OutOfBodyExperience transition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spirit"))
        {
            transition.RetrieveSpirit();
            Debug.Log("Espirito Morreu");
        }
        else if (other.CompareTag("Player"))
        {
            other.transform.position = SpawnPoint;
            Debug.Log("Player Morreu");
        }

    }
}
