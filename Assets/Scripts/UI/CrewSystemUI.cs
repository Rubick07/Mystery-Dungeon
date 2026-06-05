using UnityEngine;
using System.Collections.Generic;

public class CrewSystemUI : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] private CrewManager crewManager;
    [SerializeField] private Transform crewUITransformPrefab;
    [SerializeField] private Transform crewContainerTransform;

    private List<CrewUI> crewUIList = new();

    private void Start()
    {
        crewContainerTransform.RemoveAllChild();
    }

    private void CrewManager_OnCrewAdded(object sender, ActiveCrew e)
    {
        Transform crewUITransform = Instantiate(crewUITransformPrefab, crewContainerTransform);

        CrewUI crewUI = crewUITransform.GetComponent<CrewUI>();

        crewUI.Setup(e);

        crewUIList.Add(crewUI);
    }
    private void CrewManager_OnCrewRemoved(object sender, ActiveCrew e)
    {
        foreach(CrewUI crewUI in crewUIList)
        {
            if(crewUI.GetActiveCrew() == e)
            {
                crewUIList.Remove(crewUI);
                Destroy(crewUI.gameObject);
                return;
            }
        }
    }
    private void CrewManager_OnCrewCleared(object sender, System.EventArgs e)
    {
        crewUIList.RemoveAll(item => item == null);

        for (int i = crewUIList.Count - 1; i >= 0; i--)
        {
            Destroy(crewUIList[i].gameObject);
        }

        crewUIList.Clear();
    }

    private void OnEnable()
    {
        crewManager.OnCrewAdded += CrewManager_OnCrewAdded;
        crewManager.OnCrewRemoved += CrewManager_OnCrewRemoved;
        crewManager.OnCrewCleared += CrewManager_OnCrewCleared; ;
        
    }

    private void OnDisable()
    {
        crewManager.OnCrewAdded -= CrewManager_OnCrewAdded;
        crewManager.OnCrewRemoved -= CrewManager_OnCrewRemoved;
        crewManager.OnCrewCleared -= CrewManager_OnCrewCleared; ;

    }
}
