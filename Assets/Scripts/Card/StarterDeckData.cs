using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Run/Starter Deck")]
public class StarterDeckData : ScriptableObject
{
    public List<CardData> cards;
}
