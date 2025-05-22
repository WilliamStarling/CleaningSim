using Meta.XR.Editor.Tags;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLabels : MonoBehaviour
{
    GameObject[] taggedObjects;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        HideLabels();
    }

    private void Init()
    {
        taggedObjects = GameObject.FindGameObjectsWithTag("Label");
    }

    public void HideLabels()
    {
        foreach (GameObject taggedObject in taggedObjects)
        {
            taggedObject.SetActive(false);
        }
    }

    public void ShowLabels()
    {
        foreach (GameObject taggedObject in taggedObjects)
        {
            taggedObject.SetActive(true);
        }
    }
}
