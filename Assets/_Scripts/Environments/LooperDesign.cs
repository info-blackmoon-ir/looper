using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperDesign : MonoBehaviour
{
    [SerializeField] private GameObject[] myTransparentChilds;

    private DesignSetting theDesignSetting;

    public Material red;

    // Start is called before the first frame update
    void Start()
    {
        theDesignSetting = GameObject.FindObjectOfType<DesignSetting>();
        theDesignSetting.Loopers.Add(this.gameObject);

        for (int i = 0; i < myTransparentChilds.Length; i++)
        {
            myTransparentChilds[i].SetActive(true);
        }

        this.gameObject.GetComponent<MeshRenderer>().materials[1].SetColor("_Color", Color.white);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        theDesignSetting.selectedLooper = this.gameObject;
    }

}
