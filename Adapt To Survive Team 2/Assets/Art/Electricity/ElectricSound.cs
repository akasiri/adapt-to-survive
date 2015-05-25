using UnityEngine;
using System.Collections;

public class ElectricSound : MonoBehaviour {

	// Update is called once per frame
	void Update()
	{
		if (!GetComponent<Renderer>().isVisible)
			GetComponent<AudioSource>().Play();
	}
}
