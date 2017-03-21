using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourScript : MonoBehaviour
{
    public enum States { IDLE, HUNT }
    public States state;
    public int life;
    public int damage;

    [Header("Transforms")]
    public Transform target;

    [Header("Distances")]
    public float distanceFromTarget;
    public float huntRange;

    [Header("TimeCounter")]
    public float timeCounter;

    [Header("Movement")]
    private float speed;
    public Vector3 direction;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //target = GameObject.Find ("Character").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (life <= 0)
        {
            Application.LoadLevel("win_scene");
        }
        switch (state)
        {
            case States.IDLE:
                {
                    UpdateIdle();
                    break;
                }
            case States.HUNT:
                {
                    UpdateHunt();
                    break;
                }
        }
    }

    void UpdateIdle()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target.position);

        if (distanceFromTarget < huntRange)
        {
            SetHunt();
        }
    }
    void UpdateHunt()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target.position);

        if (distanceFromTarget > huntRange)
        {
            SetIdle();
        }

        CalculateDirection();
        rb.velocity = direction;

        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);
    }

    void SetIdle()
    {
        speed = 0;
        state = States.IDLE;
    }
    void SetHunt()
    {
        speed = 7;
        state = States.HUNT;
    }

    void CalculateDirection()
    {
        direction = target.position - transform.position;
        direction = direction.normalized;

        direction.y = rb.velocity.y;
        direction.x *= speed;
        direction.z *= speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shoot")
        {
            life -= damage;
        }
    }
}
