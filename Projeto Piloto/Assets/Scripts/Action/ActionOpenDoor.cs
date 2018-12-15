using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOpenDoor : ActionTrigger
{
    public override void ActionFromPedestal()
    {
        base.ActionFromPedestal();
        this.gameObject.SetActive(false);

        Debug.Log("Abre porta");
    }
}
