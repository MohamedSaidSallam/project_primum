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

    public void damage(int amount) {
        if (health > 0) {
            health = Mathf.Max(0, health - amount);
            OnhealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public void heal(int amount) {
        if (health < maxHealth) {
            health = Mathf.Min(maxHealth, health + amount);
            OnhealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void damagePercent(float percentage) {
        damage((int)(percentage * health));
    }
    public void healPercent(float percentage) {
        heal((int)(percentage * health));
    }
}
