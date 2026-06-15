using UnityEngine;

public abstract class RelicEffect : ScriptableObject
{
    public abstract void OnAcquire(BattleContext context);

    public virtual void OnBattleStart(BattleContext context) { }

    public virtual void OnBattleEnd(BattleContext context) { }
}
