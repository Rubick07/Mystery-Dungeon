using UnityEngine;
using System;
using System.Collections.Generic;
public class HandSystem : MonoBehaviour
{
    public static HandSystem instance;

    public event EventHandler<RuntimeCard> OnCardAdded;
    public event EventHandler<RuntimeCard> OnCardRemoved;

    [SerializeField] private int maxHandSize = 5;
    [SerializeField] private Tank playerTank;
    [SerializeField] private CardResolver cardResolver;

    private List<RuntimeCard> hand = new();

    private void Awake()
    {
        instance = this;
    }

    public bool IsHandFull()
    {
        return hand.Count >= maxHandSize;
    }

    public void AddCard(RuntimeCard card)
    {
        hand.Add(card);

        OnCardAdded?.Invoke(this, card);
    }

    public void RemoveCard(RuntimeCard card)
    {
        hand.Remove(card);

        OnCardRemoved?.Invoke(this, card);
    }

    public List<RuntimeCard> GetHand()
    {
        return hand;
    }

    public void PlayCard(RuntimeCard card)
    {
        BattleContext context = new BattleContext
        {
            Owner = playerTank,
        };

        cardResolver.PlayCard(card);

        RemoveCard(card);
    }

}
