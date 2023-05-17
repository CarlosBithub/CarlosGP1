using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyScoreText;
    PlayerManager playermanager;
   
    void Start()
    {
        playermanager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        playermanager.coinCount = 0;
        MyScoreText.text = "Score :" + playermanager.coinCount;
    }

    
    void Update()
    {
        MyScoreText.text = "Score :" + playermanager.coinCount;
    }
}
