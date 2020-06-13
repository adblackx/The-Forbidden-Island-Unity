using System;
using Tfi;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller
{
    public class PawnController: MonoBehaviour, IDragHandler, IEndDragHandler,IBeginDragHandler
    {
        public Vector3 initPos;
        public Player player;
        public static GameObject isBeingDragged; //Le prefab qui est dragg = 1 seul à la fois

        void Start()
        {
            initPos = transform.localPosition;
            initPos = new Vector3(initPos.x, initPos.y, -1);
            //print(initPos);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            isBeingDragged = gameObject;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 mousePos = Input.mousePosition;
            transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
            if (Camera.main != null)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            print(transform.position);

        
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            
            transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
            isBeingDragged = null;
            //transform.localPosition = initPos;
        
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }
    }
}