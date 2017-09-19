using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	private Vector3 vec ;
	private Vector3 vec2;
	public float scale = 2f;
	void Start(){
		vec = new Vector3 (15, 30, 45);
		vec2 = Vector3.one * scale;
		transform.localScale = vec2;
	}
	void Update () {
		
		transform.Rotate (vec*Time.deltaTime);
	}
}
