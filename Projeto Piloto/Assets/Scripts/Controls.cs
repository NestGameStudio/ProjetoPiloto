using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls: MonoBehaviour
{
    private GameObject currentState;

    private OutOfBodyExperience transition;

    private bool left = true;
    private bool right = true;
    private bool up = true;
    private bool down = true;

    private float currentTime = 0;

    void Start()
    {
        transition = OutOfBodyExperience.Instance;

        currentState = transition.body;

    }

    void FixedUpdate()
    {
        // Movimentação
        float rotation = Time.deltaTime * currentState.GetComponent<Properties>().RotationVelocity;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * currentState.GetComponent<Properties>().WalkVelocity;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * currentState.GetComponent<Properties>().WalkVelocity;

        Quaternion direction = Quaternion.Euler(0, 0, 0);
        float translation = 0;

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {

            if (Input.GetAxis("Horizontal") > 0)
            {   // Right

                // Orienta a rotação para a direção certa
                if (left)
                {
                    currentTime = 0;
                    left = false;
                    right = true;
                }

                direction = Quaternion.Euler(-90, 0, 270);
                translation = -x;

            } else if (Input.GetAxis("Horizontal") < 0)
            {   // Left

                // Orienta a rotação para a direção certa
                if (right)
                {
                    currentTime = 0;
                    left = true;
                    right = false;
                }

                direction = Quaternion.Euler(-90, 0, 90);
                translation = x;
            }

            if (Input.GetAxis("Vertical") > 0)
            {    // Up

                // Orienta a rotação para a direção certa
                if (down)
                {
                    currentTime = 0;
                    up = true;
                    down = false;
                }

                direction = Quaternion.Euler(-90, 0, 180);
                translation = -y;

            } else if (Input.GetAxis("Vertical") < 0)
            {     // Down

                // Orienta a rotação para a direção certa
                if (up)
                {
                    currentTime = 0;
                    up = false;
                    down = true;
                }

                direction = Quaternion.Euler(-90, 0, 0);
                translation = y;
            }

            if (direction != Quaternion.Euler(0, 0, 0))
            {
                // Rotaciona até o limite do eixo
                if (currentTime < 1)
                    currentTime += Time.deltaTime;

                //currentState.transform.Rotate(direction.ToEuler(), Space.Self);
                currentState.transform.rotation = Quaternion.SlerpUnclamped(currentState.transform.rotation, direction, currentTime);

                // Faz a translação do personagem
                if (currentState.transform.rotation.z - direction.z <= 1)
                {
                    currentState.transform.Translate(0, translation, 0);
                    //Debug.Log("Inicia movimentação");
                }
            }

            /*float diff = player.transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y;
            float dergee = 1;
            if (Mathf.Abs(diff) <= dergee) { Debug.Log("ready"); }*/
        }

        // Mecânica do espirito
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!transition.IsInSpiritState())
            {
                transition.ReleaseSpirit();
                currentState = transition.spirit;

            } else
            {

                transition.RetrieveSpirit();
                currentState = transition.body;
            }
        }
    }
}

