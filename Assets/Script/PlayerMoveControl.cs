﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {

    public float speed;
    public Text countText;
	public bool big=true;
	public float ballScale = 1;
    private Rigidbody rb;
    private int count;
	Vector3 vec;
	
    void Start()
    {
		vec = new Vector3 (1,1,1);
		vec *= ballScale;
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count;
    }

    void FixedUpdate()
    {
		if (big) {
			transform.localScale += vec*Time.deltaTime;
		}
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("space"))
            rb.AddForce(Vector3.up*speed/10,ForceMode.Impulse);

        if (Input.GetKeyDown("m"))
            rb.AddForce(-Vector3.up * speed / 5, ForceMode.Impulse);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ( "pickUps"))
        {
            count++;
            countText.text = "Count: " + count;
            other.gameObject.SetActive(false);

        }
    }
}
