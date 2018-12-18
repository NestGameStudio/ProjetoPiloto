using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Uma lista de objetos sob possessão do player
    private List<Crystal> CrystalsInInventory = new List<Crystal>();

    private OutOfBodyExperience transition;

    // Chave e cristal existem tipos (humano ou espirito)
    // Caso o player possua um cristal de tal tipo e encoste em uma chave de mesmo tipo ele trigguera uma ação

    private void Start()
    {
        transition = OutOfBodyExperience.getInstance();
    }

    public bool CheckIfCrystalAvailable(TipoCristal type)
    {
        foreach (Crystal crystal in CrystalsInInventory)
        {
            if (crystal.Type == type)
            {
                return true;
            }
        }
        return false;
    }

    public Crystal RetriveCrystalToPedestal(TipoCristal type)
    {
        foreach (Crystal crystal in CrystalsInInventory)
        {
            if(crystal.Type == type)
            {
                CrystalsInInventory.Remove(crystal);

                if (crystal.Type == TipoCristal.Fisico)
                {
                    transition.body.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(false);
                }
                else if (crystal.Type == TipoCristal.Espiritual)
                {
                    transition.spirit.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(false);
                }

                return crystal;
            }
        }
        return null;
    }

    public void AddCrystalToInventory(Crystal crystal)
    {
        CrystalsInInventory.Add(crystal);

        if (crystal.Type == TipoCristal.Fisico && CheckIfCrystalAvailable(TipoCristal.Fisico))
        {
            transition.body.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(true);
        } else if (crystal.Type == TipoCristal.Espiritual && CheckIfCrystalAvailable(TipoCristal.Espiritual))
        {
            transition.spirit.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(true);
        }


        // se o objeto for espiritual, retira-o da lista de objetos espirituais do OutOfBodyExperience
        if (crystal.Type == TipoCristal.Espiritual)
        {
            transition.EspiritualObjects.Remove(crystal.MechanicObject);
        }
    }

    // Não pode haver mais de um cristal de cada tipo na possessão no player
    public bool ExceedNumberOfCrystals(TipoCristal type)
    {
        foreach(Crystal crystal in CrystalsInInventory)
        {
            if (crystal.Type == type)
            {
                return true;
            }
        }

        return false;
    }
}
