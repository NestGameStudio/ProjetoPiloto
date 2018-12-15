using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Uma lista de objetos sob possessão do player
    private List<Crystal> CrystalsInInventory = new List<Crystal>(); 
    
    // Chave e cristal existem tipos (humano ou espirito)
    // Caso o player possua um cristal de tal tipo e encoste em uma chave de mesmo tipo ele trigguera uma ação

    public void AddCrystalToInventory(Crystal crystal)
    {
        CrystalsInInventory.Add(crystal);
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
