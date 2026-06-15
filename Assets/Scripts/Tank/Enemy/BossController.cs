using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private Tank tank;

    [SerializeField] private EnemyBrain brain;

    [Header("Phase 2")]
    [SerializeField] private CardData barrageCard;

    [SerializeField] private float phase2AttackInterval = 1f;

    private bool phase2Triggered;

    private void Start()
    {
        tank.OnTankTakeDamage += Tank_OnTankTakeDamage;
    }

    private void Tank_OnTankTakeDamage(object sender, System.EventArgs e)
    {
        CheckPhase2();
    }

    private void CheckPhase2()
    {
        if (phase2Triggered)
            return;

        if (tank.currentHealth <= tank.maxHP * 0.5f)
        {
            phase2Triggered = true;

            EnterPhase2();
        }
    }

    private void EnterPhase2()
    {
        Debug.Log("Boss Phase 2");

        brain.AddCard(barrageCard);

        brain.SetAttackInterval(phase2AttackInterval);

    }
}
