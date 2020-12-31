using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DesignSetting : MonoBehaviour
{
    public List<GameObject> Loopers = new List<GameObject>();
    public int looperAmount = 9;

    [SerializeField] private TextMeshProUGUI looperAmontTxt;

    // Start is called before the first frame update
    void Start()
    {
        looperAmontTxt.text = looperAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLooper()
    {
        if (looperAmount < 20)
        {
            looperAmount++;
        }
        else
        {
            Debug.Log("Loopers at max amount");
        }
        looperAmontTxt.text = looperAmount.ToString();
    }

    public void RemoveLooper()
    {
        if (looperAmount > 1) 
        {
            looperAmount--;
        }
        else
        {
            Debug.Log("Loopers at min amount");
        }
        looperAmontTxt.text = looperAmount.ToString();
    }
}
