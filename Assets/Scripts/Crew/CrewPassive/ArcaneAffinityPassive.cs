using UnityEngine;

[CreateAssetMenu(menuName = "Crew/Passive/Arcane Affinity")]
public class ArcaneAffinityPassive : CrewPassive
{
    public float magicDamageMultiplier = 0.8f;

    public override void Apply(Tank tank)
    {
        tank.stats.magicDamageMultiplier += magicDamageMultiplier;
    }

    public override void Disable(Tank tank)
    {
        tank.stats.magicDamageMultiplier -= magicDamageMultiplier;
    }
}
