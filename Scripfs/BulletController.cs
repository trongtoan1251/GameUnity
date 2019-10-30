using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;
    private Vector3 fireForce = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.AddForce(fireForce*gameObject.transform.localScale.x);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            anim.SetTrigger("bang");
            rigid.velocity = Vector3.zero;
            Destroy(this.gameObject, 1);
        }
    }
    /*  {
          
      }*/
}
