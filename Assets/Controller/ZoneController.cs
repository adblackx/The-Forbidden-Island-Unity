﻿using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Tfi;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ZoneController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 initPos;
    private Zone zone;
    private Etat.EtatName etat = Etat.EtatName.Normale;
    private float tileSize = 150f; // taille des prefabs
    private Island modele;
    
    Sprite sprite; // le sprite qu'on va load
    private Image img; // image contenant le sprite


    public void SetModele(Island modele)
    {
        this.modele = modele;
    }
    public void SetZone(Zone z)
    {
        this.zone = z;
    }
    
    public Zone GetZone()
    {
        return this.zone ;
    }

    void Start()
    {
        initPos = transform.localPosition;
        initPos = new Vector3(initPos.x, initPos.y, 0);
        
        /*if (zone.isHeliport())
            
            transform.GetChild(2).transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/heliport");
        else
            transform.GetChild(2).transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(Etat.getSpritePath(etat));*/


    }



    // Update is called once per frame
    void Update()
    {
        
        if (zone.getEtat() != etat){ // ici je teste si on a un changement d'état, puis si c'est le cas, alors je change d'état, et je met à jour mon sprite
            etat = zone.getEtat();
            sprite = Resources.Load<Sprite>(Etat.getSpritePath(etat));
            img = GetComponent<Image>();
            img.sprite = sprite;
            


            
        }
        
        Artefacts.ArtefactsName a = zone.getArtefacts();
        if(a != Artefacts.ArtefactsName.None)
        transform.GetChild(0).transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(Artefacts.getSpritePath(a));
        else
        {
            transform.GetChild(0).transform.GetComponent<Image>().enabled = false;

        }

        if (modele.getRoundOf().zonesSafeToMove().Contains(zone))
        {
            transform.GetChild(1).transform.GetComponent<Image>().enabled = true;
        }else
            transform.GetChild(1).transform.GetComponent<Image>().enabled = false;


        if (zone.isHeliport())
            
            transform.GetChild(2).transform.GetComponent<Image>().enabled =true ;
        else
            transform.GetChild(2).transform.GetComponent<Image>().enabled =false ;

        /*if (Input.GetMouseButtonDown(0))
        { // finalement inutile grâce au boxcollider
            print("click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "MyObjectName")
                {
                    print("My object is clicked by mouse");
                }
            }
        }*/


    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        
        if (Camera.main != null)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        //print(transform.position);
        //print(zone.getPosition().ToString());

        
    }

    public void OnMouseUp()
    {
        //print("rerer");
    }

    public Vector3 LocalPosPawn()
    {
        int res = 0;
        foreach (Player p in modele.GetListPlayers())
            if (p.getZone() == zone)
                res++;
        switch (res)
        {
            case 0:
                return new Vector3(-tileSize*3  + zone.getX()*tileSize + tileSize*0.25f, 
                    tileSize*3 - (zone.getY())*tileSize - tileSize*0.25f,100);
            case 1:
                return new Vector3(-tileSize*3  + zone.getX()*tileSize + tileSize*0.25f*3, 
                    tileSize*3 - (zone.getY())*tileSize - tileSize*0.25f,100);
            case 2:
                return new Vector3(-tileSize*3  + zone.getX()*tileSize + tileSize*0.25f, 
                    tileSize*3 - (zone.getY())*tileSize - tileSize*0.25f*3,100);
            default:
                return new Vector3(-tileSize*3  + zone.getX()*tileSize + tileSize*0.25f*3, 
                    tileSize*3 - (zone.getY())*tileSize - tileSize*0.25f*3,100);
        }
    }
    
    public void OnMouseDown()
    {
        // finalement inutile grâce au boxcollider
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.up);
        
        print(hit.collider.name);*/
        
        print("onMouseDown");
        Player player = modele.getRoundOf();

        List<Zone> listZones = player.zonesDrainable();
        if(listZones.Contains(zone) && player.canAct() && zone.isFlooded()){ // on fait le drain water ici
            player.drainWaterZone(zone);
            player.addAction();
            //Update();
        }
        else
            print("Mouvement interdit");
    }

    public void onDropOn()
    {//fonction appelé par la méthode du rayCast
        print("onDropOn");
        print(GetZone().getPosition().ToString());
        
    }
    
    public void onDropOnCard(TresorCard.TresorCardName cardName)
    {//fonction appelé par la méthode du rayCastv des cartes
        //print("onDropOnCard");
        print(cardName.ToString());
        print(GetZone().getPosition().ToString());
        
    }
    
    
}
