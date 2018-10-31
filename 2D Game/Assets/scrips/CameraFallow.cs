using System.Collections;
using UnityEngine;

public class CameraFallow : MonoBehaviour {

	public CharacterMove Player;
	public bool isFallowing;

	// Camera position offset
	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<CharacterMove>();

		isFallowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFallowing){
			transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, transform.position.z);
		}
	}
}
