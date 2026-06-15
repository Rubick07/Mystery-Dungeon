using UnityEngine;
[CreateAssetMenu(menuName = "Relic/Relic Data")]
public class RelicData : ScriptableObject
{
    public string relicName;

    [TextArea]
    public string description;

    public Sprite icon;

    public RelicEffect effect;
}
