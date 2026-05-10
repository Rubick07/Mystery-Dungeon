using UnityEngine;

public class CardResolver : MonoBehaviour
{
    [SerializeField] private CannonSystem cannonSystem;
    [SerializeField] private CrewManager crewManager;

    public void PlayCard(RuntimeCard card,Tank owner,Tank enemy)
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
                RecruitCrew(card);
                break;
        }
    }

    void ResolveInstant(RuntimeCard card)
    {
        Debug.Log("Instant Card");
    }

    void RecruitCrew(RuntimeCard card)
    {
        CrewCardData crewCard =
            card.Data as CrewCardData;

        if (crewCard == null)
            return;

        crewManager.RecruitCrew(crewCard.crewData);
    }

}
