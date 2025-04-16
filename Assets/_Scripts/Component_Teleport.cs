using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component_Teleport : MonoBehaviour
{
    public GameObject Acetone;
    public GameObject Isopropyl;
    public GameObject Methanol;
    public GameObject AirHose;

    private float Rot_Acetone_X;
    private float Rot_Acetone_Y;
    private float Rot_Acetone_Z;
    private float Pos_Acetone_X;
    private float Pos_Acetone_Y;
    private float Pos_Acetone_Z;

    private float Rot_Methanol_X;
    private float Rot_Methanol_Y;
    private float Rot_Methanol_Z;
    private float Pos_Methanol_X;
    private float Pos_Methanol_Y;
    private float Pos_Methanol_Z;

    private float Rot_Isopropyl_X;
    private float Rot_Isopropyl_Y;
    private float Rot_Isopropyl_Z;
    private float Pos_Isopropyl_X;
    private float Pos_Isopropyl_Y;
    private float Pos_Isopropyl_Z;

    private float Rot_Hose_X;
    private float Rot_Hose_Y;
    private float Rot_Hose_Z;
    private float Pos_Hose_X;
    private float Pos_Hose_Y;
    private float Pos_Hose_Z;

    private void Start()
    {
        Pos_Acetone_X = Acetone.transform.position.x;
        Pos_Acetone_Y = Acetone.transform.position.y;
        Pos_Acetone_Z = Acetone.transform.position.z;
        Rot_Acetone_X = Acetone.transform.rotation.x;
        Rot_Acetone_Y = Acetone.transform.rotation.y;
        Rot_Acetone_Z = Acetone.transform.rotation.z;

        Pos_Isopropyl_X = Isopropyl.transform.position.x;
        Pos_Isopropyl_Y = Isopropyl.transform.position.y;
        Pos_Isopropyl_Z = Isopropyl.transform.position.z;
        Rot_Isopropyl_X = Isopropyl.transform.rotation.x;
        Rot_Isopropyl_Y = Isopropyl.transform.rotation.y;
        Rot_Isopropyl_Z = Isopropyl.transform.rotation.z;

        Pos_Methanol_X = Methanol.transform.position.x;
        Pos_Methanol_Y = Methanol.transform.position.y;
        Pos_Methanol_Z = Methanol.transform.position.z;
        Rot_Methanol_X = Methanol.transform.rotation.x;
        Rot_Methanol_Y = Methanol.transform.rotation.y;
        Rot_Methanol_Z = Methanol.transform.rotation.z;

        Pos_Hose_X = AirHose.transform.position.x;
        Pos_Hose_Y = AirHose.transform.position.y;
        Pos_Hose_Z = AirHose.transform.position.z;
        Rot_Hose_X = AirHose.transform.rotation.x;
        Rot_Hose_Y = AirHose.transform.rotation.y;
        Rot_Hose_Z = AirHose.transform.rotation.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Component"))
        {
            Debug.Log("Component Dropped!");
            Acetone.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resets velocity
            Acetone.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Resets angular velocity
            Acetone.transform.position = new Vector3(Pos_Acetone_X, Pos_Acetone_Y, Pos_Acetone_Z);
            Acetone.transform.rotation = Quaternion.Euler(Rot_Acetone_X, Rot_Acetone_Y, Rot_Acetone_Z);
            
            Isopropyl.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resets velocity
            Isopropyl.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Resets angular velocity
            Isopropyl.transform.position = new Vector3(Pos_Isopropyl_X, Pos_Isopropyl_Y, Pos_Isopropyl_Z);
            Isopropyl.transform.rotation = Quaternion.Euler(Rot_Isopropyl_X, Rot_Isopropyl_Y, Rot_Isopropyl_Z);

            Methanol.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resets velocity
            Methanol.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Resets angular velocity
            Methanol.transform.position = new Vector3(Pos_Methanol_X, Pos_Methanol_Y, Pos_Methanol_Z);
            Methanol.transform.rotation = Quaternion.Euler(Rot_Methanol_X, Rot_Methanol_Y, Rot_Methanol_Z);

            AirHose.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resets velocity
            AirHose.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Resets angular velocity
            AirHose.transform.position = new Vector3(Pos_Hose_X, Pos_Hose_Y, Pos_Hose_Z);
            AirHose.transform.rotation = Quaternion.Euler(Rot_Hose_X, Rot_Hose_Y, Rot_Hose_Z);
            AirHose.transform.Rotate(0, -90, 0);
        }
    }
}
