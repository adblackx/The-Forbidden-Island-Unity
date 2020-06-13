using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController: MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 initPos;
        
    void Start()
    {
        initPos = transform.localPosition;
        initPos = new Vector3(initPos.x, initPos.y, 1);
        print(initPos);
    }
        
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        
        if (Camera.main != null)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
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
            RaycastHit2D hit = Physics2D.Raycast(worldPosition1,  Vector2.up);
            if (hit.collider != null)
            {
                print(hit.collider.name);
                print(hit.collider.GetComponent<ZoneController>().GetZone().getPosition().ToString()); // ici je recupere un composant de la zaone
                // il suffit alors de faire ce que tu as à faire...
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
