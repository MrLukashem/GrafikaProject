using UnityEngine;
using System.Collections;

public class CanCollider : MonoBehaviour
{
    public AudioClip CollisionCanCan;           // audio asset to play when can and can collide
    public AudioClip CollisionCanGround;        // audio asset to play when can and ground collide
    public AudioClip CollisionCanProjectile;    // audio asset to play when can and projectile collide
    AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        audio = GetComponent<AudioSource>();
        switch (other.gameObject.tag)
        {
            case "Can":         audio.PlayOneShot(CollisionCanCan, 0.7F);           break;
            case "Ground":      audio.PlayOneShot(CollisionCanGround, 0.7F);        break;
            case "Projectile":  audio.PlayOneShot(CollisionCanProjectile, 0.7F);    break;
        }
    }
}
