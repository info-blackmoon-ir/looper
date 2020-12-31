using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperTransparent : MonoBehaviour
{
    public GameObject looper;


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
        }
    }



    private void OnMouseDown()
    {
        Instantiate(looper, transform.position, transform.rotation);
    }



}
