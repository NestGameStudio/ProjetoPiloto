using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal: CrystalPedestalMechanic
{
    // Saber se está sob possesão do player 
    [HideInInspector]
    public bool IsInPlayerInventory = false;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Transform child in collision.gameObject.GetComponentInChildren<Transform>()) {

            if ((child.gameObject.CompareTag("Physical Body") && this.Type == TipoCristal.Fisico) ||
            (child.gameObject.CompareTag("Spirit Body") && this.Type == TipoCristal.Espiritual)) {

                if (!PlayerInventory.ExceedNumberOfCrystals(Type)) {
                    PlayerInventory.AddCrystalToInventory(this);
                    IsInPlayerInventory = true;
                    MechanicObject.SetActive(false);
                }

            }

        }
      
    }
}
