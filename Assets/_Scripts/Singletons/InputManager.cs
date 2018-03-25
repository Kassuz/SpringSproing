using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public float P1InputLeftX  { get; private set; }
    public float P1InputLeftY  { get; private set; }
    public float P1InputRightX { get; private set; }
    public float P1InputRightY { get; private set; }
    public float P1LeftTrigger { get; private set; }
    public float P1RightTrigger { get; private set; }
    public float P1JumpButton { get; private set; }

    public float P2InputLeftX  { get; private set; }
    public float P2InputLeftY  { get; private set; }
    public float P2InputRightX { get; private set; }
    public float P2InputRightY { get; private set; }
    public float P2LeftTrigger { get; private set; }
    public float P2RightTrigger { get; private set; }
    public float P2JumpButton { get; private set; }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        P1InputLeftX  =  Input.GetAxis("P1 leftstick x");
        P1InputLeftY  =  Input.GetAxis("P1 leftstick y");
        P1InputRightX =  Input.GetAxis("P1 rightstick x");
        P1InputRightY =  Input.GetAxis("P1 rightstick y");
        P1LeftTrigger = Input.GetAxis("P1 leftTrigger");
        P1JumpButton = Input.GetAxis("P1 jump");


        P2InputLeftX  =  Input.GetAxis("P2 leftstick x");
        P2InputLeftY  =  Input.GetAxis("P2 leftstick y");
        P2InputRightX =  Input.GetAxis("P2 rightstick x");
        P2InputRightY =  Input.GetAxis("P2 rightstick y");
        P2JumpButton = Input.GetAxis("P2 jump");
    }
}