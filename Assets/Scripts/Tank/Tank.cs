using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform firePoint;

    public int hp = 100;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        Debug.Log(name + " kena damage " + damage);
    }
}
