using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class RunData
{
    public List<CardData> deck = new();

    public List<CrewData> crews = new();

    public int currentBattle;
    
    public int MaxHP = 100;

    public float ReloadMultiplier = 1f;
}
