using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour {
    private IEnumerator coroutine;
    SphereCollider sp;
    // Use this for initialization
    void Start () {
        sp = GetComponent<SphereCollider>();
        sp.radius = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("q"))
        {
            coroutine = spExpand();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator spExpand()
    {
        while (sp.radius <= 20)
        {
            yield return new WaitForSeconds(0.001f);
            sp.radius++;
        }
        sp.radius = 0.5f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUps"))
        {
            Vector3 vec = transform.position-other.transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(vec*100,ForceMode.Impulse);

        }
    }
   
}
