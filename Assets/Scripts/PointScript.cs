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

    List<string> _patientNames = new List<string> {"James","Mary","Robert","Patricia","John","Jennifer","Michael","Linda","David","Elizabeth","William","Barbara","Richard","Susan","Joseph","Jessica","Thomas","Sarah","Charles","Karen","Christopher","Lisa",
"Daniel","Nancy","Matthew","Betty","Anthony","Margaret","Mark","Sandra","Donald","Ashley","Steven","Kimberly","Paul","Emily","Andrew","Donna","Joshua","Michelle","Kenneth","Carol","Kevin","Amanda","Brian",
"Dorothy","George","Melissa","Timothy","Deborah","Ronald","Stephanie","Edward","Rebecca","Jason","Sharon","Jeffrey","Laura","Ryan","Cynthia","Jacob","Kathleen","Gary","Amy","Nicholas","Angela","Eric","Shirley","Jonathan","Anna","Stephen",
"Brenda","Larry","Pamela","Justin","Emma","Scott","Nicole","Brandon","Helen","Benjamin","Samantha","Samuel","Katherine","Gregory","Christine","Alexander","Debra","Frank","Rachel","Patrick","Carolyn","Raymond","Janet","Jack","Catherine","Dennis",
"Maria","Jerry","Heather","Tyler","Diane","Aaron","Ruth","Jose","Julie","Adam","Olivia","Nathan","Joyce","Henry","Mirginia","Douglas","Victoria","Zachary","Kelly","Peter","Lauren","Kyle","Christina","Ethan","Joan","Walter","Evelyn","Noah","Judith","Jeremy"
,"Megan","Christian","Andrea","Keith","Cheryl","Roger","Hannah","Terry","Jacqueline",
"Bryan","Abigail","Billy","Alice","Joe","Julia","Bruce","Judy","Gabriel","Sophia","Logan","Grace","Albert","Denise","Willie","Amber","Alan","Doris","Juan","Marilyn","Wayne","Danielle","Elijah","Beverly","Randy","Isabella","Roy","Theresa","Vincent","Diana",
"Ralph","Natalie","Eugene","Brittany","Russell","Charlotte","Bobby","Marie","Mason","Kayla","Philip","Alexis","Louis"};


    [SerializeField] TMP_Text _patientNametextbox;
    bool _newHighscore = false;
    int highscorePoints = 0;
    void Start(){
        NewName();
    }
    public void addpoint(){
        points++;
        Score.text=points.ToString();
        pointsend.pointRestart();
        _difficultyScript.CheckDifficulty(); //change difficulty if points are at correcnt amount
        HighScoreCheck();
        NewName();
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
    public void NewName(){
        _patientNametextbox.text = _patientNames[Random.Range(0,_patientNames.Count)];
    }
}