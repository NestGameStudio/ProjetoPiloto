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
        if ((collision.gameObject.CompareTag("Player") && this.Type == TipoCristal.Fisico) || 
            (collision.gameObject.CompareTag("Spirit") && this.Type == TipoCristal.Espiritual)) {

            IsInPlayerInventory = true;
            if (!PlayerInventory.ExceedNumberOfCrystals(Type))
            {
                PlayerInventory.AddCrystalToInventory(this);
                IsInPlayerInventory = true;
                MechanicObject.SetActive(false);
            }

        }
    }
}
