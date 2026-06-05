using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    [SerializeField] private TankData tankData;
    [SerializeField] private int currentBattleIndex = 0;

    public RunData CurrentRun { get; private set; }

    private void Awake()
    {
        Instance = this;

        StartRun();
    }

    public void StartRun()
    {
        CurrentRun = new RunData();

        CurrentRun.MaxHP = tankData.baseHP;

        foreach (var card in tankData.starterDeck.cards)
        {
            CurrentRun.deck.Add(card);
        }

        //LoadBattle();
    }

    public void GoToNextBattle()
    {
        currentBattleIndex++;

        LoadBattle(currentBattleIndex);
    }

    void LoadBattle(int battleIndex)
    {
        Debug.Log($"Loading Battle {battleIndex}");
    }
}
