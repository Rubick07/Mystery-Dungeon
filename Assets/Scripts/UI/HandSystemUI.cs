using UnityEngine;
using System.Collections.Generic;
public class HandSystemUI : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] private Transform cardUITransformPrefab;
    [SerializeField] private Transform cardContainerTransform;

    private List<CardUI> cardUIList = new();

    private void Start()
    {

        cardContainerTransform.RemoveAllChild();
    }

    private void HandSystem_OnCardUse(object sender, RuntimeCard e)
    {
        cardUIList.RemoveAll(item => item == null);
    }

    private void HandSystem_OnCardDrawn(object sender, RuntimeCard e)
    {
        Transform cardUITransform = Instantiate(cardUITransformPrefab, cardContainerTransform);

        CardUI cardUI = cardUITransform.GetComponent<CardUI>();

        cardUI.Setup(e);

        cardUIList.Add(cardUI);
    }

    private void OnEnable()
    {
        HandSystem.instance.OnCardAdded += HandSystem_OnCardDrawn;
        HandSystem.instance.OnCardRemoved += HandSystem_OnCardUse;
    }


    private void OnDisable()
    {
        HandSystem.instance.OnCardAdded -= HandSystem_OnCardDrawn;
        HandSystem.instance.OnCardRemoved -= HandSystem_OnCardUse;
    }

}
