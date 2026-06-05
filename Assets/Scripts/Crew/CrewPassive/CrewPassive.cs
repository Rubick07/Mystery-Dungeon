using UnityEngine;

public abstract class CrewPassive : ScriptableObject
{
    public abstract void Apply(Tank tank);

    public abstract void Disable(Tank tank);
}
