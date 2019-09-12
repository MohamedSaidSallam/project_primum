using UnityEngine;
using System;

public class HealthSystem
{
    private int maxHealth;
    private int health;
    public event EventHandler OnhealthChanged;
    public HealthSystem(int MaxHP) {
        maxHealth = MaxHP;
        health = MaxHP;
;
    }

    public int getHealth() {
        return health;
    }
    public float getHealthPercent() {
        return (float)health / maxHealth;
    }

    public void damage(int amount,Vector3 objectLocation) {
        if (health > 0) {
            health = Mathf.Max(0, health - amount);
            OnhealthChanged?.Invoke(this, EventArgs.Empty);
            if(objectLocation != null) {
                DamagePopup.Create(objectLocation, amount);
            }
        }
    }
    public void heal(int amount) {
        if (health < maxHealth) {
            health = Mathf.Min(maxHealth, health + amount);
            OnhealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void damagePercent(float percentage,Vector3 location) {
        damage((int)(percentage * health),location);
    }
    public void healPercent(float percentage) {
        heal((int)(percentage * health));
    }
}
