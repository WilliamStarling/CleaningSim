using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrist_UI : MonoBehaviour
{
    [Header("Wrist UI Components")]
    public GameObject WristUI;
    public GameObject VirtualHand;
    public Transform SpawnPoint; // Spawn point must be setup manually

    [Header("Station Prefabs")]
    public GameObject SolventStation;
    public GameObject Photolithography;
    public GameObject Etching;
    public GameObject Deposition;

    private GameObject toBeDeleted;

    // Start is called before the first frame update
    void Start()
    {
        WristUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (VirtualHand.transform.localEulerAngles.z >= 100 && VirtualHand.transform.localEulerAngles.z <= 280)
        {
            WristUI.SetActive(true);
        }

        else
        {
            WristUI.SetActive(false);
        }
    }

    public void SpawnSolvent()
    {
        toBeDeleted = GameObject.FindGameObjectWithTag("Station");
        Destroy(toBeDeleted);

        Instantiate(SolventStation, SpawnPoint.position, SpawnPoint.rotation);
    }

    public void SpawnPhotolithography()
    {
        toBeDeleted = GameObject.FindGameObjectWithTag("Station");
        Destroy(toBeDeleted);

        Instantiate(Photolithography, SpawnPoint.position, SpawnPoint.rotation);
    }

    public void SpawnEtching()
    {
        toBeDeleted = GameObject.FindGameObjectWithTag("Station");
        Destroy(toBeDeleted);

        Instantiate(Etching, SpawnPoint.position, SpawnPoint.rotation);
    }

    public void SpawnDeposition()
    {
        toBeDeleted = GameObject.FindGameObjectWithTag("Station");
        Destroy(toBeDeleted);

        Instantiate(Deposition, SpawnPoint.position, SpawnPoint.rotation);
    }

    public void DeleteAll()
    {
        toBeDeleted = GameObject.FindGameObjectWithTag("Station");
        Destroy(toBeDeleted);
    }
}
