using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    static ScoreManager _instance = null;

    int _bestScore = 0;
    int _myScore = 0;

    public static ScoreManager Instance()
    {
        return _instance;
    }

	void Start () {
	    if (_instance == null)
        {
            _instance = this;
        }
        LoadBestScore();
    }
	
	public int bestScore
    {
        get
        {
            return _bestScore;
        }
    }

    public int myScore
    {
        get
        {
            return _myScore;
        }
        set
        {
            _myScore = value;

            if (_myScore > _bestScore)
            {
                _bestScore = _myScore;
                SaveBestScore();
            }

            GameObject.Find("Score").GetComponent<Text>().text = 
                "Score : " + _myScore + "\nBest Score : " + _bestScore;
        }
    }

    void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best Score", _bestScore);
    }

    void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("Best Score", 0);
    }
}
