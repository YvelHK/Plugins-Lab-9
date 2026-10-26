using TMPro;
using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text display;
    public void AddScore(int points)
    {
        score += points;
        display.text = "Score: " + score;
    }

    private void Start()
    {
        TargetHit.AddEvent += AddScore;
        AddScore(0);
    }
}
