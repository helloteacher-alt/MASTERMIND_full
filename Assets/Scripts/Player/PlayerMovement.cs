using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    
    public CharacterController charactercontroller;
    PlayerAction playerAction;
    public Transform cam;

    CinemachineFreeLook camfree;
    public Transform followPosition;

    PhotonView view;

    public float speed = 6.0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Start()
    {
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        camfree = GameObject.FindWithTag("ThirdPersonCam").GetComponent<CinemachineFreeLook>();
        charactercontroller = GetComponent<CharacterController>();
        playerAction = GetComponent<PlayerAction>();
        cam = GameObject.FindWithTag("MainCamera").transform;
        
        view = GetComponent<PhotonView>();

        if(view.IsMine){
            charactercontroller.enabled = true;
            playerAction.enabled = true;
        }
    }

    void Move(){
        if(Input.GetAxisRaw("Horizontal") != 0){
                Debug.Log("Test");
            }
    }

    void Update()
    {
        if(view.IsMine){
            followPosition = transform.Find("FollowTarget");
            // camfree.enabled = true;
            camfree.Follow = followPosition;
            camfree.LookAt = followPosition;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
        
            Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

            if(direction.magnitude >= 0.1f){
                float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.localEulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.localRotation = Quaternion.Euler(0f,angle,0f);

                Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
                charactercontroller.Move(moveDir.normalized*speed*Time.deltaTime);
                animator.SetBool("Running",true);
            }
            else
            {
                animator.SetBool("Running",false);
            }
        }
        else{
            charactercontroller.enabled = false;
            this.gameObject.tag = "OtherPlayer";
            //  camfree.enabled = false;
        }
    }

    
}
