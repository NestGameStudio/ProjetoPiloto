using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Controls : MonoBehaviour {     private GameObject currentState;      private OutOfBodyExperience transition;      private bool left = true;     private bool right = true;     private bool up = true;     private bool down = true;      private float currentTime = 0;

    void Start()     {         transition = OutOfBodyExperience.Instance;          currentState = transition.body;         
    }

void LateUpdate()     {         // Movimentação         var rotation = Time.deltaTime * currentState.GetComponent<Properties>().RotationVelocity;         var x = Input.GetAxis("Horizontal") * Time.deltaTime * currentState.GetComponent<Properties>().WalkVelocity;         var y = Input.GetAxis("Vertical") * Time.deltaTime * currentState.GetComponent<Properties>().WalkVelocity;          if (Input.GetAxis("Horizontal") > 0)         { 

            if (left)
            {
                currentTime = 0;                 left = false;
                right = true;
            }
             if (currentTime < 1)                 currentTime += Time.deltaTime; 
            currentState.transform.rotation = Quaternion.SlerpUnclamped(currentState.transform.rotation, Quaternion.Euler(-90, 0, 270), currentTime);             currentState.transform.Translate(0, -x, 0);              //Debug.Log("RIGHT");         }         else if (Input.GetAxis("Horizontal") < 0)         {             if (right)             {                 currentTime = 0;                 left = true;                 right = false;             }

            if (currentTime < 1)                 currentTime += Time.deltaTime;              //targetAngle = targetAngle - 90;              currentState.transform.rotation = Quaternion.SlerpUnclamped(currentState.transform.rotation, Quaternion.Euler(-90, 0, 90), currentTime);             currentState.transform.Translate(0, x, 0);             //currentState.transform.Rotate(new Vector3(0,0,90) * Time.deltaTime);              //float angle = Mathf.LerpAngle(90, 0, (Time.time - startTime) / 2);
            //currentState.transform.eulerAngles = new Vector3(-90, 0, angle);             //Debug.Log("LEFT");         }

        if (Input.GetAxis("Vertical") > 0)         {             if (down)             {                 currentTime = 0;                 up = true;                 down = false;             }              if (currentTime < 1)                 currentTime += Time.deltaTime;               currentState.transform.rotation = Quaternion.SlerpUnclamped(currentState.transform.rotation, Quaternion.Euler(-90, 0, 180), currentTime);             currentState.transform.Translate(0, -y, 0);              //Debug.Log("UP");         }         else if (Input.GetAxis("Vertical") < 0)         {
            if (up)             {                 currentTime = 0;                 up = false;                 down = true;             }              if (currentTime < 1)                 currentTime += Time.deltaTime;              currentState.transform.rotation = Quaternion.SlerpUnclamped(currentState.transform.rotation, Quaternion.Euler(-90, 0, 0), currentTime);             currentState.transform.Translate(0, y, 0);              //Debug.Log("DOWN");         }          // Mecânica do espirito         if (Input.GetKeyDown(KeyCode.F))         {             if(!transition.IsInSpiritState())             {                 transition.ReleaseSpirit();                 currentState = transition.spirit;              } else {                  transition.RetrieveSpirit();                 currentState = transition.body;             }         }     } }  