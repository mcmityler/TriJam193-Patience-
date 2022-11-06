using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    int _currentDifficulty = 0;
    [SerializeField] PointScript _pointScript;
    [SerializeField] DoctorScript _doctor2;
    [SerializeField] DoctorScript _doctor1;
    [SerializeField] float _doctorCurrentSpeed = 2;
    [SerializeField] float _baseSpeed = 2;
    bool _doctor2Active = false;
    [SerializeField] Animator _titleAnimator;

    [SerializeField] GameObject _restartButton;
    [SerializeField] GameObject _startButton;

    public void StartGame()
    {
        _currentDifficulty = 1;
        _doctor1.ChangeSpeed(_doctorCurrentSpeed);
        _titleAnimator.ResetTrigger("TitleBack");

        _titleAnimator.SetTrigger("TitleAway");

        _restartButton.SetActive(true);
        _startButton.SetActive(false);

        _doctor1.RandomDoctorColour();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>().StartPlayer();
    }
    void Start()
    {
        _doctor2.ChangeSpeed(0);
        _doctor1.ChangeSpeed(0);
    }

    public void CheckDifficulty()
    {
        int m_points = _pointScript.GetPoints();
        _doctorCurrentSpeed = _baseSpeed + m_points / 3;
        _doctor1.ChangeSpeed(_doctorCurrentSpeed);
        if (_doctor2Active == true)
        {
            _doctor2.ChangeSpeed(_doctorCurrentSpeed);
        }
        if (m_points >= 3)
        {
            //start spawning second doctor
            _doctor2Active = true;
            _doctor2.ChangeSpeed(_doctorCurrentSpeed);
        }
    }
    public void ResetDifficulty()
    {
        _doctorCurrentSpeed = _baseSpeed;
        _doctor1.ChangeSpeed(_doctorCurrentSpeed);
        _doctor2.ChangeSpeed(0);
        _doctor2Active = false;
        _titleAnimator.ResetTrigger("TitleBack");

        _titleAnimator.SetTrigger("TitleAway");
    }
}
