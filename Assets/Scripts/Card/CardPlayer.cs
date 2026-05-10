using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    [SerializeField] private HandSystem handSystem;
    [SerializeField] private CardResolver cardResolver;

    [SerializeField] private Tank playerTank;
    [SerializeField] private Tank enemyTank;

    public void PlayCard(RuntimeCard card)
    {
        if (card == null)
            return;

        cardResolver.PlayCard(
            card,
            playerTank,
            enemyTank
        );

        handSystem.RemoveCard(card);
    }
}
