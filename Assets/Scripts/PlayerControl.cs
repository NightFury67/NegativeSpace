using UnityEngine;
using UnityEngine.UIElements;

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
    void Start()
    {
        RBD=GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            RBD.linearVelocity= new Vector2(RBD.linearVelocity.x, JumpSpeed);
        }
    }
}
