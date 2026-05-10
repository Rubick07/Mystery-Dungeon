using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;

    private Tank owner;

    public void Initialize(Tank tank)
    {
        owner = tank;

        transform.right = owner.gameObject.transform.right;
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


}
