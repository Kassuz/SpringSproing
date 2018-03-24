using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persetesti : MonoBehaviour {

    BuildingPool pool;

	void Start () {
        pool = GetComponent<BuildingPool>();

        InvokeRepeating("Spawn", 1f, 0.5f);
	}
	

	void Update () {
		
	}

    public void Spawn()
    {
        pool.SpawnFromPool("building", new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)), Quaternion.identity);
    }
}
