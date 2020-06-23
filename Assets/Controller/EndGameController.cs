using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Tfi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class EndGameController: MonoBehaviour
{
    public static Transform MyText;
    public static String message; 
    
    void Start()
    {
        DisplayMEssage();
    }

    // Update is called once per frame

    
    
    public void onButtonClick()
    {
        SceneManager.LoadScene("menu");
    }

    public void DisplayMEssage()
    {
        MyText = this.gameObject.GetComponent<Transform>().Find("message");
        MyText.GetComponent<Text>().text = (message);
        
    }
}
