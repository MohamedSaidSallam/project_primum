using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMesh = null;
    private float disappearTimer = 0.8f;
    private Color textColor;
    private float moveYSpeed = 3f;

    private void Update()
    {
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
