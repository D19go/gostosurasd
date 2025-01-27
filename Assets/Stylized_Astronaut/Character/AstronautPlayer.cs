using UnityEngine;


public class AstronautPlayer : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    public float speed = 6.0f;
    public float sprintSpeedMultiplier = 2.0f;
    public float turnSpeed = 400.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool isJumping = false;
    public float gravity = 20.0f;
    bool TabOK = true;

  

void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(TabOK){

            if (controller.isGrounded)
            {
                float currentSpeed = speed;

                if (Input.GetAxis("Fire3") != 0 && Input.GetAxis("Vertical") != 0 )
                {
                    currentSpeed *= sprintSpeedMultiplier;
                }

                moveDirection = transform.forward * Input.GetAxis("Vertical") * currentSpeed;
                isJumping = false;

                // Joystick: A
                if (Input.GetAxis("Jump") != 0)
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            if (!isJumping)
            {
                float turn = Input.GetAxis("Horizontal");
                transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            }

            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;

            if (isJumping)
            {
                anim.SetInteger("AnimationPar", 2);
            }
            if (Input.GetAxis("Vertical") != 0)
            {
                anim.SetInteger("AnimationPar", 1);
                if(Input.GetAxis("Vertical") != 0 && Input.GetAxis("Fire3") != 0 ){
                    anim.SetInteger("AnimationPar", 2);
                }else{
                    anim.SetInteger("AnimationPar", 1);
                }
            }else
            {
                anim.SetInteger("AnimationPar", 0);
            }
        }
    }
    public void invAtivo(bool tabOK){
        TabOK = tabOK;
    }

}
