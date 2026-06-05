using UnityEngine;

public class BattleInitializer : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private CrewManager crewManager;
    [SerializeField] private Tank playerTank;

    private void Start()
    {
        Initialize(RunManager.Instance.CurrentRun);
    }

    public void Initialize(RunData run)
    {
        BuildDeck(run);

        BuildTank(run);

        BuildCrews(run);
    }

    void BuildDeck(RunData run)
    {
        deckManager.Clear();

        foreach (var card in run.deck)
        {
            deckManager.AddCardToDeck(card);
        }
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
