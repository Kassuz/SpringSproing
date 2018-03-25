using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBackgroundScript : MonoBehaviour {

	void Update () {
		
        if (transform.position.z > 7f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 800f);
        }

        if (transform.position.z < 10f) transform.position = new Vector3(transform.position.x, transform.position.y, 7f);
        Debug.Log(Time.time);
	}
}
