using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTesti : MonoBehaviour {

    ConfigurableJoint joint;
    float contract;
    Vector3 rotation;

    private void Awake()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        /*
        float grow = Input.GetAxis("P1_Grow");
        float shrink = Input.GetAxis("P1_Shrink");

        if (grow != 0)
        {
            contract += 0.1f;
            contract = Mathf.Clamp(contract, -8f, 1f);
            joint.targetPosition = new Vector3(contract, 0, 0);
        }

        if (shrink != 0)
        {
            contract -= 0.1f;
            contract = Mathf.Clamp(contract, -8f, 1f);
            joint.targetPosition = new Vector3(contract, 0, 0);
        }
        */
    }


}
