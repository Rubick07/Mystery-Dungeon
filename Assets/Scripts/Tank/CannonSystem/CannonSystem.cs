using System.Collections.Generic;
using UnityEngine;

public class CannonSystem : MonoBehaviour
{
    [SerializeField] private Tank ownerTank;

    [SerializeField] private float reloadTime = 2f;

    private Queue<RuntimeCard> cardQueue = new();

    private bool isReloading;
    private float reloadMultiplier = 1f;

    public void AddCard(RuntimeCard card)
    {
        cardQueue.Enqueue(card);

        TryFire();
    }

    void TryFire()
    {
        if (isReloading)
            return;

        if (cardQueue.Count <= 0)
            return;

        StartCoroutine(ReloadAndFire());
    }

    System.Collections.IEnumerator ReloadAndFire()
    {
        isReloading = true;

        //Debug.Log("Reloading...");

        float finalReload = reloadTime * ownerTank.stats.reloadSpeed * reloadMultiplier;


        yield return new WaitForSeconds(finalReload);

        RuntimeCard card = cardQueue.Dequeue();

        Fire(card);

        isReloading = false;

        TryFire();
    }

    void Fire(RuntimeCard card)
    {
        BattleContext context = new BattleContext
        {
            Owner = ownerTank
        };

        card.Data.action.Activate(context);

        //Debug.Log("FIRE: " + card.Data.cardName);
    }

    public void AddReloadMultiplier(float a)
    {
        reloadMultiplier *= a;
    }

    public void RemoveReloadMultiplier(float a)
    {
        reloadMultiplier /= a;
    }

}
