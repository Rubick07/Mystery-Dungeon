using UnityEngine;

public class CardResolver : MonoBehaviour
{
    [SerializeField] private CannonSystem cannonSystem;

    public void PlayCard(RuntimeCard card)
    {
        switch (card.Data.deliveryMethod)
        {
            case CardDeliveryMethod.Cannon:
                cannonSystem.AddCard(card);
                break;

            case CardDeliveryMethod.Instant:
                ResolveInstant(card);
                break;

            case CardDeliveryMethod.SpawnInsideTank:
                SpawnCrew(card);
                break;
        }
    }

    void ResolveInstant(RuntimeCard card)
    {
        Debug.Log("Instant Card");
    }

    void SpawnCrew(RuntimeCard card)
    {
        Debug.Log("Spawn Crew");
    }
}
