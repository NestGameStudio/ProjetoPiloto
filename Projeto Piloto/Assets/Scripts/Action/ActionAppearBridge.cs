using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAppearBridge : ActionTrigger
{
    public override void ActionFromPedestal()
    {
        base.ActionFromPedestal();

        Debug.Log("Aparece ponte");
    }
}
