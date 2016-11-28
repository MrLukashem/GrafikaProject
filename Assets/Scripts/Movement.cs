using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float mauseSpeedX = 2.0f;
    public float mauseSpeedY = 2.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = 10.0f;
    public float moveSpeed = 10.0f;

    private float yaw = .0f;
    private float pitch = 90.0f;
    private float lastCorrectPitch = 90.0f;
    private Vector3 horiz;
    private Vector3 vert;

    private Vector3 moveDirection = Vector3.zero;
    private Quaternion last;
    private Quaternion lastParent;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;

        yaw += mauseSpeedX * Input.GetAxis("Mouse X");
        pitch -= mauseSpeedY * Input.GetAxis("Mouse Y");
        last = Quaternion.Euler(90, yaw, .0f);

   //     lastParent = Quaternion.Euler(pitch, transform.parent.rotation.y, .0f);
    }

    // Update is called once per frame
    void Update() {
        yaw += mauseSpeedX * Input.GetAxis("Mouse X");
        pitch -= mauseSpeedY * Input.GetAxis("Mouse Y");

        if (pitch <= 120 && pitch >= 60)
        {
            lastCorrectPitch = pitch;
            transform.rotation = Quaternion.Euler(pitch, yaw, .0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(lastCorrectPitch, yaw, .0f);
        }

        
        transform.parent.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
