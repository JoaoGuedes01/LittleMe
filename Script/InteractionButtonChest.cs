using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionButtonChest : MonoBehaviour
{

    public Animator InteractionButton,popUp;
    public GameObject continueButton,character;
    public Image items;
    private bool isInsideArea=false, canE=true;
    public Sprite newsprite;
    
    EventSystem evt;
    // Start is called before the first frame update
    void Start()
    {
        evt = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideArea == true && Input.GetKeyDown(KeyCode.E)&& canE == true)
        {
            canE = false;
            popUp.SetBool("Open", true);
            evt.SetSelectedGameObject(continueButton);
            character.GetComponent<PlayerMovement>().SetCanAttack(true);
            items.sprite = newsprite;
        }
    }

    public void closePrompt() 
    {
        popUp.SetBool("Open", false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("enter");
            InteractionButton.SetTrigger("isHover");
            isInsideArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("exit");
            InteractionButton.SetTrigger("isNotHover");
            isInsideArea = false;
        }
    }

}
