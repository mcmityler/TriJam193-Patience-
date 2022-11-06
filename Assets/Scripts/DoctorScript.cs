using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorScript : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.0f; //speed of the doctor
    [SerializeField] Vector3 _moveDir = new Vector3(1, 0, 0);
    [SerializeField] List<Color> _randomHatColors;
    [SerializeField] List<Color> _randomShoeColors;

    [SerializeField] GameObject _startPoint;
    [SerializeField] GameObject _hatObj;

    [SerializeField] GameObject _shoeObj;
    [SerializeField] PatientSicknessScript _sicknessScript;

    [SerializeField] GameObject _doctor1;
    [SerializeField] GameObject _doctor2;
    [SerializeField] bool _isDoctor2 = false;


    int _doctorNumber = 0;
    int _maxDoctors = 15;
    // Start is called before the first frame update
    void Start()
    {
        _maxDoctors = Random.Range(10, 17);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Transform>().transform.position += _moveDir * Time.deltaTime * _moveSpeed; //move right at a contstant rate
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isDoctor2 == false)
        {
            if (col.gameObject.tag == "EndPoint")
            {
                RandomDoctorColour();
            }
        }
         if (_isDoctor2 == true)
        {
            if (col.gameObject.tag == "EndPoint2")
            {
                RandomDoctorColour();
            }
        }

    }
    public void RandomDoctorColour()
    {

        _hatObj.GetComponent<SpriteRenderer>().color = _randomHatColors[Random.Range(0, _randomHatColors.Count)];
        _shoeObj.GetComponent<SpriteRenderer>().color = _randomShoeColors[Random.Range(0, _randomShoeColors.Count)];
     
            while (_doctor1.GetComponent<DoctorScript>().GetCurrentHatColor() == _doctor2.GetComponent<DoctorScript>().GetCurrentHatColor() &&
             _doctor1.GetComponent<DoctorScript>().GetCurrentShoeColor() == _doctor2.GetComponent<DoctorScript>().GetCurrentShoeColor())
            {
                _hatObj.GetComponent<SpriteRenderer>().color = _randomHatColors[Random.Range(0, _randomHatColors.Count)];
                _shoeObj.GetComponent<SpriteRenderer>().color = _randomShoeColors[Random.Range(0, _randomShoeColors.Count)];
            }
    

        this.gameObject.transform.localPosition = _startPoint.transform.position;
        _doctorNumber++;
        if (_doctorNumber > _maxDoctors)
        {
            _hatObj.GetComponent<SpriteRenderer>().color = _sicknessScript.GetSicknessHat();
            _shoeObj.GetComponent<SpriteRenderer>().color = _sicknessScript.GetSicknessShoes();
            _maxDoctors = Random.Range(12, 16); //new limit before it HAS to appear
            _doctorNumber = 0; //reset counter of how many have passed

        }
    }
    public Color GetCurrentHatColor()
    {
        return _hatObj.GetComponent<SpriteRenderer>().color;

    }
    public Color GetCurrentShoeColor()
    {
        return _shoeObj.GetComponent<SpriteRenderer>().color;

    }
    public List<Color> GetAllHatColors()
    {
        return _randomHatColors;

    }
    public List<Color> GetAllShoeColors()
    {
        return _randomShoeColors;
    }
    public void ChangeSpeed(float m_moveSpeed){
        _moveSpeed = m_moveSpeed;
    }
}

