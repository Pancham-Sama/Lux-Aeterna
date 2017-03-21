using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    private bool death;
    public bool stunned;
    public enum States { IDLE, HUNT, ATTACK, DAMAGE, DEAD }
    public States state;

    [Header("Transforms")]
    public Transform target;

    [Header("Distances")]
    public float distanceFromTarget;
    public float huntRange;
    public float attackRange;

    [Header("Animation")]
    public Animator anim;
    public Renderer rend;

    [Header("TimeCounter")]
    public float attackCoolDown;
    public float stunTime;
    public float timeCounter;
    public float damageTakenCounter;

    [Header("Stats")]
    public float life;
    public float hit;
    bool tokeDamage;
    public float damage;

    [Header("Movement")]
    private float speed;
    public Vector3 direction;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        death = false;
        rb = GetComponent<Rigidbody>();
        //target = GameObject.Find ("Character").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        life = 320;
    }

    void Update()
    {
        if (damageTakenCounter >= 25) 
        {
            tokeDamage = false;
            damageTakenCounter = 26;
        }
        if (tokeDamage == true)
        {
            damageTakenCounter++;
        }
        float shootPower = CharacterControlerBehaviourScript.loadingCounter;
        damage = shootPower;
        if (life <= 0) death = true;
        if (death == true) Destroy(this.gameObject);
        if (stunned == false)
        {
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
                case States.ATTACK:
                    {
                        UpdateAttack();
                        break;
                    }
                case States.DAMAGE:
                    {
                        UpdateDamage();
                        break;
                    }
                case States.DEAD:
                    {
                        UpdateDead();
                        break;
                    }
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
        if (distanceFromTarget < attackRange)
        {
            SetAttack();
        }

        CalculateDirection();
        rb.velocity = direction;
        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);

    }
    void UpdateAttack()
    {
        speed = 0;
        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);
        if (timeCounter >= attackCoolDown)
        {
            timeCounter = 0;
            CharacterControlerBehaviourScript.life -= hit;
            SetIdle();
        }
        else
        {
            timeCounter += Time.deltaTime;
        }
    }
    void UpdateDamage()
    {
        //recibir daño de Player
    }
    void UpdateDead()
    {
        if (life <= 0) death = true;//morir
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
    void SetAttack()
    {
        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);
        //anim.SetBool("IsPlayerNear", false);
        //anim.Play("Attack");
        speed = 0;
        state = States.ATTACK;
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
        if ((other.tag == "Shoot") && (tokeDamage == false))
        {
            damageTakenCounter = 0;
            tokeDamage = true;
            life -= damage;
        }
    }
    void OnTriggerExit(Collider other)
    {

    }
}
