using UnityEngine;
using System.Collections;

public class CameraBasedPosition : MonoBehaviour {
    public float xpos;
    public float ypos;
	// Use this for initialization
	void Start () {
        this.transform.position = (Vector2)(Camera.main.ViewportToWorldPoint(new Vector3(xpos, ypos, 0)));
	}

    public static IEnumerator LerpTo(GameObject obj, Vector3 position, float dampening = 0.5f)
    {
        Vector3 distance = obj.transform.position - position;
        while (distance.magnitude < 0.1)
        {
            obj.transform.position -= dampening * distance;
            distance = obj.transform.position - position;
            yield return 0;
        }
    }
}
