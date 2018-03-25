using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public int playerNumber;
    Rigidbody rig;
    public LayerMask player1;
    public LayerMask player2;
    public Rigidbody player1Rig;
    public Rigidbody player2Rig;
    public GameControllerScript gameController;
    public ParticleSystem partikkeleja;
    public AudioSource audioS;
    public AudioClip[] hitSounds;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    public void SetPlayerNumber(int nr)
    {
        playerNumber = nr;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((player2.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer && playerNumber == 1)
        {
            float impakti = collision.relativeVelocity.magnitude;

            if (impakti > 6f)
            {
                gameController.TakeDamage(2, collision.relativeVelocity.magnitude);
                player2Rig.AddForce((player2Rig.transform.position - transform.position) * collision.relativeVelocity.magnitude * 2f, ForceMode.Impulse);
                player2Rig.AddForce(Vector3.up, ForceMode.Impulse);
                partikkeleja.Play();
                audioS.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
            }

        }

        if ((player1.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer && playerNumber == 2)
        {
            float impakti = collision.relativeVelocity.magnitude;

            if (impakti > 6f)
            {
                gameController.TakeDamage(1, collision.relativeVelocity.magnitude);
                player1Rig.AddForce((player1Rig.transform.position - transform.position) * collision.relativeVelocity.magnitude * 2f, ForceMode.Impulse);
                player1Rig.AddForce(Vector3.up, ForceMode.Impulse);
                partikkeleja.Play();
                audioS.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
            }
        }
    }

}
