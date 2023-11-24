using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = Gworld.Instance.RemovePatient();
        if (target == null)
            return false;

        resource = Gworld.Instance.RemoveCubicle();
        if (resource != null)
            inventory.AddItem(resource);
        else
        {
            Gworld.Instance.AddPatient(target);
            target = null;
            return false;
        }

        Gworld.Instance.GetWorld().ModifyState("FreeCubicle", -1);
        return true;
    }

    public override bool PostPerform()
    {
        Gworld.Instance.GetWorld().ModifyState("Waiting", -1);
        if (target)
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        return true;
    }
}
