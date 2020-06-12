using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller
{
    public class PawnController: MonoBehaviour, IDragHandler, IEndDragHandler
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
    }
}