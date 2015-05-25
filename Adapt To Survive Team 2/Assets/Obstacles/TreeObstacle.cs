using UnityEngine;
using System.Collections;

public class TreeObstacle : Obstacle
{
    protected override void OnTriggerDestroy()
    {
		GetComponent<AudioSource>().Play();
    }
}
