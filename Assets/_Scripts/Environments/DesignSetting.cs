using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SaveSys;

public class DesignSetting : MonoBehaviour
{
    public GameObject looper, selectedLooper, autoGeneratePanel, colorizingPanel, finalizeDesignPanel, finalizeColoringPanel;
    public LooperTransparent[] allTransparentChilds;
    public List<GameObject> Loopers = new List<GameObject>();

    public Looper[] looperData;
    public LooperData data;

    public int looperAmount = 9;

    [SerializeField] private TextMeshProUGUI looperAmontTxt;

    // Start is called before the first frame update
    void Start()
    {
        looperAmontTxt.text = looperAmount.ToString();
        colorizingPanel.GetComponent<Animator>().SetBool("isActive", false);
        finalizeColoringPanel.GetComponent<Animator>().SetBool("isActive", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increases the amount of Loopers used for auto generating.
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

    // Decreases the amount of Loopers used for auto generating.
    public void RemoveLooper()
    {
        if (looperAmount > 3)
        {
            looperAmount--;
        }
        else
        {
            Debug.Log("Loopers at min amount");
        }
        looperAmontTxt.text = looperAmount.ToString();
    }

    // Triggers the Auto generation
    public void TriggerAutoGeneration()
    {
        Clear();

        StartCoroutine(AutoGenerateCoroutine());
    }

    // Destroys any pre-existing Loopers and clears the list,
    // and spawns a new Looper.
    public void Clear()
    {
        foreach (GameObject looper in Loopers)
        {
            Destroy(looper.gameObject);
        }

        Loopers.Clear();

        Instantiate(looper, transform.position, Quaternion.Euler(0, 180, 0));
    }

    // Starts to aoutomatically spawn Loopers.
    public IEnumerator AutoGenerateCoroutine()
    {
        yield return new WaitForSeconds(0.2f);

        

        for (int i = 1; i < looperAmount; i++)
        {
            allTransparentChilds = GameObject.FindObjectsOfType<LooperTransparent>();

            int randomIndex = Random.Range(0, allTransparentChilds.Length);

            GameObject go = Instantiate(looper,
                allTransparentChilds[randomIndex].transform.position,
                Quaternion.Euler(0, allTransparentChilds[randomIndex].transform.eulerAngles.y + 180,
                allTransparentChilds[randomIndex].transform.eulerAngles.z));

            go.transform.rotation = Quaternion.Euler(0, 180, go.transform.rotation.eulerAngles.z);

            yield return new WaitForSeconds(0.2f);

            if (i == looperAmount - 1)  
            {
                FinalizeDesign();
            }
        }

    }

    // Deactivates the transparent guide children,
    public void FinalizeDesign()
    {
        allTransparentChilds = GameObject.FindObjectsOfType<LooperTransparent>();

        foreach (LooperTransparent child in allTransparentChilds)
        {
            child.gameObject.SetActive(false);
        }

    }

    // TODO: Switch the Amount panel with color panel.
    public void SetUpColoringPanel()
    {
        FinalizeDesign();

        finalizeDesignPanel.GetComponent<Animator>().SetBool("isActive", false);
        finalizeColoringPanel.GetComponent<Animator>().SetBool("isActive", true);

        autoGeneratePanel.GetComponent<Animator>().SetBool("isActive", false);
        colorizingPanel.GetComponent<Animator>().SetBool("isActive", true);

    }

    public void SetUpDesigningPanel()
    {
        foreach (GameObject looper in Loopers)
        {
            looper.GetComponent<LooperDesign>().ActivateChildren();
        }

        finalizeDesignPanel.GetComponent<Animator>().SetBool("isActive", true);
        finalizeColoringPanel.GetComponent<Animator>().SetBool("isActive", false);

        autoGeneratePanel.GetComponent<Animator>().SetBool("isActive", true);
        colorizingPanel.GetComponent<Animator>().SetBool("isActive", false);
    }

    public void Color(string hexColor)
    {
        Color color;

        if (ColorUtility.TryParseHtmlString("#" + hexColor, out color))
        {
            selectedLooper.GetComponent<MeshRenderer>().materials[1].SetColor("_Color", color);
            selectedLooper.GetComponent<LooperDesign>().hexColorCode = hexColor;
        }

    }

    public void SaveLoopers()
    {

        //looperData[0].Number = 0;
        //looperData[0].Xvalue = Loopers[0].transform.position.x;
        for (int i = 0; i < Loopers.Count; i++)
        {

            looperData[i].Number = i;
            looperData[i].Xvalue = Loopers[i].transform.position.x;
            looperData[i].Yvalue = Loopers[i].transform.position.y;
            looperData[i].ZValue = Loopers[i].transform.position.z;
            looperData[i].ZRotation = Loopers[i].transform.rotation.eulerAngles.z;
            looperData[i].HexCode = Loopers[i].GetComponent<LooperDesign>().hexColorCode;
        }

        SaveSystem.SaveData(looperData, "Looper");

        LoadaLooper();

    }

    public void LoadaLooper()
    {
        data = SaveSystem.LoadData("Looper");
        //Looper[]  LooperData = data.loopers;
        Debug.Log(data.loopers[1].Xvalue);
    }
    
}
