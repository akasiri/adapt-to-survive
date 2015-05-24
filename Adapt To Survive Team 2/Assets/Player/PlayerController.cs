using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    Rigidbody rb;
    private int numLanes = 3;
    private int lane = 1;
    public float laneDistance = 2f;
    private ParticleSystem jumpDust;
    private Controls control;

    private AudioSource aud;
    // Use this for initialization
    void Start()
    {
        control = GetComponent<Controls>();
        jumpDust = transform.Find("JumpDustParticleSystem").GetComponent<ParticleSystem>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        control.DoUpdate();
        if (control.ConsumeCommandStart(Controls.Command.LEFT) && lane > 0)
        {
            //Debug.Log("Jump!");
            aud.Play();
            lane--;
            StartCoroutine(UpdateLane());
            jumpDust.transform.eulerAngles = new Vector3(jumpDust.transform.eulerAngles.x, 90, jumpDust.transform.eulerAngles.z); //turn
            jumpDust.Play();

        }
        else if (control.ConsumeCommandStart(Controls.Command.RIGHT) && lane < numLanes - 1)
        {
            //Debug.Log("Jump!");
            aud.Play();
            lane++;
            StartCoroutine(UpdateLane());
            jumpDust.transform.eulerAngles = new Vector3(jumpDust.transform.eulerAngles.x, 270, jumpDust.transform.eulerAngles.z); //turn
            jumpDust.Play();
        }

    }

    IEnumerator UpdateLane()
    {
        float targetDistance;
        do
        {
            targetDistance = lane * laneDistance - this.transform.position.x;
            this.transform.position = this.transform.position + new Vector3(targetDistance / 3, 0, this.transform.position.z);
            yield return 0;
        }
        while (Mathf.Abs(targetDistance) > 0.1f);

        this.transform.position = new Vector3(lane * laneDistance, 0, this.transform.position.z);

        
    }

    //debugging
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
    }

}
