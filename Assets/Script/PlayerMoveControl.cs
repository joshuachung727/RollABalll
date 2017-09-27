using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {
	public float slowValue=6f;
    public float Initialspeed;
	public float thrustSpeed=2.5f;
    public Text countText;
    public GameObject Camera;
    public float dashSpeed = 5f;


	public bool big=true;
	public Text winText;
	public float ballScale = 1;
	private bool gravityStatus = true;
  
    private Rigidbody rb;
    private int count;
  
	Vector3 vec;
    private float speed;
    void Start()
    {
        speed = Initialspeed;
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

        if (Input.GetKey("c"))
			rb.AddForce(-Vector3.up * 2*thrustSpeed, ForceMode.Impulse);

		slowDown();

		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = Initialspeed*6;
		} else {
			speed = Initialspeed;
		}

		if (Input.GetKey ("e")) {
			rb.AddTorque (Vector3.up*10000);
		}

        




        float moveHorizontal = -Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		if (moveVertical != 0 || moveHorizontal != 0) {
			gravityStatus = false;

		} else {
			gravityStatus = true;
		}
        //  Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 cameraVec = new Vector3(Camera.transform.forward.x,0, Camera.transform.forward.z);
        Vector3 movement = Camera.transform.forward * moveVertical     +   Vector3.Cross(cameraVec, Vector3.up).normalized*moveHorizontal*0.8f;
        
        
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("f"))
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            Invoke("setGravity",1f);
            rb.AddForce(Camera.transform.forward*dashSpeed*1000);
        }
		rb.useGravity = gravityStatus;

    }
	void slowDown(){
		if (rb.velocity != Vector3.zero) {
		//	Vector3 rbVel = rb.velocity;
			//rb.velocity.Set((float)  rbVel.x *( 1-slowValue/100) , rbVel.y, (float)rbVel.z*( 1-slowValue/100));
			rb.velocity *= 1 - slowValue / 100;
		}
	}

    void setGravity()
    {
		if (gravityStatus) {
			rb.useGravity = true;
		}
        
        
    }
    
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ( "pickUps"))
        {
          
			addScore ();
            other.gameObject.SetActive(false);

        }
    }
	void SetCountText(){
		countText.text = "Count: " + count;
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
	public void addScore(){
		count++;
		SetCountText ();
	}
}
