using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoCristal { Espiritual, Fisico };

public class CrystalPedestalMechanic : MonoBehaviour
{
    public TipoCristal Type = TipoCristal.Fisico;

    [HideInInspector]
    public GameObject MechanicObject;
    [HideInInspector]
    public Inventory PlayerInventory;

    void Start()
    {
        MechanicObject = this.gameObject;
        PlayerInventory = GameObject.Find("MainScripts").GetComponent<Inventory>();
    }

}
