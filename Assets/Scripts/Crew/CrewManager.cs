using UnityEngine;
using System.Collections.Generic;
using System;

public class CrewManager : MonoBehaviour
{
    public event EventHandler<ActiveCrew> OnCrewAdded;
    public event EventHandler<ActiveCrew> OnCrewRemoved;
    public event EventHandler OnCrewCleared;

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

        foreach(ActiveCrew activeCrew in activeCrews)
        {
            if (activeCrew.Data == crewData)
                return;

        }

        ActiveCrew crew = new ActiveCrew(crewData);

        activeCrews.Add(crew);

        ApplyPassive(crew);

        InjectCrewCards(crew);

        OnCrewAdded?.Invoke(this, crew);

        Debug.Log("Recruit: " + crewData.crewName);
    }

    public void RemoveCrew(CrewData crewData)
    {
        foreach(ActiveCrew activeCrew in activeCrews)
        {
            if(activeCrew.Data = crewData)
            {
                activeCrews.Remove(activeCrew);

                DisablePassive(activeCrew);
                RemoveCrewCards(activeCrew);

                OnCrewRemoved?.Invoke(this, activeCrew);
                return;
            }
        }

    }

    void ApplyPassive(ActiveCrew crew)
    {
        if (crew.Data.passive != null)
        {
            crew.Data.passive.Apply(GetComponent<Tank>());
        }
    }

    void DisablePassive(ActiveCrew crew)
    {
        if (crew.Data.passive != null)
        {
            crew.Data.passive.Disable(GetComponent<Tank>());
        }
    }

    void InjectCrewCards(ActiveCrew crew)
    {
        foreach (var card in crew.Data.crewCards)
        {
            RunManager.Instance.CurrentRun.deck.Add(card);
        }
    }

    void RemoveCrewCards(ActiveCrew crew)
    {
        foreach (var card in crew.Data.crewCards)
        {
            RunManager.Instance.CurrentRun.deck.Remove(card);
        }
    }

    public void Clear()
    {
        activeCrews.Clear();

        OnCrewCleared?.Invoke(this, EventArgs.Empty);
    }
}