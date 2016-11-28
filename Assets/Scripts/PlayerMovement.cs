using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speedOfMove = 10.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;
        bool isKeyPressed = false;
        //     Vector3 movement = new Vector3(moveHor, 0.0f, -moveVert);      // setup vector to move pistol model
        //   transform.Translate(movement * speedOfMove * Time.deltaTime);  // move pistol model with vector
        if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, 0, 1) * speedOfMove * Time.deltaTime;
            isKeyPressed = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left * speedOfMove * Time.deltaTime;
            isKeyPressed = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right * speedOfMove * Time.deltaTime;
            isKeyPressed = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back * speedOfMove * Time.deltaTime;
            isKeyPressed = true;
        }

        if (isKeyPressed)
        {
            transform.Translate(movement);
            isKeyPressed = false;
        }
    }
}
