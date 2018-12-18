using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOpenDoor : ActionTrigger
{
    public Animator Door;
    public override void ActionFromPedestal()
    {
        base.ActionFromPedestal();
        //this.gameObject.SetActive(false);

        Door.Play("Porta Abrindo");

        Debug.Log("Abre porta");
    }
}
