using UnityEngine;
using System.Collections.Generic;
using System;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    public event EventHandler<RuntimeCard> OnCardDrawn;
    public event EventHandler<RuntimeCard> OnCardUse;

    public List<CardData> startingDeck;
    [SerializeField] private Tank playerTank;
    [SerializeField] private Tank enemyTank;


    private List<RuntimeCard> drawPile = new();
    private List<RuntimeCard> hand = new();
    private List<RuntimeCard> discardPile = new();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BuildDeck();
        Shuffle(drawPile);

        Draw(5);
    }

    void BuildDeck()
    {
        foreach (var card in startingDeck)
        {
            drawPile.Add(new RuntimeCard(card));
        }
    }

    public void Draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (drawPile.Count == 0)
            {
                Reshuffle();
            }

            if (drawPile.Count == 0)
                return;

            RuntimeCard card = drawPile[0];
            drawPile.RemoveAt(0);

            hand.Add(card);

            OnCardDrawn?.Invoke(this, card);

            Debug.Log("Draw: " + card.Data.cardName);
        }
    }

    void Reshuffle()
    {
        drawPile.AddRange(discardPile);
        discardPile.Clear();

        Shuffle(drawPile);
    }

    void Shuffle(List<RuntimeCard> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, list.Count);

            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

    public void PlayCard(RuntimeCard card)
    {
        BattleContext context = new BattleContext
        {
            Owner = playerTank,
            Enemy = enemyTank
        };

        card.Data.action.Activate(context);

        hand.Remove(card);

        

        discardPile.Add(card);

        OnCardUse?.Invoke(this, card);
    }


}
