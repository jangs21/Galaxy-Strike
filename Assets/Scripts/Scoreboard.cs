using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    
    int score = 0;


    public void IncreaseScore(int amount) 
    {
        score += amount; //score = score + amount;
        scoreboardText.text = score.ToString(); // Storing the score as text in the UI, converting the int to a string

    }
}
