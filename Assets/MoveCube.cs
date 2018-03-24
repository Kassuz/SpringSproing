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
            RaycastHit[] hits;

            hits = Physics.SphereCastAll(transform.position, 4f, transform.position, destructableBuildings);
            //foreach(RaycastHit hit in hits)
            //{
            //    if (hit.collider.CompareTag("DestructableBuilding"))
            //    {
            //        otherRB = hit.collider.gameObject.GetComponent<Rigidbody>();
            //        otherRB.AddExplosionForce(1000f, transform.position, 50f);
            //    }
            //}

            //rb.AddExplosionForce(1000f, transform.position, 50f);
            collision.gameObject.SetActive(false);
            BuildingPool.Instance.SpawnFromPool("building", collision.transform.parent.transform.position, Quaternion.identity);
        }
    }

}