using UnityEngine;

[CreateAssetMenu(menuName = "Relic/Effects/Arcane Crystal")]
public class ArcaneCrystalEffect : RelicEffect
{
    public float magicDamageBuff;

    public override void OnAcquire(BattleContext context)
    {
    }

    public override void OnBattleStart(BattleContext context)
    {
        context.Owner.stats.magicDamageMultiplier += magicDamageBuff;
    }

    public override void OnBattleEnd(BattleContext context)
    {
        context.Owner.stats.magicDamageMultiplier -= magicDamageBuff;
    }

}
