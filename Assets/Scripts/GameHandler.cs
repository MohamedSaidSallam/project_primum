using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Transform healthBarPrefab = null;

    public event EventHandler OnClick;
    // Start is called before the first frame update
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        Transform healthBartransform = Instantiate(healthBarPrefab,new Vector3(0,10),Quaternion.identity);
        HPBar healthBar = healthBartransform.GetComponent<HPBar>();
        
    }
}
