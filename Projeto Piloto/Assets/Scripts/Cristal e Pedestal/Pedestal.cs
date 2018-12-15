﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal: CrystalPedestalMechanic
{
    public GameObject ActionfromObject;

    // Saber se há cristal no pedestal 
    [HideInInspector]
    public bool IsCrystalInPedestal = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.Type == TipoCristal.Fisico ||
            collision.gameObject.CompareTag("Spirit") && this.Type == TipoCristal.Espiritual)
        {
            if (this.PlayerInventory.CheckIfCrystalAvailable(this.Type))
            {
                Crystal crystalInInventory = PlayerInventory.RetriveCrystalToPedestal(this.Type);

                IsCrystalInPedestal = true;
                crystalInInventory.MechanicObject.tag = "Untagged";
                crystalInInventory.MechanicObject.transform.parent = this.MechanicObject.transform;
                crystalInInventory.MechanicObject.GetComponent<MeshCollider>().enabled = false;
                crystalInInventory.MechanicObject.transform.position = this.MechanicObject.transform.position + Vector3.up*1/3 + Vector3.left* 6/7;
                crystalInInventory.MechanicObject.SetActive(true);
                ActionfromObject.GetComponent<ActionTrigger>().ActionFromPedestal();


            }
        }
    }

}
