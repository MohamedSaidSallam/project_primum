using UnityEngine;
using System;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnhealthChanged;

    [Header("Config")]
    [SerializeField]
    private int maxHealth = 0;
    [SerializeField]
    private int health = 0;
    [SerializeField]
    private bool shakeCamera = false;

    [Header("Ref")]
    [SerializeField]
    private Transform hPBarTransform = null;
    [SerializeField]
    private CameraShake cameraShake = null;

    [Header("Damage Popup")]
    [SerializeField]
    private GameObject dmgPopupPrefab = null;
    [SerializeField]
    private Transform emptyParentTransform = null;
    [SerializeField]
    private Vector3 dmgPopupOffset = Vector3.zero;

    private readonly Quaternion lookAtCameraRotation = new Quaternion(0, 180, 0, 0);

    public int Health { get => health; set => health = value; }
    public float HealthPercent
    {
        get
        {
            return (float)Health / maxHealth;
        }
        private set { }
    }

    private void healthChange()
    {
        hPBarTransform.localScale = new Vector3(HealthPercent, 1);
        OnhealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Damage(int amount)
    {
        if (Health > 0)
        {
            Health = Mathf.Max(0, Health - amount);
            if (shakeCamera) cameraShake.ShakeCamera();
            createDamagePopup(amount, Color.red);
            healthChange();
        }
    }

    public void Heal(int amount)
    {
        if (Health < maxHealth)
        {
            Health = Mathf.Min(maxHealth, Health + amount);
            createDamagePopup(amount, Color.green);
            healthChange();
        }
    }

    public void DamagePercent(float percentage)
    {
        Damage((int)(percentage * Health));
    }

    public void HealPercent(float percentage)
    {
        Heal((int)(percentage * Health));
    }

    private void createDamagePopup(int amount, Color color)
    {
        TextMeshPro textMeshPro = Instantiate(dmgPopupPrefab,
                                               transform.position + dmgPopupOffset,
                                               lookAtCameraRotation,
                                               emptyParentTransform).GetComponent<TextMeshPro>();
        textMeshPro.color = color;
        textMeshPro.text = amount.ToString();
    }
}
