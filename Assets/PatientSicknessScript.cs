using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatientSicknessScript : MonoBehaviour
{
    List<Color> _hatColors;
    List<Color> _shoeColors;
    [SerializeField] DoctorScript _doctorScript;

    [SerializeField] GameObject _sicknessShoe;
    [SerializeField] GameObject _sicknessHat;
    [SerializeField] TMP_Text _WinnerText;

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

    void RandomSickness()
    {
        _sicknessShoe.GetComponent<SpriteRenderer>().color = _shoeColors[Random.Range(0, _shoeColors.Count)];
        _sicknessHat.GetComponent<SpriteRenderer>().color = _hatColors[Random.Range(0, _hatColors.Count)];

    }

    public void CheckCombo()
    {
        if (_sicknessShoe.GetComponent<SpriteRenderer>().color == _doctorScript.GetCurrentHatColor() &&
                _sicknessHat.GetComponent<SpriteRenderer>().color == _doctorScript.GetCurrentShoeColor())
        {
            Debug.Log("Winner!!!");
        }
    }
}



