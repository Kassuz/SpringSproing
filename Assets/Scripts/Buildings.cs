using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {


    public Material[] windows;
    public GameObject[] buildingBlock;
    public Vector3[] buildingBlockPos;
    Rigidbody rb, otherRb, childRB;
    Renderer rend;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < buildingBlock.Length; i++)
        {
            buildingBlock[i] = gameObject.transform.GetChild(i).gameObject;
            rend = buildingBlock[i].GetComponent<Renderer>();
            rend.material = windows[Random.Range(0, windows.Length)];

            buildingBlockPos[i] = buildingBlock[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        otherRb = other.GetComponent<Rigidbody>();
        for (int i = 0; i < buildingBlock.Length; i++)
        {
            childRB = buildingBlock[i].GetComponent<Rigidbody>();
            childRB.isKinematic = false;
            childRB.AddExplosionForce(1000f, transform.position, 50f);
        } 
    }

    private void OnDisable()
    {

    }
    private void OnEnable()
    {
        
        for (int i = 0; i < buildingBlock.Length; i++)
        {
            //buildingBlock[i].transform.position = buildingBlockPos[i];
            //Debug.Log(buildingBlock[i].transform.position);
        }
    }
}
