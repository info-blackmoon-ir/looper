using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooperDesign : MonoBehaviour
{
    [SerializeField] private GameObject[] myTransparentChilds;

    private DesignSetting theDesignSetting;

    // Start is called before the first frame update
    void Start()
    {
        theDesignSetting = GameObject.FindObjectOfType<DesignSetting>();
        theDesignSetting.Loopers.Add(this.gameObject);

        for (int i = 0; i < myTransparentChilds.Length; i++)
        {
            myTransparentChilds[i].SetActive(true);
        }

        if (theDesignSetting.Loopers.Count <= theDesignSetting.looperAmount && theDesignSetting.isAutoGenerate)
        {
            StartCoroutine(AutoSpawnCoroutine());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Deactivates all its child transparent Loopers/
    public void DeactivateChildren()
    {
        for (int i = 0; i < myTransparentChilds.Length; i++)
        {
            myTransparentChilds[i].SetActive(false);
        }
    }

    // Each Looper Spawns the next one in a random position
    private IEnumerator AutoSpawnCoroutine()
    { 
        yield return new WaitForSeconds(0.1f);

        if (theDesignSetting.Loopers.Count == theDesignSetting.looperAmount)
        {
            theDesignSetting.isAutoGenerate = false;
            theDesignSetting.FinalizeDesign();
        }
        else
        {
            int randomIndex = Random.Range(0, theDesignSetting.allTransparentChilds.Length);

            GameObject go = Instantiate(theDesignSetting.looper,
                theDesignSetting.allTransparentChilds[randomIndex].transform.position,
                Quaternion.Euler(0, theDesignSetting.allTransparentChilds[randomIndex].transform.eulerAngles.y + 180,
                theDesignSetting.allTransparentChilds[randomIndex].transform.eulerAngles.z));

            go.transform.rotation = Quaternion.Euler(0, 180, go.transform.rotation.eulerAngles.z);
        }




    }

}
