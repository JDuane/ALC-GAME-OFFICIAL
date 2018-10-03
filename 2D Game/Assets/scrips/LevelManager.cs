using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	private Rigidbody2D pc;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay
	public float RespawnDelay;

	// Point Penalty on Death
	public int PointPenaltyOnDeath;

	// Store Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<Rigidbody2D> ();
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnpcCo");
	}

	public IEnumerator RespawnPlayerCo(){
		// Generate Death Particle
		Instantiate (DeathParticle, pc.transform.position, pc.transform.rotation);
		// Hide pc
		// pc.enabled = false
		pc.GetComponent<Renderer>().enabled = false;
		//Gravity Reset
		GravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
		pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
		pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug Message
		Debug.Log ("pc Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		// Gravity Restore
		pc.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		// Match pcs transform position
		pc.transform.position = CurrentCheckPoint.transform.position;
		// Show pc
		// pc.enable = true;
		pc.GetComponent<Renderer> ().enabled = true;
		// Spawn pc
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);

	}
}
