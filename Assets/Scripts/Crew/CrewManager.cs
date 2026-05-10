using UnityEngine;
using System.Collections.Generic;
using System;

public class CrewManager : MonoBehaviour
{
    public event EventHandler<ActiveCrew> OnCrewAdded;

    [SerializeField] private DeckManager deckSystem;

    [SerializeField] private int maxCrew = 3;

    private List<ActiveCrew> activeCrews = new();

    public bool IsCrewFull()
    {
        return activeCrews.Count >= maxCrew;
    }

    public void RecruitCrew(CrewData crewData)
    {
        if (IsCrewFull())
        {
            Debug.Log("Crew Full");
            return;
        }

        ActiveCrew crew = new ActiveCrew(crewData);

        activeCrews.Add(crew);

        ApplyPassive(crew);

        InjectCrewCards(crew);

        OnCrewAdded?.Invoke(this, crew);

        Debug.Log("Recruit: " + crewData.crewName);
    }

    void ApplyPassive(ActiveCrew crew)
    {
        if (crew.Data.passive != null)
        {
            crew.Data.passive.Apply(GetComponent<Tank>());
        }
    }

    void InjectCrewCards(ActiveCrew crew)
    {
        foreach (var card in crew.Data.crewCards)
        {
            deckSystem.AddCardToDeck(card);
        }
    }
}