using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour {

    public static DamagePopup Create(Vector3 position, int damageAmount) {
        Transform damagePopupTransform = Instantiate(GameAssets.i.DamagePopupPf, position, new Quaternion(0, 180, 0, 0));
        DamagePopup dmagepopup = damagePopupTransform.GetComponent<DamagePopup>();
        dmagepopup.Setup(damageAmount);
        return dmagepopup;
    }

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake() {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damage) {
        textMesh.SetText(damage.ToString());
        textColor = textMesh.color;
        disappearTimer = 0.8f;
    }
    private void Update() {
        float moveYSpeed = 3f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0) {
            float disappearSpeed = 5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0) {
                Destroy(gameObject);
            }
        }
    }
}
