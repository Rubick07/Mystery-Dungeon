using UnityEngine;
using System;


public class Tank : MonoBehaviour
{
    public event EventHandler OnTankTakeDamage;
    public event EventHandler OnTankTakeHeal;
    public event EventHandler OnTankHpChanged;

    public Transform firePoint;

    public int currentHealth = 100;

    public TankStats stats = new();


    public CannonSystem cannonSystem;
    public CrewManager crewManager;

    private int maxHP;

    private void Awake()
    {
        maxHP = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        ModifyHealth(-damage);

        OnTankTakeDamage?.Invoke(this, EventArgs.Empty);
        Debug.Log(name + " kena damage " + damage);
    }

    public void Heal(int amount)
    {
        ModifyHealth(amount);

        OnTankTakeHeal?.Invoke(this, EventArgs.Empty);
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHP);

        OnTankHpChanged?.Invoke(this, EventArgs.Empty);
    }
    public float GetHealthNormalized()
    {
        return (float)currentHealth / maxHP;
    }

    public int GetMaxHP() => maxHP;
}
