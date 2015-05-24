using UnityEngine;
using System.Collections;

public class TreeObstacle : Obstacle
{
    protected override void OnDestroy()
    {
          GetComponent<AudioSource>().Play();
    }
}
