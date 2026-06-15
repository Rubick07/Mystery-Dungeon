using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelectEffectsHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float verticalMoveAmount = 5f;
    [SerializeField] private float moveTime = 0.1f;
    [Range(0f, 2f), SerializeField] private float scaleAmount = 1.2f;

    private Vector3 originalPosition;
    private Vector3 originalScale;

    private void Start()
    {
        originalPosition = transform.localPosition;
        originalScale = transform.localScale;

    }
    private IEnumerator MoveCard(bool startingAnimation)
    {
        Vector3 endPos;
        Vector3 endScale;

        float elapsedTime = 0f;
        while(elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            if (startingAnimation)
            {
                endPos = originalPosition + new Vector3(0f, verticalMoveAmount, 0f);
                endScale = originalScale * scaleAmount;
            }
            else
            {
                endPos = originalPosition;
                endScale = originalScale;
            }
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, elapsedTime / moveTime);
            transform.localScale = Vector3.Lerp(transform.localScale, endScale, elapsedTime / moveTime);

            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(MoveCard(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(MoveCard(false));
    }
}
