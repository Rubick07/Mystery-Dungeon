using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    [SerializeField] private CannonSystem cannon;
    [SerializeField] private CardData attackCard;

    [SerializeField] private float interval = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            RuntimeCard card = new RuntimeCard(attackCard);

            cannon.AddCard(card);
        }
    }


}
