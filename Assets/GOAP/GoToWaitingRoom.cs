using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        Gworld.Instance.GetWorld().ModifyState("Waiting", 1);
        Gworld.Instance.AddPatient(this.gameObject);
        beliefs.ModifyState("atHospital", 1);
        return true;
    }
}
