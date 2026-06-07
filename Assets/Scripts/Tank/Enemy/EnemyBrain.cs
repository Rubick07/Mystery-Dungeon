using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private EnemyController enemy;

    [SerializeField] private List<CardData> cards;

    [SerializeField] private float interval = 3f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            PlayRandomCard();
        }
    }

    void PlayRandomCard()
    {
        CardData card =
            cards[Random.Range(0, cards.Count)];

        enemy.Cannon.AddCard(
            new RuntimeCard(card));
    }
}
