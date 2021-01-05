using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSys;

public class LooperSpawner : MonoBehaviour
{
    public List<Looper> loadedLooper = new List<Looper>();

    [SerializeField] private GameObject looper;
    [SerializeField] private Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        LoadLoopers();

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLoopers()
    {
        int c = SaveSystem.LoadConfig("Looper");

        for (int i = 0; i < c; i++)
        {
            loadedLooper.Add(SaveSystem.LoadData("Looper", i.ToString()));
        }

        SpawnLoopers();
    }

    public void SpawnLoopers()
    {
        for (int i = 0; i < loadedLooper.Count; i++)
        {
            GameObject go = Instantiate(looper, this.transform);
            go.transform.position = new Vector3(loadedLooper[i].Xvalue, loadedLooper[i].Yvalue, loadedLooper[i].ZValue);
            go.transform.rotation = Quaternion.Euler(0, 180, loadedLooper[i].ZRotation);

            string hexColor = loadedLooper[i].HexCode;

            Color color;

            if (ColorUtility.TryParseHtmlString("#" + hexColor, out color))
            {
                go.GetComponent<MeshRenderer>().materials[1].SetColor("_Color", color);
            }
        }

        this.transform.position = parentTransform.position;
        this.transform.rotation = parentTransform.rotation;
        this.transform.localScale = parentTransform.localScale;
    }
}
