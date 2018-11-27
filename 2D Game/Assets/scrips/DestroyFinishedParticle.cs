using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem ThisParticleSystem;

	// Use this for initialization
	void Start () {
		ThisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ThisParticleSystem.isPlaying)
			return;

		Destroy (gameObject);
	}
	void OnBecameInvisible (){
		Destroy (gameObject);
	}

}
