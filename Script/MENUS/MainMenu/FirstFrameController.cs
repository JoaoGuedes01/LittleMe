using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FirstFrameController : MonoBehaviour
{
    public GameObject buttons, parteCima, Panels2, Buttons2 , SecondFrame, saveSlot1 , newGameButton;
    private Animator animbuttons, parteCimaanim, Panels2anim, Buttons2anim;
    public Animator transition;
    EventSystem evt;
    private int WhatFrameisThis=0;
    void Start()
    {
        Panels2anim = Panels2.GetComponent<Animator>();
        Buttons2anim = Buttons2.GetComponent<Animator>();
        evt = EventSystem.current;
        animbuttons = buttons.GetComponent<Animator>();
        parteCimaanim = parteCima.GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // new Game Window

        if (WhatFrameisThis == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenFrame1();
                CloseFrame2();
            }
        }
        // Load Game Window
        else if (WhatFrameisThis==2)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenFrame1();
                CloseFrame3();
            }
        }
    }

    public void NewGame() 
    {
        Debug.Log("New Game");
        CloseFrame1();
        OpenFrame2();
        WhatFrameisThis = 1;
    }
   public void LoadGame()
    {
        Debug.Log("Load Game");
        CloseFrame1();
        OpenFrame3();
        WhatFrameisThis = 2;
    }
   public void Options()
    {
        Debug.Log("Options");
        CloseFrame1();
    }
   public void Quit()
    {
        Debug.Log("Quit");
        CloseFrame1();
        Application.Quit();
    }

    // Botao de uma save
    public void NewGameSaveSlot() 
    {
        if (WhatFrameisThis == 1)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else if (WhatFrameisThis == 2)
        {
            Debug.Log("slot selected to load");
        }
        
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        //Play animation
        transition.SetTrigger("start");
        //wait
        yield return new WaitForSeconds(1f);
        //load scene
        SceneManager.LoadScene(levelIndex);
    }


    //abrir o menu inicial
    public void OpenFrame1()
    {
        animbuttons.SetTrigger("open");
        parteCimaanim.SetTrigger("open");
        WhatFrameisThis = 0;
        evt.SetSelectedGameObject(newGameButton);
    }

    //fechar o menu inicial
    void CloseFrame1() 
    {
        animbuttons.SetTrigger("close");
        parteCimaanim.SetTrigger("close");
    }


    //abrir o menu das saves para um new game
    void OpenFrame2() 
    {
        SecondFrame.SetActive(true);
        Panels2anim.SetTrigger("open");
        Buttons2anim.SetTrigger("open");
        evt.SetSelectedGameObject(saveSlot1);
    }

    //fechar o menu das saves para um new game
    void CloseFrame2() 
    {
        Panels2anim.SetTrigger("close");
        Buttons2anim.SetTrigger("close");
    }

    //Abrir o menu das saves para um load game
    void OpenFrame3()
    {
        SecondFrame.SetActive(true);
        Panels2anim.SetTrigger("open");
        Buttons2anim.SetTrigger("open");
        evt.SetSelectedGameObject(saveSlot1);
    }

    //fechar o menu das saves para um load game
    void CloseFrame3()
    {
        Panels2anim.SetTrigger("close");
        Buttons2anim.SetTrigger("close");
    }







}
