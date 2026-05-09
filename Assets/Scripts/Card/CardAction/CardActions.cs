using UnityEngine;

public abstract class CardActions : ScriptableObject
{
    public abstract void Activate(BattleContext context);
}
