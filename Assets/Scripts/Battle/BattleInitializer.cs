using UnityEngine;

public class BattleInitializer : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CrewManager crewManager;
    [SerializeField] private Tank playerTank;
    [SerializeField] private EnemySpawner enemySpawner;

    public void Initialize(RunData run, BattleData battleData)
    {
        BuildPLayer(run);

        SpawnEnemy(battleData);
    }

    private void BuildPLayer(RunData run)
    {
        BuildDeck(run);
        BuildTank(run);
        BuildCrews(run);
    }

    void SpawnEnemy(BattleData battle)
    {
        enemySpawner.SpawnEnemy(battle);
    }


    void BuildDeck(RunData run)
    {
        deckManager.Clear();

        deckManager.Initialize(run.deck);
/*        foreach (var card in run.deck)
        {
            deckManager.AddCardToDeck(card);
        }*/
    }

    void BuildTank(RunData run)
    {
        playerTank.Initialized(run.MaxHP);

        playerTank.stats.reloadSpeed *= run.ReloadMultiplier;
    }

    void BuildCrews(RunData run)
    {
        foreach (var crew in run.crews)
        {
            crewManager.RecruitCrew(crew);
        }
    }

}
