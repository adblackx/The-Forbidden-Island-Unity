using System;
using System.Collections;
using System.Collections.Generic;
using Tfi;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ZoneController : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update

    private Vector3 initPos;
    private Zone zone;
    private Etat.EtatName etat = Etat.EtatName.Normale;
    
    Sprite sprite; // le sprite qu'on va load
    private Image img; // image contenant le sprite
    

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
        print(transform.position);
        print(zone.getPosition().ToString());

        
    }

    public void OnMouseUp()
    {
        print("rerer");
    }
    
    public void OnMouseDown()
    {
        Vector3 p = transform.localPosition;
        int x = (int) p.x;
        int y = (int) p.y;
        print(x+" "+ y);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On drop");
    }
}
