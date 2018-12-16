using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private GameObject currentState;

    private OutOfBodyExperience transition;
   

    void Start()
    {
        transition = OutOfBodyExperience.Instance;

        currentState = transition.body;
    }

    void LateUpdate()
    {
        // Movimentação
        var rotation = Input.GetAxis("Horizontal") * Time.deltaTime * currentState.GetComponent<Properties>().RotationVelocity;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * currentState.GetComponent<Properties>().WalkVelocity;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * currentState.GetComponent<Properties>().WalkVelocity;

        // x no x da movimentação, refino

        currentState.transform.Rotate(0, 0, rotation);
        currentState.transform.Translate(0, -y, 0);


        // Mecânica do espírito
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!transition.IsInSpiritState())
            {
                transition.ReleaseSpirit();
                currentState = transition.spirit;

            } else {

                transition.RetrieveSpirit();
                currentState = transition.body;
            }
        }
    }
}
