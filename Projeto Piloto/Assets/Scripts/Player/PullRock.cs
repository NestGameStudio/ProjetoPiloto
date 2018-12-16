using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRock : MonoBehaviour
{
    public float pushForce = 2.0f;

    // dar um jeito de verificar se o jogador está fazendo força contra a pedra


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            // collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce);
            //Vector3 pushDir = Vector3(collision.moveDirection.x, 0, collision.moveDirection.z);

            //collision.velocity = pushDir * pushPower;

            collision.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.GetComponent<Rigidbody>().velocity;

            Debug.Log("Posso empurrar pedra");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Nao pode empurrar pedra");
        }
    }

}
