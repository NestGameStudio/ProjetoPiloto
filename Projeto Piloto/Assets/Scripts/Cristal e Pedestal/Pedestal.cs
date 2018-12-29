using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal: CrystalPedestalMechanic
{
    public GameObject ActionFromObject;

    // Saber se há cristal no pedestal 
    [HideInInspector]
    public bool IsCrystalInPedestal = false;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Transform child in collision.gameObject.GetComponentInChildren<Transform>()) {

            if (collision.gameObject.CompareTag("Physical Body") && this.Type == TipoCristal.Fisico ||
            collision.gameObject.CompareTag("Spirit Body") && this.Type == TipoCristal.Espiritual) {
                if (this.PlayerInventory.CheckIfCrystalAvailable(this.Type)) {
                    Crystal crystalInInventory = PlayerInventory.RetriveCrystalToPedestal(this.Type);

                    IsCrystalInPedestal = true;
                    crystalInInventory.MechanicObject.tag = "Untagged";
                    crystalInInventory.MechanicObject.transform.parent = this.MechanicObject.transform;
                    crystalInInventory.MechanicObject.GetComponent<MeshCollider>().enabled = false;
                    crystalInInventory.MechanicObject.transform.position = this.MechanicObject.transform.position + Vector3.up * 1 / 3 + Vector3.left * 6 / 7;
                    crystalInInventory.MechanicObject.SetActive(true);
                    ActionFromObject.GetComponent<ActionTrigger>().ActionFromPedestal();


                }
            }

        }
            
    }

}
