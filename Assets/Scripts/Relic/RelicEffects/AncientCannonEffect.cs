using UnityEngine;

[CreateAssetMenu(menuName = "Relic/Effects/Ancient Cannon")]
public class AncientCannonEffect : RelicEffect
{
    public float damageBuff;
    public override void OnAcquire(BattleContext context)
    {

    }
    public override void OnBattleStart(BattleContext context)
    {
        context.Owner.stats.projectileDamageMultiplier += damageBuff;
    }

    public override void OnBattleEnd(BattleContext context)
    {
        context.Owner.stats.projectileDamageMultiplier -= damageBuff;
    }
}
