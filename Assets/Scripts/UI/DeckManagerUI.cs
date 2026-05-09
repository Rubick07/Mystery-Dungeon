using UnityEngine;
using System.Collections.Generic;
public class DeckManagerUI : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] private Transform cardUITransformPrefab;
    [SerializeField] private Transform cardContainerTransform;

    private List<CardUI> cardUIList = new();

    private void Start()
    {
        DeckManager.instance.OnCardDrawn += DeckManager_OnCardDrawn;
        DeckManager.instance.OnCardUse += DeckManager_OnCardUse;

        cardContainerTransform.RemoveAllChild();
    }

    private void DeckManager_OnCardUse(object sender, RuntimeCard e)
    {
        cardUIList.RemoveAll(item => item == null);
    }

    private void DeckManager_OnCardDrawn(object sender, RuntimeCard e)
    {
        Transform cardUITransform = Instantiate(cardUITransformPrefab, cardContainerTransform);

        CardUI cardUI = cardUITransform.GetComponent<CardUI>();

        cardUI.Setup(e);

        cardUIList.Add(cardUI);
    }

    

    private void OnDestroy()
    {
        DeckManager.instance.OnCardDrawn -= DeckManager_OnCardDrawn;
    }
}
