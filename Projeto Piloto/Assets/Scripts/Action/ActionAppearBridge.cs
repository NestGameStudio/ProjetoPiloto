using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAppearBridge : ActionTrigger
{
    public override void ActionFromPedestal()
    {
        base.ActionFromPedestal();

        this.gameObject.SetActive(true);
        Debug.Log("Aparece ponte");
    }
}
