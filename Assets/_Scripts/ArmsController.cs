using UnityEngine;

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

    private Rigidbody rb;
    public Rigidbody leftWeapon;
    public SpringJoint shieldSpring;
    public Transform testTransform;
    public ConfigurableJoint testJoint;
    public Rigidbody head;
    public Rigidbody torso;
    public ParticleSystem jumpEffect;
    bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        ArmStuff();
    }

    void Movement()
    {
        Vector3 localVel = transform.InverseTransformDirection(rb.velocity);

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

    void ArmStuff()
    {
        leftWeapon.mass = 1f + InputManager.Instance.P1LeftTrigger * 5f;

        if (InputManager.Instance.P1RightTrigger > 0.3f)
        {
            testJoint.targetPosition = testTransform.position;

        }
        else
        {
            testJoint.targetPosition = Vector3.zero;
        }
       
    }

    private void LateUpdate()
    {
        float ySpeed =   InputManager.Instance.P1InputRightY * cameraYTurnSpeed * Time.deltaTime;
        Quaternion newRot = Quaternion.AngleAxis(ySpeed, Vector3.right);
        
        cameraRoot.rotation *= newRot;
    }

}