using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float MoveSpeed=5f;
    [SerializeField] private float JumpSpeed = 10f;
    [SerializeField] private Transform grounddetector;
    private float detectrad = 0.1f;
    [SerializeField] private LayerMask groundlayer;
    private Rigidbody2D RBD;
    private bool isGrounded;
    [SerializeField] private float Airdeccelration = 1f;
    [SerializeField] private float Grounddeccelration = 5f;

    //public float Playerposition;
    void Start()
    {
        RBD=GetComponent<Rigidbody2D>();
        if (SessionData.ReturningFromNegativeSpace == true && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main-Cave")
        {
            transform.position = SessionData.ReturnPosition;
            SessionData.ReturningFromNegativeSpace = false;
            //Debug.Log("ReturningFromNegativeSpace: " + SessionData.ReturningFromNegativeSpace);
            //Debug.Log("ReturnPosition: " + SessionData.ReturnPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement();
        CheckGround();
        Jump();
    }

    void horizontalMovement()
    {
        if (Dialoguemanager.instance.IsDialogueActive())
        {
            RBD.linearVelocity = new Vector2(0, 0);
            return;
        }

            float input = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float currentdeccelration;
        if (isGrounded)
        {
            currentdeccelration =Grounddeccelration;
        }
        else
        {
            bool isMoving =Mathf.Abs(input)> 0.01f;
            currentdeccelration= isMoving?Grounddeccelration : Airdeccelration;
        }

        float smoothvel= Mathf.Lerp(RBD.linearVelocity.x, input, currentdeccelration*Time.fixedDeltaTime);
        RBD.linearVelocity= new Vector2(smoothvel, RBD.linearVelocity.y);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(grounddetector.position, detectrad, groundlayer);
    }

    void Jump()
    {
        if (Dialoguemanager.instance.IsDialogueActive()) return;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            RBD.linearVelocity= new Vector2(RBD.linearVelocity.x, JumpSpeed);
        }
    }

    
}
