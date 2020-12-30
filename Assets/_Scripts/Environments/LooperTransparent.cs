using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperTransparent : MonoBehaviour
{
    private LooperDesign theLooperDesign;

    // Start is called before the first frame update
    void Start()
    {
        theLooperDesign = GameObject.FindObjectOfType<LooperDesign>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        //if (col.getcomponent<looperdesign>())
        //{
        //    this.gameobject.setactive(false);
        //}
        print("olde");
    }

    private void OnMouseDown()
    {
        theLooperDesign.Instantiate(this.transform);

    }

}
