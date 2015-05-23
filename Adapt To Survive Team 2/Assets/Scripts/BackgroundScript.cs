using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {
	float speed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0f, Time.time * speed);

		this.gameObject.GetComponent<Renderer> ().material.mainTextureOffset = offset;

	}
}
