using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBackgroundScript : MonoBehaviour {

	void Update () {
		
        if (transform.position.z > 10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 1000f);
        }

	}
}
