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
        initPos = new Vector3(initPos.x, initPos.y, 0);
        print(initPos);
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


        
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        if (Camera.main != null)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.localPosition = initPos;
        }
        
    }
    
    public void OnMouseDown()
    {
        Vector3 p = transform.localPosition;
        int x = (int) p.x;
        int y = (int) p.y;
        print(x+ " "+y);
        
    }
}
