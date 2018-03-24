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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
        
        if (Mathf.Abs(rb.angularVelocity.y) < maxRotationSpeed)
        {
            float rotSpeed = -InputManager.Instance.P1InputRightX * rotationSpeed;
            rb.rotation *= Quaternion.AngleAxis(rotSpeed, Vector3.up);
        }
        Debug.Log(rb.angularVelocity);
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
    }

    private void LateUpdate()
    {
        float ySpeed =   InputManager.Instance.P1InputRightY * cameraYTurnSpeed * Time.deltaTime;
        Quaternion newRot = Quaternion.AngleAxis(ySpeed, Vector3.right);
        
        cameraRoot.rotation *= newRot;
    }

}