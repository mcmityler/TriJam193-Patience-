using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointScript : MonoBehaviour


{
    // Start is called before the first frame update
    
    int points= 0;
    [SerializeField] TMP_Text Score;
    [SerializeField] GameOverScript pointsend;
    
    public void addpoint(){
        points++;
        Score.text=points.ToString();
        pointsend.pointRestart();
    }

    public void pointsreset(){
        points=0;
        Score.text=points.ToString();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
