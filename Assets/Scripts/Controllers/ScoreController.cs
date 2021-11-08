using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using UnityEngine.UI;




public class ScoreController : MonoBehaviour
{
    private int score = 0 ;
    
    private TextMeshProUGUI textMesh; 


    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateScoreText();
    }


    public void IncreaseScore( int sc)
    {
        score += sc;
        UpdateScoreText();
    }
  


    void UpdateScoreText()
    {
        textMesh.text = "Score : " +score;
    }
   
}
