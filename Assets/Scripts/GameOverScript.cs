using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] GameObject gameOverObj;
    [SerializeField] GameObject playerone;
    [SerializeField] GameObject startPosition;
    [SerializeField] DoctorScript DoctorScripty1;
    [SerializeField] DoctorScript DoctorScripty2;

    [SerializeField] PatientSicknessScript PatientlySick;
    [SerializeField] GameObject winReset;
    [SerializeField] GameObject _cameraObject;

    int _lives = 3;
    [SerializeField] TMP_Text _livesText;
    [SerializeField] CameraShake _cameraShake;
    [SerializeField] DifficultyScript _difficultyScript;
    [SerializeField] PointScript _pointScript;
    [SerializeField] Animator _titleAnimator;
    [SerializeField] DoctorScript _doctor1;
    [SerializeField] DoctorScript _doctor2;



    public void showGameOver()
    {
        _pointScript.DisplayNewhighscore();
        gameOverObj.SetActive(true);
        _titleAnimator.ResetTrigger("TitleAway");

        _titleAnimator.SetTrigger("TitleBack");

        _doctor1.ChangeSpeed(0);
        _doctor2.ChangeSpeed(0);


    }
    public void gameRestart()
    {
        gameOverObj.SetActive(false);
        playerone.transform.position = startPosition.transform.position;
        DoctorScripty1.RandomDoctorColour();
        DoctorScripty2.RandomDoctorColour();

        PatientlySick.RandomSickness();
        winReset.SetActive(false);
        _lives = 3;
        _livesText.text = _lives.ToString();
        _cameraObject.transform.localPosition = Vector3.zero;

        _difficultyScript.ResetDifficulty();
    }
    public void pointRestart()
    {
        gameOverObj.SetActive(false);
        playerone.transform.position = startPosition.transform.position;
        DoctorScripty1.RandomDoctorColour();
        DoctorScripty2.RandomDoctorColour();

        PatientlySick.RandomSickness();
        winReset.SetActive(false);
    }
    public void RemoveLife()
    {
        _lives--;
        _livesText.text = _lives.ToString();
        if (_lives <= 0)
        {
            _lives = 0;
            showGameOver();
            return;
        }
        StartCoroutine(_cameraShake.Shake(0.3f, 0.3f)); //make camera shake whenever you take damage
    }
}
