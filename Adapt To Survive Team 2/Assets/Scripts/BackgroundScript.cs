using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {
	public float speed = 0.5f;

	void Start () {
	
	}

	void Update () {
		Vector2 offset = new Vector2 (0f, Time.time * speed);
		this.gameObject.GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
