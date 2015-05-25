using UnityEngine;
using System.Collections;

public class PredatorDeath : MonoBehaviour {

	public GameObject blood;
	private GameObject b;

	public void Explode()
	{
		Destroy (gameObject);
		b = Instantiate (blood, gameObject.transform.position, blood.transform.rotation) as GameObject;
		Destroy (b, 0.3f);
	}
}
