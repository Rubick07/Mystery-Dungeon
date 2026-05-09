using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;

    private Tank owner;

    public void Initialize(Tank tank)
    {
        owner = tank;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        Tank target = other.GetComponent<Tank>();

        if (target != null && target != owner)
        {
            target.TakeDamage(damage);

            Destroy(gameObject);
        }
    }


}
