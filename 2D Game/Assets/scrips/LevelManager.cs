using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D pc;

	public GameObject pc2;

	// Particles
	public GameObject DeathPs;
	public GameObject RespawnPs;

	// Respawn Delay
	public float RespawnDelay;

	// Point Penalty on Death
	public int PointPenaltyOnDeath;

	// Store Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		pc = GameObject.Find("pc").GetComponent<Rigidbody2D>();
		pc2 = GameObject.Find("pc");
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		// Generate Death Particle
		Instantiate (DeathPs, pc.transform.position, pc.transform.rotation);
		// Hide pc
		// pc.enabled = false
		pc2.SetActive(false);
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
		pc2.SetActive(true);
		pc.GetComponent<Renderer> ().enabled = true;
		// Spawn pc
		Instantiate (RespawnPs, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);

	}
}
