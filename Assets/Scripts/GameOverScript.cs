using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] GameObject gameOverObj;
    [SerializeField] GameObject playerone;
    [SerializeField] GameObject startPosition;
    [SerializeField] DoctorScript DoctorScripty;
    [SerializeField] PatientSicknessScript PatientlySick;
    [SerializeField] GameObject winReset;
    [SerializeField] GameObject _cameraObject;

    int _lives = 3;
    [SerializeField] TMP_Text _livesText;
    [SerializeField] CameraShake _cameraShake;
    public void showGameOver()
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 0;
    }
    public void gameRestart()
    {
        gameOverObj.SetActive(false);
        Time.timeScale = 1;
        playerone.transform.position = startPosition.transform.position;
        DoctorScripty.RandomDoctorColour();
        PatientlySick.RandomSickness();
        winReset.SetActive(false);
        _lives = 3;
        _livesText.text = _lives.ToString();
        _cameraObject.transform.localPosition = Vector3.zero;

    }
    public void pointRestart()
    {
        gameOverObj.SetActive(false);
        playerone.transform.position = startPosition.transform.position;
        DoctorScripty.RandomDoctorColour();
        PatientlySick.RandomSickness();
        winReset.SetActive(false);

    }
    public void RemoveLife()
    {
        _lives--;
        _livesText.text = _lives.ToString();

        if (_lives <= 0)
        {
            showGameOver();
            return;
        }
        StartCoroutine(_cameraShake.Shake(0.3f, 0.3f)); //make camera shake whenever you take damage


    }
}
