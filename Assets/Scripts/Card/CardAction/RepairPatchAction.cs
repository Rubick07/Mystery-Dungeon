using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Actions/Repair Patch")]
public class RepairPatchAction : CardActions
{
    public int healAmount = 15;

    public override void Activate(BattleContext context)
    {
        context.Owner.Heal(healAmount);

        Debug.Log("Repair Tank");
    }
}
