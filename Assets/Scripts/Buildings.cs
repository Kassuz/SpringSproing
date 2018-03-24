using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {


    public Material[] windows;
    public GameObject[] buildingBlock;
    Rigidbody rb, otherRb, childRB;
    Renderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < buildingBlock.Length; i++)
        {
            buildingBlock[i] = gameObject.transform.GetChild(i).gameObject;
            rend = buildingBlock[i].GetComponent<Renderer>();
            rend.material = windows[Random.Range(0, windows.Length)];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        otherRb = other.GetComponent<Rigidbody>();
        for (int i = 0; i < buildingBlock.Length; i++)
        {
            childRB = buildingBlock[i].GetComponent<Rigidbody>();
            childRB.isKinematic = false;
            
        }
        //Debug.Log(otherRb.velocity);
        
    }
}
