using UnityEngine;
using System.Collections;

public class CameraBasedPosition : MonoBehaviour {
    public float xpos;
    public float ypos;
	// Use this for initialization
	void Start () {
        this.transform.position = (Vector2)(Camera.main.ViewportToWorldPoint(new Vector3(xpos, ypos, 0)));
	}
}
