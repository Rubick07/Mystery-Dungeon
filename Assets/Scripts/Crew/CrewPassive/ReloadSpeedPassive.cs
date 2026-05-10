using UnityEngine;

[CreateAssetMenu(menuName = "Crew/Passive/Reload Speed")]
public class ReloadSpeedPassive : CrewPassive
{
    public float reloadMultiplier = 0.8f;

    public override void Apply(Tank tank)
    {
        tank.stats.reloadSpeed *= reloadMultiplier;
    }
}
