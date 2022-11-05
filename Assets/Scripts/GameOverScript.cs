using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    
    [SerializeField] GameObject gameOverObj;
    [SerializeField] GameObject playerone;
    [SerializeField] GameObject startPosition;
    [SerializeField] DoctorScript DoctorScripty;
    [SerializeField] PatientSicknessScript PatientlySick;
    [SerializeField] GameObject winReset;
    
    public void showGameOver(){
        gameOverObj.SetActive(true);
        Time.timeScale= 0;
    }   
    public void gameRestart(){
        gameOverObj.SetActive(false);
        Time.timeScale= 1;
        playerone.transform.position = startPosition.transform.position;
        DoctorScripty.RandomDoctorColour();
        PatientlySick.RandomSickness();
        winReset.SetActive(false);
        
    }    
}
