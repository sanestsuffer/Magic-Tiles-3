using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text feedbackText;
    [SerializeField] private Text comboText;

    private int currentScore = 0;
    private int comboCount = 0;
    public static int scorePoints;

    public enum AccuracyType
    {
        Perfect,
        Great,
        Cool,
        Miss
    }

    public void AddScore(AccuracyType accuracy)
    {
        int scoreToAdd = 0;
        string feedback = "";

        switch (accuracy)
        {
            case AccuracyType.Perfect:
                scoreToAdd = 5;
                feedback = "Perfect!";
                comboCount++;
                break;
            case AccuracyType.Great:
                scoreToAdd = 3;
                feedback = "Great!";
                comboCount = 0;
                break;
            case AccuracyType.Cool:
                scoreToAdd = 1;
                feedback = "Cool!";
                comboCount = 0;
                break;
            case AccuracyType.Miss:
                scoreToAdd = 0;
                feedback = "Miss!";
                comboCount = 0;
                break;
        }
        
        currentScore += scoreToAdd;
        scorePoints = currentScore;
        scoreText.text = currentScore.ToString("0");
        comboText.text = comboCount > 1 ? "x " + comboCount.ToString() : "";

        if (feedbackText != null)
        {
            feedbackText.text = feedback;
            CancelInvoke(nameof(ClearFeedback));
            Invoke(nameof(ClearFeedback), 1f);
        }
    }
    private void ClearFeedback()
    {
        feedbackText.text = "";
    }
}
