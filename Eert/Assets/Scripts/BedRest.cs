using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BedRest : MonoBehaviour
{
    private bool inRange = false;
    public GameObject instruction;
    public GameObject menuButtons;

    // Start is called before the first frame update
    void Start()
    {
        //if (instruction) instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            instruction.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                if(menuButtons != null)
                {
                    menuButtons.SetActive(false);
                }
            }
        }
        else
        {
            //instruction.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
            Debug.Log("Trigger Enter");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            Debug.Log("Trigger Exit");
        }
    }


}
