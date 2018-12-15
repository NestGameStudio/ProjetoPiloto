using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOpenDoor : ActionTrigger
{
    public override void ActionFromPedestal()
    {
        base.ActionFromPedestal();

        Debug.Log("Abre porta");
    }
}
