using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNav : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpensScreen(GameObject next)
    {
        next.SetActive(true);
    }

    public void CloseScreen(GameObject self)
    {
        self.SetActive(false);
    }
}
