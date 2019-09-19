using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick = null;
    [SerializeField] private float speed = 12f;
    [SerializeField] private Rigidbody rigidbody = null;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        rigidbody.MovePosition(rigidbody.position + new Vector3(-joystick.Horizontal * speed * Time.deltaTime,
            0,
            -joystick.Vertical * speed * Time.deltaTime));
    }
}
