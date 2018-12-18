using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOpenDoor : ActionTrigger
{
    public Animator Door;
    public override void ActionFromPedestal()
    {
        base.ActionFromPedestal();
        Door.Play("Porta Abrindo");
    }
}
