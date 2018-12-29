using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    private OutOfBodyExperience transition;

    void Start()
    {
        transition = OutOfBodyExperience.getInstance();
    }

    void Update()
    {
        // Mecânica do espirito
        if (Input.GetKeyDown(KeyCode.F)) {
            if (!transition.IsInSpiritState()) {
                transition.ReleaseSpirit();

            } else {

                transition.RetrieveSpirit();
            }
        }
    }
}
