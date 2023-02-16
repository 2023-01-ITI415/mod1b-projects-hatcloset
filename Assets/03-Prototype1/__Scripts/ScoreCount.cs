using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI classes like Text.

public class ScoreCount : MonoBehaviour
{
    [Header("Dynamic")]

    public int score = 0;

    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        uiText.text = "SCORE: " + score.ToString("#,0"); // This 0 is a zero!
    }
}
