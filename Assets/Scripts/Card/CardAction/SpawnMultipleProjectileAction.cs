using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Actions/Spawn Multiple Projectile")]
public class SpawnMultipleProjectileAction : CardActions
{
    public int spawn; 
    public Projectile projectilePrefab;

    public override void Activate(BattleContext context)
    {
        context.Owner.StartCoroutine(SpawnMultipleObject(context));
    }

    System.Collections.IEnumerator SpawnMultipleObject(BattleContext context)
    {

        for (int i = 0; i < spawn; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, context.Owner.firePoint.position, Quaternion.identity);
            projectile.Initialize(context.Owner);

            yield return new WaitForSeconds(.35f);
        }

    }


}
