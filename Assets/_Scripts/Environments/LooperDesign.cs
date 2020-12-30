using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperDesign : MonoBehaviour
{
    [SerializeField] private GameObject looper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiate( Transform transform)
    {


        Instantiate(looper, transform.position, transform.rotation);
    }
}
