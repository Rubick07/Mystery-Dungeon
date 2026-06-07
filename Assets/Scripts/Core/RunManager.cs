using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    [SerializeField] private TankData tankData;
    [SerializeField] private List<BattleData> battles;
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
            if(card.cardType == CardType.Crew)
            {
                CrewCardData crewCard = card as CrewCardData;

                if (crewCard == null)
                    return;

                CurrentRun.crews.Add(crewCard.crewData);

                continue;
            }
            CurrentRun.deck.Add(card);
        }

        BattleManager.instance.StartBattle();
        //LoadBattle();
    }

    public void GoToNextBattle()
    {
        CurrentRun.currentBattle++;

        BattleManager.instance.StartBattle();
    }

    void LoadBattle(int battleIndex)
    {
        Debug.Log($"Loading Battle {battleIndex}");
    }

    public BattleData GetCurrentBattle()
    {
        return battles[CurrentRun.currentBattle];
    }
}
