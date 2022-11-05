using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desk_interaction : MonoBehaviour
{
    bool serviceDesk = false;

    [SerializeField]PatientSicknessScript patitientsicknessScript;    
    [SerializeField] GameObject EyeAlert;    
    
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            serviceDesk = true;
            EyeAlert.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            serviceDesk = false;
            EyeAlert.SetActive(false);
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
