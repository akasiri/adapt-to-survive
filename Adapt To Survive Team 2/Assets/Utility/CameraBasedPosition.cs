using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraBasedPosition : MonoBehaviour {
    public float xpos;
    public float ypos;
    public static Dictionary<int, IEnumerator> lerps = new Dictionary<int, IEnumerator>();
	// Use this for initialization
	void Start () {
        this.transform.position = (Vector2)(Camera.main.ViewportToWorldPoint(new Vector3(xpos, ypos, 0)));
	}
}
