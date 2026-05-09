using UnityEngine;
[CreateAssetMenu(menuName = "Cards/Actions/Spawn Projectile")]
public class SpawnProjectileAction : CardActions
{
    public Projectile projectilePrefab;

    public override void Activate(BattleContext context)
    {
        Projectile projectile = Instantiate(
            projectilePrefab,
            context.Owner.firePoint.position,
            Quaternion.identity
        );

        projectile.Initialize(context.Owner);
    }

}
