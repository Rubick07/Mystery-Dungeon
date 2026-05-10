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

    private void OnEnable()
    {
        crewManager.OnCrewAdded += CrewManager_OnCrewAdded;
    }
    private void OnDisable()
    {
        crewManager.OnCrewAdded -= CrewManager_OnCrewAdded;
    }
}
