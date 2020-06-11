using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ZoneController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 initPos;
    
    void Start()
    {
        initPos = transform.localPosition;
        initPos = new Vector3(initPos.x, initPos.y, 0);
        print(initPos);
    }


    // Update is called once per frame
    void Update()
    {
    }
    

    public void OnMouseDown()
    {
        Vector3 p = transform.localPosition;
        int x = (int) p.x;
        int y = (int) p.y;
        
    }
}
