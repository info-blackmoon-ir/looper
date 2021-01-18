using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    [SerializeField] private string btnHexCode;
    public Color collli;

    private DesignSetting theDesignSetting;

    // Start is called before the first frame update
    void Start()
    {
        theDesignSetting = GameObject.FindObjectOfType<DesignSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        theDesignSetting.looperHexColor = btnHexCode;
    }
}
