using UnityEngine;

public class BattleInitializer : MonoBehaviour
{
    public static BattleInitializer instance;

    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CrewManager crewManager;
    [SerializeField] private ProductionSystem productionSystem;
    [SerializeField] private Tank playerTank;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private RelicManager relicManager;

    private void Awake()
    {
        instance = this;
    }

    public void Initialize(RunData run, BattleData battleData)
    {
        BuildPLayer(run);
        SpawnEnemy(battleData);


        BattleContext playerContext = new BattleContext()
        {
            Owner = playerTank,
            Enemy = enemySpawner.GetCurrentEnemyTank(),
            ProductionSystem = productionSystem,

            CrewManager = crewManager,
            RelicManager = relicManager
        };

        relicManager.Initialize(run.relics);
        relicManager.TriggerBattleStart(playerContext);
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

    public BattleContext GetBattleContext()
    {
        BattleContext playerContext = new BattleContext()
        {
            Owner = playerTank,
            Enemy = enemySpawner.GetCurrentEnemyTank(),

            ProductionSystem = productionSystem,

            CrewManager = crewManager,
            RelicManager = relicManager
        };

        return playerContext;
    }

}
