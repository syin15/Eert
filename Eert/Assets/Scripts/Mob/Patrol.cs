using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timetoFlip = 0.0f;
    [SerializeField] private float moveDistanceX;
    [SerializeField] private float moveDistanceY;
    [SerializeField] private float forceMuliplier = 2;

    private Vector3 pointA;
    private Vector3 pointB;
   
    public Rigidbody2D rb;
   


    // Start is called before the first frame update
    void Start()
    {

        pointA = rb.position;
        pointB = new Vector3(rb.position.x + moveDistanceX, rb.position.y + moveDistanceY, 0);
    }

    // Update is called once per frame
    void Update()
    { 
        Move();   
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector2 force = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force * forceMuliplier);
            Debug.Log("collided");
        }
        
    }

    void Move()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }


    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
    }
}
