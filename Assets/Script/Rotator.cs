using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	private Vector3 vec ;
	private Vector3 vec2;
	float timer=0;
	Light lt;
	Rigidbody rb;
	public float scale = 2f;
	void Start(){
		lt = GetComponent<Light> ();
		vec = new Vector3 (15, 30, 45);
		vec2 = Vector3.one * scale;
		transform.localScale = vec2;
		rb = GetComponent<Rigidbody> ();
	}
	void Update () {
		timer+=Time.deltaTime;
		if (timer > 0.2) {
			changeLight ();
			timer = 0;
		}

		transform.Rotate (vec*Time.deltaTime);
	}
	void FixedUpdate(){
		if (transform.position.magnitude > 173) {
			rb.velocity *= 0;
			Vector3 back = Vector3.zero-transform.position;
			rb.AddForce (back,ForceMode.Impulse);
		}
	}

	void changeLight(){
		Color coll=new Color();
		coll = Color.yellow;
		lt.color = coll;

	}
}
