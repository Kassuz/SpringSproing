using UnityEngine;

public class ArmsController : MonoBehaviour
{
    [SerializeField] private Rigidbody leftArm;
    [SerializeField] private Rigidbody rightArm;

    [Space()]
    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;

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
        Vector3 movement = new Vector3(InputManager.Instance.P1InputLeftX, 0.0f, InputManager.Instance.P2InputLeftY);
        movement *= maxSpeed;

        rb.velocity = movement;

        float rotSpeed = - InputManager.Instance.P1InputRightX * rotationSpeed * Time.fixedDeltaTime;
        rb.rotation *= Quaternion.AngleAxis(rotSpeed, Vector3.up);
    }

    private void LateUpdate()
    {
        float ySpeed =   InputManager.Instance.P1InputRightY * cameraYTurnSpeed * Time.deltaTime;
        Quaternion newRot = Quaternion.AngleAxis(ySpeed, Vector3.right);
        
        cameraRoot.rotation *= newRot;
    }

}