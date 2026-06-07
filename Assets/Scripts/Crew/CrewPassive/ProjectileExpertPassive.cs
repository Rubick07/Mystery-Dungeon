using UnityEngine;

[CreateAssetMenu(menuName = "Crew/Passive/Projectile Expert")]
public class ProjectileExpertPassive : CrewPassive
{
    public float projectileDamageMultiplier = 0.25f;

    public override void Apply(Tank tank)
    {
        tank.stats.projectileDamageMultiplier += projectileDamageMultiplier;
    }

    public override void Disable(Tank tank)
    {
        tank.stats.projectileDamageMultiplier -= projectileDamageMultiplier;
    }
}
