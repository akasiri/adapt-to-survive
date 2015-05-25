using UnityEngine;
using System.Collections;

public class PredatorScript : Obstacle {

	// Use this for initialization
    protected override void OnTriggerDestroy()
    {
        GetComponent<PredatorDeath>().Explode();
    }
}
