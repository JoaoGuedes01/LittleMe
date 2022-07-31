using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    // Queue = FIFO
    private Queue<string> sentences;
    public TextMeshProUGUI nameText, dialogueMessage;
    public Animator anim, animbutton;
    private int tamanho;
    EventSystem evt;
    public GameObject continueButton;
    public bool canE;
    // Start is called before the first frame update
    void Start()
    {
        evt = EventSystem.current;
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue, int size) 
    {
        canE = false;
        tamanho = size;
        anim.SetBool("open",true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (tamanho == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        tamanho = tamanho - 1;
        StopAllCoroutines();
        StartCoroutine(TypeSentece(sentence));
        evt.SetSelectedGameObject(continueButton);
    }

    IEnumerator TypeSentece(string sentence) 
    {
        dialogueMessage.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueMessage.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() 
    {
        canE = true;
        anim.SetBool("open",false);
        Debug.Log("End of conversation");
    }
}
