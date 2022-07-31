using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public GameObject character;
    private bool isondoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (isondoor==true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Door Opened");
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("enter");
            isondoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("exit");
            isondoor = false;
        }
    }


}
