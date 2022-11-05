using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk_interaction : MonoBehaviour
{
    bool serviceDesk = false;

    [SerializeField]PatientSicknessScript patitientsicknessScript; 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "Player")
        {
            serviceDesk = true;
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && serviceDesk == true)
        {
            Debug.Log("col.gameObject.name");
        
            patitientsicknessScript.CheckCombo();
        }
    }
}
