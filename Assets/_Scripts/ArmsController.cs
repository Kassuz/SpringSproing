using UnityEngine;
using System.Collections;

public class ArmsController : MonoBehaviour
{
    [SerializeField] private Rigidbody leftArm;
    [SerializeField] private Rigidbody rightArm;

    [Space()]
    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationSpeed;

    [Space()]
    [Header("Camera")]
    [SerializeField] private Transform cameraRoot;
    [SerializeField] private float cameraYTurnSpeed = 40.0f;
    public AudioClip bicycleClip;
    public AudioClip[] fartNoises;
    public int player;
    private Rigidbody rb;
    public Rigidbody head;
    public Rigidbody torso;
    public ParticleSystem jumpEffect;
    public WeaponScript weaponScript;
    bool grounded;
    AudioSource aSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        weaponScript.SetPlayerNumber(player);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground") grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground") grounded = false;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 localVel = transform.InverseTransformDirection(rb.velocity);
        if (player == 1)
        {
            if (Mathf.Abs(localVel.z) < maxSpeed)
            {
                rb.AddForce(transform.forward * InputManager.Instance.P1InputLeftY * -150f);
            }

            if (Mathf.Abs(localVel.x) < maxSpeed)
            {
                rb.AddForce(transform.right * InputManager.Instance.P1InputLeftX * 150f);
            }

            if (Mathf.Abs(rb.angularVelocity.y) < maxRotationSpeed)
            {
                float rotSpeed = -InputManager.Instance.P1InputRightX * rotationSpeed;
                rb.rotation *= Quaternion.AngleAxis(rotSpeed, Vector3.up);
            }

            if (grounded && InputManager.Instance.P1JumpButton > 0.5f)
            {
                rb.AddForce(Vector3.up * 60f, ForceMode.Impulse);
                head.AddForce(Vector3.up * 3f, ForceMode.Impulse);
                torso.AddForce(Vector3.up * 60f, ForceMode.Impulse);
                jumpEffect.Play();
            }
        }
        else
        {
            if (Mathf.Abs(localVel.z) < maxSpeed)
            {
                rb.AddForce(transform.forward * InputManager.Instance.P2InputLeftY * -150f);
            }

            if (Mathf.Abs(localVel.x) < maxSpeed)
            {
                rb.AddForce(transform.right * InputManager.Instance.P2InputLeftX * 150f);
            }

            if (Mathf.Abs(rb.angularVelocity.y) < maxRotationSpeed)
            {
                float rotSpeed = -InputManager.Instance.P2InputRightX * rotationSpeed;
                rb.rotation *= Quaternion.AngleAxis(rotSpeed, Vector3.up);
            }

            if (grounded && InputManager.Instance.P2JumpButton > 0.5f)
            {
                rb.AddForce(Vector3.up * 60f, ForceMode.Impulse);
                head.AddForce(Vector3.up * 3f, ForceMode.Impulse);
                torso.AddForce(Vector3.up * 60f, ForceMode.Impulse);
                jumpEffect.Play();
            }
        }

        if (rb.velocity.magnitude > 3f)
        {
            aSource.clip = bicycleClip;

        }
        
    }

    private void LateUpdate()
    {

        if (player == 1)
        {
            float ySpeed = InputManager.Instance.P1InputRightY * cameraYTurnSpeed * Time.deltaTime;
            Quaternion newRot = Quaternion.AngleAxis(ySpeed, Vector3.right);

            cameraRoot.rotation *= newRot;
        }
        else
        {
            float ySpeed = InputManager.Instance.P2InputRightY * cameraYTurnSpeed * Time.deltaTime;
            Quaternion newRot = Quaternion.AngleAxis(ySpeed, Vector3.right);

            cameraRoot.rotation *= newRot;
        }

    }

    

}