using UnityEngine;

public class RuntimeCard
{
    public CardData Data;

    //public int CurrentCost;

    public RuntimeCard(CardData data)
    {
        Data = data;
        //CurrentCost = data.energyCost;
    }
}