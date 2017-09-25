using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;
	public GameObject Camera;

	bool audioPlaying=false;
	float timer;
	Ray shootRay = new Ray();
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer gunLine;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;
	// Use this for initialization
	void Start () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
		gunAudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			Shoot ();
		}



		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			Invoke ("DisableEffects",0f);

		}
	}

	public void DisableEffects ()
	{
		gunLine.enabled = false;
		gunLight.enabled = false;
		if (!audioPlaying) {
			audioPlaying = true;
			Invoke ("pauseAudio",timeBetweenBullets);
		}

	}

	void pauseAudio(){
		gunAudio.Pause ();
		audioPlaying = false;
	}

	void Shoot ()
	{
		timer = 0f;

		gunAudio.UnPause();

		gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position+Vector3.left*2);

		shootRay.origin = transform.position;
		shootRay.direction = Camera.transform.forward;

		if(Physics.Raycast (shootRay, out shootHit, range))
		{
			

			gunLine.SetPosition (1, shootHit.point);
			if (shootHit.collider.gameObject.CompareTag ( "pickUps")) {
				Destroy (shootHit.collider.gameObject);
			}
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}
