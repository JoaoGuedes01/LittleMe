using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionButton : MonoBehaviour
{
    public Transform button;
    public GameObject continueButton, objeto;
    public Animator transition;
    private Animator anim;
    private bool isInsideArea;
    private bool canE;
    public bool gameend;
    EventSystem evt;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = button.GetComponent<Animator>();
        evt = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        canE = FindObjectOfType<DialogueManager>().canE;
        
        if (isInsideArea == true && Input.GetKeyDown(KeyCode.E) && canE == true && score.scoreValue>=6)
        {
            Debug.Log("Game is over, congrats kiddo");
            transition.SetTrigger("end");
            evt.SetSelectedGameObject(continueButton);
        }
        else if (isInsideArea == true && Input.GetKeyDown(KeyCode.E) && canE == true)
        {
            objeto.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("enter");
            anim.SetTrigger("isHover");
            isInsideArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("exit");
            anim.SetTrigger("isNotHover");
            isInsideArea = false;
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("start");
        //wait
        yield return new WaitForSeconds(1f);

    }


    public void endthegame() 
    {
        Application.Quit();
    }

}
