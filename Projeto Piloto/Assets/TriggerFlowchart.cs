using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlowchart : MonoBehaviour
{
    public GameObject flowchart2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            flowchart2.SetActive(true);
        }
    }
}

