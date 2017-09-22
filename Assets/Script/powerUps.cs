using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour {
    private IEnumerator coroutine;
    SphereCollider sp;
	public float expandRadius=30f;
	public float suckSpeed = 3f;
    // Use this for initialization
    void Start () {
        sp = GetComponent<SphereCollider>();
        sp.radius = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
		sp.radius = 0.5f;
        if (Input.GetKey("q"))
        {
			
            //coroutine = spExpand();
           // StartCoroutine(coroutine);
			sp.radius = expandRadius;
        }

    }

    private IEnumerator spExpand()
    {
		for (int i=0;i<4;i++)
        {
            yield return new WaitForSeconds(0.1f);
            sp.radius++;
			print ("aye");
        }
        sp.radius = 0.5f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUps"))
        {
            Vector3 vec = transform.position-other.transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(vec*suckSpeed,ForceMode.Impulse);

        }
    }
   
}
