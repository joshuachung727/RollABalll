using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltPlatForm : MonoBehaviour {
    Vector3 vec;
	// Use this for initialization
	void Start () {
        vec = new Vector3(1,5,4);
	}
	
	
	void Update () {
        transform.Rotate(vec*Time.deltaTime);
	}
}
