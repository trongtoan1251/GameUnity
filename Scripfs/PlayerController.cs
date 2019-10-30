using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;
    [SerializeField] GameObject bullets;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && onGround)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("move", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("move", false);
        }
        if (anim.GetBool("move"))
        {
            if (movingRight)
            {
                transform.position += Vector3.right * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }
    private bool onGround=true;
    private Vector3 jumpForce = new Vector3(0, 8000, 0);
    private bool movingRight;
    private void Jump()
    {
        rigid.AddForce(jumpForce);
        anim.SetTrigger("jump");
    }
    private void Move(bool isRight)
    {
        anim.SetBool("move", true);
        if (isRight)
        {
            transform.localScale = Vector3.right;
            movingRight = true;
        }
        else
        {
            transform.localScale = Vector3.left;
            movingRight = false;
        }
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        var bullet = Instantiate(bullets);
        bullet.transform.position = gameObject.transform.position +Vector3.down;
        bullet.transform.localScale = gameObject.transform.localScale;
        Destroy(bullet, 10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            onGround = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            onGround = false;
        }
    }
}
