using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperTransparent : MonoBehaviour
{
    public GameObject theLooperDesign;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LooperDesign>() && this.transform.parent != other.gameObject.transform) 
        {
            gameObject.SetActive(false);
            //Debug.Log(this.gameObject.name + " : " + other.gameObject.name);
        }
    }

    

    private void OnMouseDown()
    {
        Instantiate(theLooperDesign, transform.position, transform.rotation);
    }

    

}
