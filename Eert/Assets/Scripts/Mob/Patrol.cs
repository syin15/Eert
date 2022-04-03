using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timetoFlip = 0.0f;
    [SerializeField] private float moveDistanceX;
    //[SerializeField] private float moveDistanceY;
    [SerializeField] private float forceMuliplier = 2;

    private Vector2 pointA;
    private Vector2 pointB;
    private bool m_FacingRight = true;

    public Rigidbody2D rb;
    public Animator animator;
   


    // Start is called before the first frame update
    void Start()
    {

        pointA = rb.position;
        pointB = new Vector2(rb.position.x + moveDistanceX, rb.position.y);
    }

    // Update is called once per frame
    void Update()
    { 
        Move();   
        
        //if(Vector2.Distance(gameObject.transform.position, pointB)  == 0 || Vector2.Distance(gameObject.transform.position, pointA) == 0 )
        //{
        //    Flip();
        //}
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
        //Vector3 temp = Vector3.Lerp(pointA, pointB, time);
        //transform.Translate(Vector2.right * speed * Time.deltaTime);


        Debug.Log(Vector3.Distance(transform.position, pointB));
        if(Vector3.Distance(transform.position, pointB) < 0.3 && m_FacingRight)
        {
            Flip();
            m_FacingRight = false;
        }

        if (Vector3.Distance(transform.position, pointA) < 0.3 && !m_FacingRight)
        {
            Flip();
            m_FacingRight = true;
        }




    }


    void Flip()
    {


        Debug.Log("flip");
        //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        //speed *= -1;
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
