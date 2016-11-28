using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour {

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
        audio = GetComponent<AudioSource>(); // map audio source to component
    }

    // Update is called once per frame
    void Update() {
        bool shoot = Input.GetButtonDown("Fire1"); // get input
        if (shoot) ShootProjectile();             // shoot

        // move 'player' pistol x and y
        float moveHor = Input.GetAxis("Horizontal"); // get input
        float moveVert = Input.GetAxis("Vertical");  // get input

        x += moveHor * speedOfMove * Time.deltaTime;                   // move point of ball spawning according to input
        y += moveVert * speedOfMove * Time.deltaTime;                  // move point of ball spawning according to input
    }

    // instantiates and applies force to the projectile
    void ShootProjectile()
    {
        GameObject projectile = (GameObject)Instantiate(prefab, transform.position, transform.rotation); // instantiate projectile
        projectile.GetComponent<Rigidbody>().AddForce(transform.up * speedOfShot);                // add force to the instantiated projectile
        audio.PlayOneShot(shot, 0.7F); // play a sound
    }
}
