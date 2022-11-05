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
    [SerializeField] DifficultyScript _difficultyScript;
    [SerializeField] TMP_Text highscore;
    [SerializeField] TMP_Text _newHighScoreText;

    bool _newHighscore = false;
    int highscorePoints = 0;
    public void addpoint(){
        points++;
        Score.text=points.ToString();
        pointsend.pointRestart();
        _difficultyScript.CheckDifficulty(); //change difficulty if points are at correcnt amount
        HighScoreCheck();
    }

    public void pointsreset(){
        points=0;
        Score.text=points.ToString();
        _newHighscore = false;
        
    }
    public int GetPoints(){
        return points;
    }
    public void HighScoreCheck(){
        if(points > highscorePoints){
            _newHighscore = true;
            highscorePoints = points;
            highscore.text = highscorePoints.ToString();
        }
    }
    public void DisplayNewhighscore(){
        if(_newHighscore){
            _newHighScoreText.text = "NEW HIGHSCORE: " + highscorePoints.ToString();
            _newHighscore = false;
        }else
        {
            _newHighScoreText.text = "";
        }
    }
}
