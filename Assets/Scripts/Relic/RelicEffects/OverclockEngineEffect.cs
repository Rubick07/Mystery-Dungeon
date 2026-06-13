using UnityEngine;

[CreateAssetMenu(menuName = "Relic/Effects/Overclock Engine")]
public class OverclockEngineEffect : RelicEffect
{
    public float overClockBuff;

    public override void OnAcquire(BattleContext context)
    {
    }

    public override void OnBattleStart(BattleContext context)
    {
        context.ProductionSystem.ModifyProductionRate(overClockBuff);
    }

    public override void OnBattleEnd(BattleContext context)
    {
        context.ProductionSystem.ModifyProductionRate(-overClockBuff);
    }

}
