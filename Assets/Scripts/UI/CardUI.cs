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

        button.onClick.AddListener( () => 
        {
            Destroy(gameObject);
            DeckManager.instance.PlayCard(runtimeCard);

        });
    }

    public RuntimeCard GetRuntime() => runtimeCard; 


}
