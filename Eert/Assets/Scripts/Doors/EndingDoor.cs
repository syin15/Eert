using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingDoor : MonoBehaviour
{
    private bool hasCollided = false;
    private bool roundTwo = false;
    public GameObject instruction;

    [SerializeField] private bool isDoorInRoundTwo = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hasCollided)
        {
            instruction.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!isDoorInRoundTwo)
                {
                    SceneManager.LoadScene("Round 2");
                    isDoorInRoundTwo = true;
                }
                else SceneManager.LoadScene("End_Scene");
            }
        }
        else
        {
           // instruction.SetActive(false);
        }

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasCollided = true;
            Debug.Log("Ending Door");

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasCollided = false;
            Debug.Log("Leaving door");
        }
    }
}
