using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Cards/Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public CardRarity rarity;
    public CardType cardType; // Bullet, Magic, Crew
    public List<CardTag> tags;

    [TextArea(5,10)]
    public string descText;

    public CardActions action;
}

public enum CardRarity
{
    Common,
    Uncommon,
    Rare,
    Legendary

}

public enum CardType 
{
    Bullet,
    Magic,
    Crew
}

public enum CardTag 
{
    Cannon,
    Magic,
    Crew,
    Shield
}