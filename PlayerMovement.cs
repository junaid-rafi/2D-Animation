using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    float horizontalInput;
    float moveSpeed = 10f;
    bool isFacingRight = true;

    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

       
        FlipSprite();

 

        if(Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
        }
        else if(Input.GetKey(KeyCode.R))
        {
            anim.SetBool("isRunning", true);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJump", false);
        }

 



        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
           
        }
    }

   

}
