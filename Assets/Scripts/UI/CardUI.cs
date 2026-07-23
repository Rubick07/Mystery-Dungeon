using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Image spriteImage;
    [SerializeField] private Button button;

    private RuntimeCard runtimeCard;
    public void Setup(RuntimeCard runtimeCard)
    {
        spriteImage.sprite = runtimeCard.Data.artwork;

        this.runtimeCard = runtimeCard;

    }

    public RuntimeCard GetRuntime() => runtimeCard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CardPlayCollider"))
        {
            Destroy(gameObject);

            HandSystem.instance.GetCardPlayer().PlayCard(runtimeCard);
        }
    }
}
