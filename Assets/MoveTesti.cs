using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTesti : MonoBehaviour {

    Rigidbody rig;
    bool grounded;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");

        if (h != 0) rig.AddForce(transform.right * 200f * h);
        if (v != 0) rig.AddForce(transform.forward * 200f * v);
        if (j != 0 && grounded) rig.AddForce(transform.up * 170f, ForceMode.Impulse);
        /*
        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(-transform.right * 200f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(transform.right * 200f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(transform.forward * 200f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(-transform.forward * 200f);
        }
        */
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded) rig.AddForce(transform.up * 175f, ForceMode.Impulse);
        }
        */
        Debug.Log(j);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "ground") grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ground") grounded = false;
    }


}
