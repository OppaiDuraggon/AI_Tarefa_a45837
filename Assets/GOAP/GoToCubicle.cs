using UnityEngine;
public class GoToCubicle : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if (target == null) return false;

        return true;
    }

    public override bool PostPerform()
    {
        Gworld.Instance.GetWorld().ModifyState("TreatingPatient", 1);
        Gworld.Instance.AddCubicle(target);
        inventory.RemoveItem(target);
        Gworld.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        return true;
    }
}