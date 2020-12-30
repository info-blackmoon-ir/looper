using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperDesign : MonoBehaviour
{
    [SerializeField] private GameObject looper;
    public GameObject[] mychilds;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mychilds.Length; i++)
        {
            mychilds[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiate( Transform transform)
    {


        
    }
}
