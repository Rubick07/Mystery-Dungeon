using UnityEngine;

public class ProductionSystem : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandSystem handSystem;

    private RuntimeCard currentProducingCard;

    private float timer;

    private bool isActive = true;

    private void Start()
    {
        BattleManager.instance.OnBattleEnd += BattleManager_OnBattleEnd;
        BattleManager.instance.OnBattleStart += BattleManager_OnBattleStart; ;
    }

    private void BattleManager_OnBattleStart(object sender, System.EventArgs e)
    {
        isActive = true;
    }

    private void BattleManager_OnBattleEnd(object sender, System.EventArgs e)
    {
        isActive = false;
    }

    private void Update()
    {
        if (!isActive)
            return;

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

    private void OnDestroy()
    {
        BattleManager.instance.OnBattleStart -= BattleManager_OnBattleStart; ;
        BattleManager.instance.OnBattleEnd -= BattleManager_OnBattleEnd;
    }

}
