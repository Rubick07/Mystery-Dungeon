using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Actions/Emergency Reload")]
public class EmergencyReloadAction : CardActions
{
    public float reloadBoost = 0.5f;

    public float duration = 5f;

    public override void Activate(BattleContext context)
    {
        context.Owner.StartCoroutine(
            ApplyReloadBoost(context)
        );
    }

    System.Collections.IEnumerator ApplyReloadBoost(
        BattleContext context)
    {
        CannonSystem cannon =
            context.Owner.cannonSystem;

        cannon.AddReloadMultiplier(reloadBoost);

        yield return new WaitForSeconds(duration);

        cannon.RemoveReloadMultiplier(reloadBoost);
    }
}
