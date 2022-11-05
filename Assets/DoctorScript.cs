using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorScript : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.0f; //speed of the doctor
    [SerializeField] List<Color> _randomColors;
    [SerializeField] GameObject _startPoint;
    // Start is called before the first frame update
    void Start()
    {

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
        this.gameObject.GetComponent<SpriteRenderer>().color = _randomColors[Random.Range(0, _randomColors.Count)];
        this.gameObject.transform.localPosition = _startPoint.transform.position;
    }
}
