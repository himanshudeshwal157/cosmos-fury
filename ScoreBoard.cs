using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
   
   int score;
   TMP_Text scoreText;
   void Start()
   {
    scoreText = GetComponent<TMP_Text>();
    scoreText.text = "start";

   }

   public void IncreaseScore(int AmtToIncrease)
   {
        score = score+AmtToIncrease;
        scoreText.text = score.ToString();
   }
}
