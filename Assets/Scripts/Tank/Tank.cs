using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform firePoint;

    public int hp = 100;

    public TankStats stats = new();

    public CannonSystem cannonSystem;
    public CrewManager crewManager;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        Debug.Log(name + " kena damage " + damage);
    }
}
