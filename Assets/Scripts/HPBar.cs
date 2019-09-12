using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    
    [SerializeField ]private Transform localTransform = null;
    private HealthSystem healthSystem = new HealthSystem(100);
  
    public void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            healthSystem.heal(20);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            healthSystem.damage(20);
            CameraShake.isDamaged = true;
        }

        localTransform.localScale = new Vector3(healthSystem.getHealthPercent(), 1);
    }
}
