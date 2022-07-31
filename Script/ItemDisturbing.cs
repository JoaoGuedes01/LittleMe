﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisturbing : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("scarf");
            anim.SetTrigger("Disturbed");
        }
    }
}
