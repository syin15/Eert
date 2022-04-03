using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{

    [SerializeField] private float timeToBreak;
    [SerializeField] private float currentTime = 0.0f;
    private bool hasCollided = false;

    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= timeToBreak)
        {
            SoundManagerScript.PlaySound("doorBreak");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (hasCollided)
        {
            currentTime += Time.fixedDeltaTime;
            animator.SetBool("hasCollided", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!hasCollided) SoundManagerScript.PlaySound("door");
            hasCollided = true;
        }
    }
}
