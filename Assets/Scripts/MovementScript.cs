using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    bool _leftPressed, _rightPressed = false;

    Vector3 _moveDir = new Vector3(0, 0, 0);
    [SerializeField] float _moveSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // _leftPressed = _rightPressed = false;
        _moveDir = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _leftPressed = true;
            _rightPressed = false;
            _moveDir += new Vector3(-1, 0, 0);
         
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _rightPressed = true;
            _leftPressed = false;
            _moveDir += new Vector3(1, 0, 0);

            
        }
        MovePlayer();
        PlayerFlip();
    
    }
    
    void PlayerFlip(){

            foreach (var item in this.gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
               item.flipX=_leftPressed; 
            }
            
    }
    
    
    void MovePlayer()
    {
        this.gameObject.GetComponent<Transform>().transform.position += _moveDir * _moveSpeed * Time.deltaTime;


    }
    public void StartPlayer(){
        _moveSpeed = 4;
    }
}
