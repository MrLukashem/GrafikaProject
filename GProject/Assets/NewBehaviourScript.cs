using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    protected int speed = 0;
    protected Camera mMainCamera;

    void squareLogic()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            speed += 1;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            speed = 0;
        }

        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void doCameraMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mMainCamera.transform.Translate(0.0f, 0.0f, 13.0f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            mMainCamera.transform.Translate(0.0f , 0.0f, -13.0f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            mMainCamera.transform.Translate(13.0f * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            mMainCamera.transform.Translate(-13.0f * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            mMainCamera.transform.Translate(13.0f * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    // Use this for initialization
    void Start () {
        mMainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        squareLogic();
        doCameraMovement();
    }
}
