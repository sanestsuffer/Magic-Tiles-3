using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Start()
    {
        int finalScore = ScoreManager.scorePoints;
        scoreText.text = finalScore.ToString("0");
    }
}
