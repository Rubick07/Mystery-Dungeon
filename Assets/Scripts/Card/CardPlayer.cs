using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    [SerializeField] private HandSystem handSystem;
    [SerializeField] private CardResolver cardResolver;

    [SerializeField] private Tank playerTank;
    [SerializeField] private Tank enemyTank;

    private void Awake()
    {
        EnemySpawner.OnNewEnemySpawn += EnemySpawner_OnNewEnemySpawn;
    }

    private void EnemySpawner_OnNewEnemySpawn(object sender, Tank e)
    {
        enemyTank = e;
    }

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

    private void OnDestroy()
    {
        EnemySpawner.OnNewEnemySpawn -= EnemySpawner_OnNewEnemySpawn;
    }
}
