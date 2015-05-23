using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    Rigidbody rb;
    private int numLanes = 3;
    private int lane = 1;
    public float laneDistance = 2f;

    private Controls control;
    // Use this for initialization
    void Start()
    {
        control = GetComponent<Controls>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        control.DoUpdate();
        if (control.ConsumeCommandStart(Controls.Command.LEFT) && lane > 0)
        {
            Debug.Log("Jump!");
            lane--;
            StartCoroutine(UpdateLane());
        }
        else if (control.ConsumeCommandStart(Controls.Command.RIGHT) && lane < numLanes - 1)
        {
            Debug.Log("Jump!");
            lane++;
            StartCoroutine(UpdateLane());
        }

    }

    IEnumerator UpdateLane()
    {
        float targetDistance;
        do
        {
            targetDistance = lane * laneDistance - this.transform.position.x;
            this.transform.position = this.transform.position + new Vector3(targetDistance / 2, this.transform.position.y, this.transform.position.z);
            yield return 0;
        }
        while (targetDistance > 0.1f);

        this.transform.position = new Vector3(lane * laneDistance, this.transform.position.y, this.transform.position.z);

        
    }

}
