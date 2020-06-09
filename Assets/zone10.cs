using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class zone10 : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update

    private Vector3 initPos;
    
    void Start()
    {
<<<<<<< HEAD
        print("Romain");
=======
        print("ererer");
>>>>>>> 3fd66efa0593784b5b222cd10748710d985a8477
        initPos = transform.localPosition;
        initPos = new Vector3(initPos.x, initPos.y, 0);
        print(initPos);
    }


    // Update is called once per frame
    void Update()
    {
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
