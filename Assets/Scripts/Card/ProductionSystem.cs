using UnityEngine;

public class ProductionSystem : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandSystem handSystem;

    private RuntimeCard currentProducingCard;

    private float timer;

    private void Update()
    {
        ProduceCard();
    }

    void ProduceCard()
    {
        if (handSystem.IsHandFull())
            return;

        if (currentProducingCard == null)
        {
            currentProducingCard = deckManager.GetNextCard();

            timer = 0f;
        }

        if (currentProducingCard == null)
            return;

        timer += Time.deltaTime;

        float productionTime =
            currentProducingCard.Data.productionTime;

        if (timer >= productionTime)
        {
            handSystem.AddCard(currentProducingCard);

            currentProducingCard = null;
        }
    }
}
