using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Tfi;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController: MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 initPos;
    private TresorCard.TresorCardName cardName ;
    private PanelButtonController pbc;
    public Tfi.Player p;

    public void setPlayer(Tfi.Player p)
    {
        this.p = p;
    }
    
    void Start()
    {
        initPos = transform.localPosition;
        initPos = new Vector3(initPos.x, initPos.y, 1);
        print(initPos);
    }

    public void SetCardName(TresorCard.TresorCardName cardName)
    {
        this.cardName = cardName;
    }
        
    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 1); // important pour detecter la zone

        RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.up);
      /* if (hit.collider.name == "ButPlayer1")
        {
//            print(hit.collider.name);
            
            //print("player");
            PanelButtonController pbc = hit.collider.transform.parent.transform.GetComponent<PanelButtonController>();
            pbc.showOtherPanel(0);
            print(pbc);
        }*/

        for (int i = 0; i < 4; i++)
        {
            String tag = "ButPlayer" + (i+1);
            if (hit.collider.name == tag)
            {
//            print(hit.collider.name);
            
                //print("player");
                //hit.collider.transform.GetComponent<CardController>().p
                if (i != p.GetModele().GetListPlayers().IndexOf(p))
                {
                    pbc = hit.collider.transform.parent.transform.GetComponent<PanelButtonController>();
                    pbc.setPanelActive(p.GetModele().GetListPlayers().IndexOf(p));
                    pbc.showOtherPanel(i);
                    print(pbc);
                }
                else
                {
                    print("meme joueur");
                    pbc = hit.collider.transform.parent.transform.GetComponent<PanelButtonController>();
                    pbc.showPanel();
                }

            }
        }
        
        
        Vector3 mousePos = Input.mousePosition;
        
        if (Camera.main != null)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            initPos = new Vector3(initPos.x, initPos.y, -5);

        }

        //print(transform.position);    
    }
    
    
    public void OnEndDrag(PointerEventData eventData)
    {


        
        Vector3 worldPosition1;
        //Vector3 mousePos = Input.mousePosition;
        transform.position = new Vector3(transform.position.x, transform.position.y, 1); // important pour detecter la zone

        if (Camera.main != null)
        {
            worldPosition1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition1.z = -1 * worldPosition1.z;
            print(-1*Vector2.up);
            print(Vector2.up);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition1,  -Vector2.up);
            if (hit.collider != null)
            {
                print(hit.collider.name);
                if (hit.collider.name == "ZoneNormal(Clone)(Clone)")
                {
                    //print(hit.collider.GetComponent<ZoneController>().GetZone().getPosition().ToString()); // ici je recupere un composant de la zaone
                    ZoneController zc = hit.collider.GetComponent<ZoneController>();
                    zc.onDropOn();
                    zc.onDropOnCard(cardName);
                    // il suffit alors de faire ce que tu as à faire...
                }
                    
            }
            
            print(hit.normal);
            print(hit.centroid);
           // transform.position = new Vector3(transform.position.x, transform.position.y, 10); // important pour detecter la zone
            
            
             if (hit.collider.name == "Card(Clone)(Clone)")
             {
                 print(hit.collider.name);
                 print("CARTE DONENEEEE");
                 PanelCardController p = hit.collider.transform.parent.GetComponent<PanelCardController>();
                 p.setToInitPos(); // je replace le panel à sa position initial après le drop

                 //p.transform = p.initPos;
                 /* pos.localPosition = new Vector3(pos.localPosition.x,
                      0 ,
                      pos.localPosition.z );*/


                 // pos = hit.collider.transform.parent.GetComponent<PanelCardController>();

                 /*PanelCardController p = hit.collider.transform.parent.GetComponent<PanelCardController>();
                 print( p.p.ToString());    */
             }

             if (pbc != null)
             {
                 pbc.showPanel();
             }


            transform.localPosition = initPos;
            
        }
        
       
    }
    
    public void OnMouseDown()
    {
        Vector3 p = transform.localPosition;
        int x = (int) p.x;
        int y = (int) p.y;
        //print(x+ " "+y);

    }
}
