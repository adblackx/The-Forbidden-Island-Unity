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
        private Transform startParent;

        void Start()
        {
            initPos = transform.localPosition;
            initPos = new Vector3(initPos.x, initPos.y, -1);
            //print(initPos);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //startParent = transform.parent;
            //transform.SetParent(transform.parent.parent);
            isBeingDragged = gameObject;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 mousePos = Input.mousePosition;
            //transform.GetComponent<CanvasGroup>().blocksRaycasts = false; // a commentter pour l'autre méthode
        
            if (Camera.main != null)
            { // même chose que toi donc à ne pas modifier
                //print("camera");
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(transform.position.x, transform.position.y,100);
                
                //print("postion : " + transform.position);
                //print("localPostion : " + transform.localPosition);

            }


        
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {

            //transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
            isBeingDragged = null;
            //transform.SetParent(startParent);
            //transform.localPosition = initPos;

            
            // second version             
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,-100);

            if (Camera.main != null)
            {
                Vector3 worldPosition1;

                worldPosition1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition1.z = -1 * worldPosition1.z;
                //print(-1*Vector2.up);
                //print(Vector2.up);
                RaycastHit2D hit = Physics2D.Raycast(transform.position,  -Vector2.up);
                if (hit.collider != null)
                {
                    print(hit.collider.name);
                    if (hit.collider.name != "Card(Clone)(Clone)")
                    {
                        //print(hit.collider.GetComponent<ZoneController>().GetZone().getPosition().ToString()); // ici je recupere un composant de la zaone
                        ZoneController zc = hit.collider.GetComponent<ZoneController>();
                        zc.onDropOn();
                        // il suffit alors de faire ce que tu as à faire...
                    }
                    
                }

                transform.localPosition = initPos;
            
            }

        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }
    }
}