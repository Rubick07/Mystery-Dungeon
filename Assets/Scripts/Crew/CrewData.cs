using UnityEngine;

[CreateAssetMenu(menuName = "Crew/Crew Data")]
public class CrewData : ScriptableObject
{
    public string crewName;

    public Sprite portrait;

    [TextArea]
    public string description;

    public CrewTag[] tags;

    public CardData[] crewCards;

    public CrewPassive passive;
}

public enum CrewTag
{
    Engineer,
    Mage,
    Demolition,
    Support,
    Chaos
}