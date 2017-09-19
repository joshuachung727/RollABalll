using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {
	public float slowValue=6f;
    public float speed;
	public float thrustSpeed=2.5f;
    public Text countText;

	public bool big=true;
	public Text winText;
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
		winText.text = "";
		SetCountText ();
    }

    void FixedUpdate()
    {
		if (big) {
			transform.localScale += vec*Time.deltaTime;
		}
      
		if (Input.GetKey ("space")) {
			rb.AddForce (Vector3.up * thrustSpeed, ForceMode.Impulse);
		}

        if (Input.GetKey("z"))
			rb.AddForce(-Vector3.up * thrustSpeed, ForceMode.Impulse);

		if (rb.velocity != Vector3.zero) {
			rb.velocity *= 1 - slowValue / 100;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = 40;
		} else {
			speed = 20;
		}



		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ( "pickUps"))
        {
            count++;
			SetCountText ();
            other.gameObject.SetActive(false);

        }
    }
	void SetCountText(){
		countText.text = "Count: " + count;
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}
