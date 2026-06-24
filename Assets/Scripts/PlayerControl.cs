using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MoveSpeed=5f;
    public float JumpSpeed = 10f;
    public Transform grounddetector;
    private float detectrad = 0.1f;
    public LayerMask groundlayer;
    public Rigidbody2D RBD;
    private bool isGrounded;
    void Start()
    {
        RBD=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckGround();
        Jump();
    }

    void Movement()
    {
        Vector2 move=Vector2.zero;
        float input = Input.GetAxisRaw("Horizontal");
        move.x = MoveSpeed * input;
        RBD.linearVelocity=new Vector2(move.x, RBD.linearVelocity.y);
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
