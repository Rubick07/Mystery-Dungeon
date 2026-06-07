using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;
    [SerializeField] private DamageType damageType;

    protected Tank owner;

    public enum DamageType
    {
        Physical,
        Magic
    }

    public void Initialize(Tank tank)
    {
        owner = tank;

        int finalDamage = damage;

        switch (damageType)
        {
            case DamageType.Physical:
                finalDamage = Mathf.RoundToInt(damage * tank.stats.projectileDamageMultiplier);
                break;

            case DamageType.Magic:
                finalDamage = Mathf.RoundToInt(damage * tank.stats.magicDamageMultiplier);
                break;
        }

        this.damage = finalDamage;


        transform.right = owner.gameObject.transform.right;

        BattleManager.instance.OnBattleEnd += BattleManager_OnBattleEnd;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile otherProjectile = other.GetComponent<Projectile>();

        if (otherProjectile != null)
        {
            if (IsSameTank(otherProjectile.owner))
            {
                return;
            }

            Destroy(otherProjectile.gameObject);
            Destroy(gameObject);

            return;
        }

        Tank target = other.GetComponent<Tank>();

        if (target != null && target != owner)
        {
            target.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    public bool IsSameTank(Tank tank)
    {
        return owner == tank;
    }

    private void BattleManager_OnBattleEnd(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }


    private void OnDestroy()
    {
        BattleManager.instance.OnBattleEnd -= BattleManager_OnBattleEnd;
    }


}
