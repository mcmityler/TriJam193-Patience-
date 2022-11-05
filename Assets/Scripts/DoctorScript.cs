using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorScript : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.0f; //speed of the doctor
    [SerializeField] List<Color> _randomHatColors;
    [SerializeField] List<Color> _randomShoeColors;

    [SerializeField] GameObject _startPoint;
    [SerializeField] GameObject _hatObj;

    [SerializeField] GameObject _shoeObj;
    // Start is called before the first frame update
    void Start()
    {
        RandomDoctorColour();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Transform>().transform.position += new Vector3(1, 0, 0) * Time.deltaTime * _moveSpeed; //move right at a contstant rate
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EndPoint")
        {
            RandomDoctorColour();
        }
    }
    void RandomDoctorColour()
    {
        _hatObj.GetComponent<SpriteRenderer>().color = _randomHatColors[Random.Range(0, _randomHatColors.Count)];
        _shoeObj.GetComponent<SpriteRenderer>().color = _randomShoeColors[Random.Range(0, _randomShoeColors.Count)];

        this.gameObject.transform.localPosition = _startPoint.transform.position;
    }
    public Color GetCurrentHatColor(){
        return _hatObj.GetComponent<SpriteRenderer>().color;

    }
    public Color GetCurrentShoeColor(){
        return _shoeObj.GetComponent<SpriteRenderer>().color;

    }
    public List<Color> GetAllHatColors(){
        return _randomHatColors;

    }
    public List<Color> GetAllShoeColors(){
        return _randomShoeColors;
    }
}

