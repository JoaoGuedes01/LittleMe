using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text dn;
    // Start is called before the first frame update
    void Start()
    {
        dn = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dn.text = "Dead Niggas :" + scoreValue; 
    }
}
