using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float jumpPower = 5.0f;
    public float shotCoolDown = 0.3f;
    private bool canShot = true;
    private bool canJump = true;

    public GameObject bullet;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public int direction = 1;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(moveSpeed * h * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
            canJump = false;
        }

        

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
            if(h < 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
        else
            animator.SetBool("isWalk", false);

        if (Input.GetMouseButtonDown(0) && canShot)
        {
            StartCoroutine(Shot());
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "left" || col.gameObject.name == "right")
        {
            animator.SetBool("isWalk", false);
        }

        if (col.gameObject.name == "Map")
            canJump = true;
    }

    IEnumerator Shot()
    {
        canShot = false;
        GameObject Scouter_Bullet = Instantiate(bullet,this.transform);
        yield return new WaitForSeconds(shotCoolDown);
        canShot = true;
    }
}