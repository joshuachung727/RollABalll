using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youllFloatToo : MonoBehaviour {

    public float timeInBetween=3f;

    Rigidbody rb;
    Vector3 vec;
    float timer=0f;
    
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer > timeInBetween)
        {
            vec = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            vec = vec.normalized * Random.Range(1, 100);
            rb.AddForce(vec, ForceMode.Impulse);
            timer = 0;
        }
        
    }
}
