using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power = 3.0f;
    public GameObject bullet;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Player").GetComponent<PlayerCtrl>().direction;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(power*direction, 0), ForceMode2D.Impulse);
        if (direction == -1)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Map")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().hit();
            Destroy(gameObject);
        }
    }
}
