using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    Rigidbody rb, otherRB;
    public float cubeForce;
    public LayerMask destructableBuildings;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * cubeForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestructableBuilding"))
        {
            Vector3 spawnPos = collision.transform.parent.transform.position;
            collision.gameObject.SetActive(false);
            
            if (collision.gameObject.name == "Block1_Full")
                BuildingPool.Instance.SpawnFromPool("building1", spawnPos, Quaternion.identity);
            else if (collision.gameObject.name == "Block2_Full")
                BuildingPool.Instance.SpawnFromPool("building2", spawnPos, Quaternion.identity);
            else if (collision.gameObject.name == "Block3_Full")
                BuildingPool.Instance.SpawnFromPool("building3", spawnPos, Quaternion.identity);
        }
    }

}

//RaycastHit[] hits;
//hits = Physics.SphereCastAll(transform.position, 4f, transform.position, destructableBuildings);
//foreach(RaycastHit hit in hits)
//{
//    if (hit.collider.CompareTag("DestructableBuilding"))
//    {
//        otherRB = hit.collider.gameObject.GetComponent<Rigidbody>();
//        otherRB.AddExplosionForce(1000f, transform.position, 50f);
//    }
//}

//rb.AddExplosionForce(1000f, transform.position, 50f);