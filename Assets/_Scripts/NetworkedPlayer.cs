using UnityEngine;
using UnityEngine.Networking;

public class NetworkedPlayer : NetworkBehaviour
{
    public struct PlayerInput
    {
        public float leftXAxis;
        public float leftYAxis;
        public float rightXAxis;
        public float rightYAxis;
        public float jumpAxis;
    }

    [SerializeField] private Rigidbody leftArm;
    [SerializeField] private Rigidbody rightArm;

    [Space()]
    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxRotationSpeed;

    [Space()]
    [Header("Camera")]
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private Transform cameraRoot;
    [SerializeField] private float cameraYTurnSpeed = 40.0f;

    private Rigidbody rb;
    
    [Space()]
    [Header("Tommi stuff")]
    public Rigidbody leftWeapon;
    public SpringJoint shieldSpring;
    public Transform testTransform;
    public ConfigurableJoint testJoint;
    public Rigidbody head;
    public Rigidbody torso;
    public ParticleSystem jumpEffect;
    bool grounded;

    [SyncVar]
    private PlayerInput input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (!isLocalPlayer)
            cameraObj.SetActive(false);
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
        if (isLocalPlayer)
            CmdSetInputOnServer(GetInput());

        Movement(input);
    }

    private void Movement(PlayerInput input)
    {
        Vector3 localVel = transform.InverseTransformDirection(rb.velocity);

        if (Mathf.Abs(localVel.z) < maxSpeed)
        {
            rb.AddForce(transform.forward * input.leftYAxis * -150f);
        }

        if (Mathf.Abs(localVel.x) < maxSpeed)
        {
            rb.AddForce(transform.right * input.leftXAxis * 150f);
        }

        if (Mathf.Abs(rb.angularVelocity.y) < maxRotationSpeed)
        {
            float rotSpeed = -input.rightXAxis * rotationSpeed;
            rb.rotation *= Quaternion.AngleAxis(rotSpeed, Vector3.up);
        }

        if (grounded && input.jumpAxis > 0.5f)
        {
            rb.AddForce(Vector3.up * 60f, ForceMode.Impulse);
            head.AddForce(Vector3.up * 3f, ForceMode.Impulse);
            torso.AddForce(Vector3.up * 60f, ForceMode.Impulse);
            jumpEffect.Play();
        }
        
    }

    private void LateUpdate()
    {
        float ySpeed =   InputManager.Instance.P1InputRightY * cameraYTurnSpeed * Time.deltaTime;
        Quaternion newRot = Quaternion.AngleAxis(ySpeed, Vector3.right);
        
        cameraRoot.rotation *= newRot;
    }

    private PlayerInput GetInput()
    {
        PlayerInput i = new PlayerInput
        {
            leftXAxis  = InputManager.Instance.P1InputLeftX,
            leftYAxis  = InputManager.Instance.P1InputLeftY,
            rightXAxis = InputManager.Instance.P1InputRightX,
            rightYAxis = InputManager.Instance.P1InputRightY,
            jumpAxis   = InputManager.Instance.P1JumpButton
        };
        return i;
    }

    [Command]
    private void CmdSetInputOnServer(PlayerInput newInput)
    {
        input = newInput;
    }
}