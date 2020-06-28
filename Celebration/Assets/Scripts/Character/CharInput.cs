
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class CharInput : MonoBehaviour
{

    [Header("Object References")]
    public GameManager gameManager;
    private AudioSource vo_Player;
    private Object obj;

    [Header("Audio References")]
    public AudioClip vo_countdown;
    public AudioClip vo_dancing;
    public AudioClip vo_acquired;
    public AudioClip vo_submitted;
    public AudioClip vo_moveit;
    public AudioClip vo_savetheparty;
    public AudioClip vo_timeisrunningout;

    public float velocity = 9;
    [Space]

    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;


    [Header("Pickup")]
    public bool canPickUp; //Reference to pick up object
    public GameObject pickupID;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;


    private float verticalVel;
    private Vector3 moveVector;
    public bool canMove;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        vo_Player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Blend", Speed);
        InputMagnitude();

        if (Input.GetAxis("Grab") > 0)
        {
            //TO DO: Delete from list & Create UI feedback 
            Destroy(pickupID);
            vo_Event(vo_acquired);
        }

        //TO DO: Yell  & lock move
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Yell");
        }

        //TO DO: Defeat state & lock move
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Defeat");
        }

        //TO DO: Typing Sequence trigger (When grab pressed at console w/ item) & lock move
        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("Typing");
            vo_Event(vo_submitted);
            gameManager.music_Change();
        }

        //If you don't need the character grounded then get rid of this part.
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= .05f * Time.deltaTime;
        }
        moveVector = new Vector3(0, verticalVel, 0);
        controller.Move(moveVector);

        //Updater
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");


        desiredMoveDirection = new Vector3(InputX, 0, InputZ);

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * velocity);
        }
    }

    public void vo_Event(AudioClip vo_clip)
    {
        vo_Player.clip = vo_clip;
        vo_Player.Play();
    }

    public void RotateTowards(Transform t)
    {
        transform.rotation = Quaternion.LookRotation(t.position - transform.position);

    }

    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player
        if (Speed > allowPlayerRotation)
        {
            //anim.SetFloat ("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            //anim.SetFloat ("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
        }
    }
}
