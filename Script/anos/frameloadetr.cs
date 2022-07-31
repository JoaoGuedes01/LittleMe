using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameloadetr : MonoBehaviour
{
    public GameObject frame1, frame2, character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (frame1.active == true)
            {
                frame1.SetActive(false);
                frame2.SetActive(true);

            }
            else if (frame1.active == false)
            {
                frame1.SetActive(true);
                frame2.SetActive(false);
            }
        }

    }
}
