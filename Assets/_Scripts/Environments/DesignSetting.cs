using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DesignSetting : MonoBehaviour
{
    public GameObject looper;
    public LooperTransparent[] allTransparentChilds;
    public List<GameObject> Loopers = new List<GameObject>();
    public int looperAmount = 9;
    public bool isAutoGenerate = false;

    [SerializeField] private TextMeshProUGUI looperAmontTxt;

    // Start is called before the first frame update
    void Start()
    {
        looperAmontTxt.text = looperAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        allTransparentChilds = GameObject.FindObjectsOfType<LooperTransparent>();
    }

    // Deactivates the transparent guide children,
    // and brings up the color panel.
    public void FinalizeDesign()
    {
        for (int i = 0; i < Loopers.Count; i++)
        {
            foreach (GameObject looper in Loopers)
            {
                looper.GetComponent<LooperDesign>().DeactivateChildren();
            }
        }

        // TODO: Switch the Amount panel with color panel.
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

    // Destroys any pre-existing Loopers and clears the list,
    // and spawns a new looper with auto generating On.
    public void AutoGenerateLoopers()
    {
        foreach (GameObject looper in Loopers)
        {
            Destroy(looper.gameObject);
        }

        Loopers.Clear();

        isAutoGenerate = true;

        Instantiate(looper, transform.position, Quaternion.Euler(0, 180, 0));
    }
}
