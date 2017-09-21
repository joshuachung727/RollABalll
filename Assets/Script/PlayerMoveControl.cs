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


	public bool big=true;
	public Text winText;
	public float ballScale = 1;

  
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

		if (rb.velocity != Vector3.zero) {
			rb.velocity *= 1 - slowValue / 100;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = Initialspeed*2;
		} else {
			speed = Initialspeed;
		}

       

        




        float moveHorizontal = -Input.GetAxis("Horizontal");
       
		float moveVertical = Input.GetAxis("Vertical");

        //  Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 cameraVec = new Vector3(Camera.transform.forward.x,0, Camera.transform.forward.z);
        Vector3 movement = Camera.transform.forward * moveVertical     +   Vector3.Cross(cameraVec, Vector3.up).normalized*moveHorizontal*0.8f;
        
        print(speed);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("f"))
        {
            rb.velocity = Vector3.zero;
            print("thrust");
            rb.AddForce(Camera.transform.forward*thrustSpeed*1000);

        }
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
