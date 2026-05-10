using UnityEngine;
using System.Collections.Generic;
using System;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    [SerializeField] private List<CardData> startingDeck;

    private List<CardData> cardList;

    private Queue<RuntimeCard> drawPile = new();

    private void Start()
    {
        Initialize(startingDeck);
    }

    public void Initialize(List<CardData> deck)
    {
        List<RuntimeCard> runtimeCards = new();

        cardList = startingDeck;

        foreach (var card in deck)
        {
            runtimeCards.Add(new RuntimeCard(card));
        }

        Shuffle(runtimeCards);

        foreach (var card in runtimeCards)
        {
            drawPile.Enqueue(card);
        }
    }

    public RuntimeCard GetNextCard()
    {
        List<RuntimeCard> runtimeCards = new();


        if (drawPile.Count <= 0)
        {
            foreach (var card in cardList)
            {
                runtimeCards.Add(new RuntimeCard(card));
            }

            Shuffle(runtimeCards);
        }

        foreach (var card in runtimeCards)
        {
            drawPile.Enqueue(card);
        }


        return drawPile.Dequeue();
    }

    void Shuffle(List<RuntimeCard> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, list.Count);

            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

}
