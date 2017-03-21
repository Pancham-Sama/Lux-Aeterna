using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerBehaviourScript : MonoBehaviour
{
    [Header("Basic movement")]
    private CharacterController controller;
    public Transform playerTransform;
    public Transform toFace;
    public Vector3 moveDirection;
    private Vector3 inputAxis;
    private Vector3 desiredDirection;

    [Header("Health properties")]
	public bool deathFall;
    static public float life;
    public bool dead;
    public float damage;

    public bool godMode;

    [Header("Physics")]
    public float speed;
    public float speedRun;
    public float speedRun2;
    public float jumpSpeed;
    public float gravityMagnitude;
    public bool jump = false;
    private float forceToGround;
    public bool isGrounded;

    [Header("Combat")]
    static public float loadingCounter;
    public GameObject ShootRadius;
    public float shootActive;
    public bool shoot;
    // Use this for initialization
    void Start ()
    {  
        controller = GetComponent<CharacterController>();

        forceToGround = Physics.gravity.y;

        speed = 8;

        ShootRadius.SetActive(false);

        life = 1000;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (life >= 1000) life = 1000;
        ReadInput();

        if (life <= 0) Death();

        moveDirection += Physics.gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        rotX = 0;

        if (isGrounded && !jump)
        {
            moveDirection.y = forceToGround;
        }
        else
        {
            moveDirection += gravityMagnitude * Physics.gravity * Time.deltaTime;
            jump = false;
        }
        //rotate when... (look at)
        if (Input.GetButton("W") || Input.GetButton("S") || (Input.GetButton("Fire2")) || Input.GetButton("A") || Input.GetButton("D"))
        {
            Vector3 targetPostition = new Vector3(toFace.position.x, this.transform.position.y, toFace.position.z);
            this.transform.LookAt(toFace);
        }
        //activate godMode
        if (Input.GetButtonDown("G")) godMode = true;
        if (Input.GetButtonDown("H")) godMode = false;
        if (godMode == true) GodMode();

        //Shot logic
        if (godMode == false)
        {
            if (loadingCounter >= 240) loadingCounter = 240;
            if (Input.GetButton("Fire2")) loadingCounter++;
            if (Input.GetButtonUp("Fire2") && loadingCounter >= 60) shoot = true;
            if (!Input.GetButton("Fire2") && shoot == false) loadingCounter = 0;
            if (shoot == true)
            {
                shootActive++;
            }
            if (shootActive >= 19)
            {
                shoot = false;
                shootActive = 0;
                ShootRadius.SetActive(false);
                loadingCounter = 0;
            }
            if (shootActive > 1 && shootActive < 19)
            {
                Shot();
            }
            if (loadingCounter < 19) ShootRadius.SetActive(false);
        }

        //calculate direction movement
        desiredDirection = inputAxis.x * transform.right + inputAxis.z * transform.forward;

        moveDirection.x = desiredDirection.x * speed;
        moveDirection.z = desiredDirection.z * speed;

        //is Grounded?
        if (!controller.isGrounded)
        {
            isGrounded = false;
        }
    }
    void ReadInput ()
    {
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.z = Input.GetAxis("Vertical");

        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                jump = true;
                moveDirection.y = jumpSpeed * gravityMagnitude;
            }
        }

        if(Input.GetKey(KeyCode.LeftShift)) speed = speedRun;
        else
        {
            speed = 8;
        }
    }

    public float rotX
    {
        get { return transform.rotation.eulerAngles.x; }
        set
        {
            Vector3 v = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0, v.y, v.z);
        }
    }

    void Shot()
    {
        ShootRadius.SetActive(true);
    }

    bool isMoving()
    {
        if ((inputAxis.x != 0) || (inputAxis.z != 0))
        {
            return true;
        }
        else return false;
    }

    public void Damage(int hit)
    {
        life -= hit;
        //Play hurt sound
        if (life <= 0)
        {
            dead = true;
            //Play death sound
        }
        else
        {
            //Play hurt sound
            //sound.Play(2, 1, 1);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
		deathFall = true;

		if (hit.gameObject.layer == 10) { //la layer "Ground" = 10
			isGrounded = true;
		} else
			isGrounded = false;
		
		if (hit.gameObject.layer == 11)
			Death();

        if (hit.gameObject.layer == 12)
            DeathStartMap();

        if (hit.gameObject.layer == 16)
            Application.LoadLevel("scene1");
    }
    
    void GodMode()
    {
        life = 1000;
        if (Input.GetButton("Fire2")) Shot();
        else if (!Input.GetButton("Fire2")) ShootRadius.SetActive(false);
        loadingCounter = 1000;

        if (Input.GetButton("Jump"))
        {
            jump = true;
            moveDirection.y = jumpSpeed * gravityMagnitude;
        }

        if (Input.GetButton("Fire2")) Shot();
        if (Input.GetKey(KeyCode.LeftShift)) speed = speedRun2;
        else
        {
            speed = 8;
        }
    }
	void Death()
	{
		Application.LoadLevel("scene1");
	}

    void DeathStartMap()
    {
        Application.LoadLevel("star_map");
    }
}
