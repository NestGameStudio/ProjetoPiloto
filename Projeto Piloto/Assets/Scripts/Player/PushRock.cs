using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRock : MonoBehaviour
{
    public float pushForce = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = this.transform.TransformDirection(this.GetComponent<Rigidbody>().velocity);


        Vector3 force = pushForce * direction;
        Debug.Log(force);
        collision.collider.attachedRigidbody.AddForce(force);

        /*Rigidbody body = collision.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic) {
            Debug.Log("entrei aqui");
            return; }

        // We dont want to push objects below us 
        Vector3 direction = collision.gameObject.GetComponent<Rigidbody>().velocity;
        if (direction.y < -0.3) {
            Debug.Log("entrei aqui 2");
            return; }

        // Calculate push direction from move direction, 
        // we only push objects to the sides never up and down 
        Vector3 pushDir = new Vector3(direction.x, 0, direction.z);

        // Apply the push 
        body.velocity = pushDir * pushForce;
        //animation.Play("push");

        Debug.Log("gsf");*/
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Nao pode empurrar pedra");
        }
    }

}
