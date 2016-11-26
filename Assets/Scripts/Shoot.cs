using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour {

    // UI info
    public Text ctrlInfoLabel;
    public Text ctrlInfoShoot;
    public Text ctrlInfoMovement;

    public float x;            // spawning projectiles x
    public float y;            // spawning projectiles y
    public float z;            // spawning projectiles z
    public float speedOfShot;  // speed of shot
    public float speedOfMove;  // speed of shot

    public GameObject prefab;  // prefab to instantiate
    public AudioClip shot;     // audio asset to play when shot occurs
    AudioSource audio;

    // Use this for initialization
    void Start () {
        ctrlInfoLabel.text = "Key bindings:";
        ctrlInfoShoot.text = "Shoot Ball: Space";
        ctrlInfoMovement.text = "Movement: Arrows";

        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        bool shoot = Input.GetButtonDown("Jump"); // get input
        if (shoot) ShootProjectile();             // shoot

        // move 'player' pistol x and y
        float moveHor = Input.GetAxis("Horizontal"); // get input
        float moveVert = Input.GetAxis("Vertical");  // get input

        x += moveHor * speedOfMove * Time.deltaTime;                   // move point of ball spawning according to input
        y += moveVert * speedOfMove * Time.deltaTime;                  // move point of ball spawning according to input
        Vector3 movement = new Vector3(moveHor, 0.0f, -moveVert);      // setup vector to move pistol model
        transform.Translate(movement * speedOfMove * Time.deltaTime);  // move pistol model with vector
    
    }

    // instantiates and applies force to the projectile
    void ShootProjectile()
    {
        GameObject projectile = (GameObject)Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity); // instantiate projectile
        projectile.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, speedOfShot));                // add force to the instantiated projectile
        audio.PlayOneShot(shot, 0.7F); // play a sound
    }
}
