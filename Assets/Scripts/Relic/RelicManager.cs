using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    private readonly List<RelicData> activeRelics = new();

    private void Start()
    {
        BattleManager.instance.OnBattleEnd += BattleManager_OnBattleEnd;
    }

    private void BattleManager_OnBattleEnd(object sender, System.EventArgs e)
    {
        TriggerBattleEnd(BattleInitializer.instance.GetBattleContext());
    }

    public void Initialize(List<RelicData> relics)
    {
        activeRelics.Clear();

        activeRelics.AddRange(relics);
    }

    public void TriggerBattleStart(BattleContext context)
    {
        foreach (var relic in activeRelics)
        {
            Debug.Log("APPLY: " + relic.relicName);
            relic.effect.OnBattleStart(context);
        }
    }

    public void TriggerBattleEnd(BattleContext context)
    {
        foreach (var relic in activeRelics)
        {
            Debug.Log("Disable: " + relic.relicName);
            relic.effect.OnBattleEnd(context);
        }
    }
}
