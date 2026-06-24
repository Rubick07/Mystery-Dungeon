using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Splines;
using DG.Tweening;
public class HandSystemUI : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] private Transform cardUITransformPrefab;
    [SerializeField] private Transform cardContainerTransform;

    private List<CardUI> cardUIList = new();

    //cardUI spline
    [SerializeField] private Transform cardSpawnPoint;
    private Spline handSpline;

    private void Start()
    {
        cardContainerTransform.RemoveAllChild();

        handSpline = cardContainerTransform.GetComponent<SplineContainer>().Spline;
        HandSystem.instance.OnCardCleared += HandSystem_OnCardCleared;
    }

    private void HandSystem_OnCardCleared(object sender, System.EventArgs e)
    {
        cardUIList.RemoveAll(item => item == null);

        for (int i = cardUIList.Count - 1; i >= 0; i--)
        {
            Destroy(cardUIList[i].gameObject);
        }

        cardUIList.Clear();
    }

    private void HandSystem_OnCardUse(object sender, RuntimeCard e)
    {
        cardUIList.RemoveAll(item => item == null);
    }

    private void HandSystem_OnCardDrawn(object sender, RuntimeCard e)
    {
        Transform cardUITransform = Instantiate(cardUITransformPrefab, cardContainerTransform);

        cardUITransform.position = cardSpawnPoint.position;
        cardUITransform.rotation = cardSpawnPoint.rotation;

        CardUI cardUI = cardUITransform.GetComponent<CardUI>();

        cardUI.Setup(e);

        cardUIList.Add(cardUI);

        UpdateCardPositions();
    }
    //CardUI spline
    private void UpdateCardPositions()
    {
        if (handSpline == null || cardUIList.Count == 0)
            return;

        float cardSpacing = 1f / cardUIList.Count / 1.5f;
        float firstCardPosition = 0.5f - (cardSpacing * (cardUIList.Count - 1) / 2f);
        for (int i = 0; i < cardUIList.Count; i++)
        {
            float t = firstCardPosition + (i * cardSpacing);
            Vector3 splinePosition = handSpline.EvaluatePosition(t);
            Vector3 forward = handSpline.EvaluateTangent(t);
            Vector3 up = handSpline.EvaluateUpVector(t);
            Quaternion rotation = Quaternion.LookRotation(new Vector3(up.x, 0, up.z), new Vector3(0,180,0));
            cardUIList[i].transform.DOMove(splinePosition, 0.25f);
            cardUIList[i].transform.DORotateQuaternion(rotation, 0.25f);
        }
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
