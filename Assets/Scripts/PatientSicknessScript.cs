using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatientSicknessScript : MonoBehaviour
{
    List<Color> _hatColors;
    List<Color> _shoeColors;
    [SerializeField] DoctorScript _doctorScript;
    [SerializeField] GameOverScript GameEnd;

    [SerializeField] GameObject _sicknessShoe;
    [SerializeField] GameObject _sicknessHat;
    [SerializeField] TMP_Text _WinnerText;
    [SerializeField] PointScript getpoints; 

    // Start is called before the first frame update
    void Start()
    {
        _hatColors = _doctorScript.GetAllHatColors();
        _shoeColors = _doctorScript.GetAllShoeColors();
        RandomSickness();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomSickness()
    {
        _sicknessShoe.GetComponent<SpriteRenderer>().color = _shoeColors[Random.Range(0, _shoeColors.Count)];
        _sicknessHat.GetComponent<SpriteRenderer>().color = _hatColors[Random.Range(0, _hatColors.Count)];

    }

    public void CheckCombo()
    {
        Debug.Log(_sicknessShoe.GetComponent<SpriteRenderer>().color);
        Debug.Log(_doctorScript.GetCurrentHatColor());


        if (_sicknessShoe.GetComponent<SpriteRenderer>().color == _doctorScript.GetCurrentShoeColor() &&
                _sicknessHat.GetComponent<SpriteRenderer>().color == _doctorScript.GetCurrentHatColor())
        {
            Debug.Log("Winner!!!");
            _WinnerText.gameObject.SetActive(true);
            getpoints.addpoint();
        }else{
            Debug.Log("Life was lost");
            GameEnd.RemoveLife();
        }
    }
}



