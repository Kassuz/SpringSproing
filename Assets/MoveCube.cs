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

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 spawnPos = collision.transform.parent.transform.position;
        if (collision.gameObject.CompareTag("DestructableBuilding")) //&& rb.velocity.magnitude > cubeForce)
        {
            Debug.Log(collision.gameObject.name);

            collision.gameObject.SetActive(false);

            if (collision.gameObject.name == "New_Block_01_Full")
            {
                BuildingPool.Instance.SpawnFromPool("building1", spawnPos, Quaternion.identity);
                BuildingPool.Instance.SpawnFromPool("BildDestruction", spawnPos, Quaternion.identity);
            }
            else if (collision.gameObject.name == "New_Block_02_Full")
            {
                BuildingPool.Instance.SpawnFromPool("building2", spawnPos, Quaternion.identity);
                BuildingPool.Instance.SpawnFromPool("BildDestruction", spawnPos, Quaternion.identity);
            }
            else if (collision.gameObject.name == "New_Block_03_Full")
            {
                BuildingPool.Instance.SpawnFromPool("building3", spawnPos, Quaternion.identity);
                BuildingPool.Instance.SpawnFromPool("BildDestruction", spawnPos, Quaternion.identity);
            }
            else if (collision.gameObject.name == "New_Block_04_Full")
            {
                BuildingPool.Instance.SpawnFromPool("building4", spawnPos, Quaternion.identity);
                BuildingPool.Instance.SpawnFromPool("BildDestruction", spawnPos, Quaternion.identity);
            }
            else if (collision.gameObject.name == "New_Block_05_Full")
            {
                BuildingPool.Instance.SpawnFromPool("building5", spawnPos, Quaternion.identity);
                BuildingPool.Instance.SpawnFromPool("BildDestruction", spawnPos, Quaternion.identity);
            }
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {

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