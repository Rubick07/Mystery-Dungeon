using UnityEngine;
using System;


public class Tank : MonoBehaviour
{

    public static event EventHandler OnAnyPlayerTankTakeDamage;

    public event EventHandler OnTankTakeDamage;
    public event EventHandler OnTankTakeHeal;
    public event EventHandler OnTankHpChanged;

    public Transform firePoint;

    public int currentHealth = 100;

    public TankStats stats = new();


    public CannonSystem cannonSystem;
    public CrewManager crewManager;

    public bool isEnemy;

    private int maxHP;
    private int lastDamageValue;


    private void Awake()
    {
        maxHP = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        ModifyHealth(-damage);

        lastDamageValue = damage;

        OnTankTakeDamage?.Invoke(this, EventArgs.Empty);
        Debug.Log(name + " kena damage " + damage);

        if (!isEnemy)
        {
            OnAnyPlayerTankTakeDamage?.Invoke(this, EventArgs.Empty);
        }

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

    public int GetLastDamageValue()
    {
        return lastDamageValue;
    }


    public int GetMaxHP() => maxHP;
}
