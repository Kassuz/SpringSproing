using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBackgroundScript : MonoBehaviour {

	void Update () {
		
        if (transform.position.z > 2f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 800f);
        }

        if (transform.position.z < 2f) transform.position = new Vector3(transform.position.x, transform.position.y, 2f);
        Debug.Log(Time.time);
	}
}
