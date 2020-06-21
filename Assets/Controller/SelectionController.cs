using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Tfi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continuer()
    {
        print("continuer");
        /*Transform child = transform.Find("Ingénieur");
        print(child.GetComponent<Toggle>().isOn);*/
        
        
        Island modele = new Island();
        mainMenuController.modele = modele;
        List<Zone> safeZones = modele.GetRandomSafeZone(6);
        int compteur = 0;

        foreach (Transform eachChild in transform) {
            print(eachChild.name);
            
            if (eachChild.name != "Continuer" && eachChild.GetComponent<Toggle>().isOn)
            { // try possible ici.....

                    Type type =  Type.GetType("Tfi."+eachChild.name);
                    String imageURL = "uselessParameter..."; //On Pourrait peut être modifier pour passer le prefabs si besoin

                    object p1 = Activator.CreateInstance(type,safeZones[compteur],imageURL, modele);
                    modele.GetListPlayers().Add((Player)p1);
                    
                    compteur++;
                    //addPlayerPrefabs(p);
            }

        }
        
        if(compteur>0 && compteur<=4)
        SceneManager.LoadScene("SampleScene");
        
        
        
    }

    public void Toggle()
    {
        print("Toggle");

    }
}
