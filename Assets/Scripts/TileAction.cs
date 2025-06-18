using UnityEngine;
using UnityEngine.SceneManagement;

public class TileAction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer color;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource buttonSound;
    private Transform scoreLine;
    private bool isPressed = true;

    public void Init(float fallSpeed)
    {
        rb.velocity = new Vector3(0, -fallSpeed, 0);
    }
    private void PlaySound()
    {
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
    }
    public void SetScoreLine(Transform line)
    {
        scoreLine = line;
    }
    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleInput(Input.GetTouch(0).position);
        }
#endif
    }
    private void HandleInput(Vector3 screenPos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
        Collider2D hit = Physics2D.OverlapPoint(worldPoint);

        if (hit != null && hit.gameObject == gameObject && isPressed)
        {
            float distance = Mathf.Abs(transform.position.y - scoreLine.position.y);

            ScoreManager.AccuracyType accuracy;
            if (distance <= 1f) accuracy = ScoreManager.AccuracyType.Perfect;
            else if (distance <= 2f) accuracy = ScoreManager.AccuracyType.Great;
            else if (distance <= 5f) accuracy = ScoreManager.AccuracyType.Cool;
            else accuracy = ScoreManager.AccuracyType.Miss;

            FindObjectOfType<ScoreManager>().AddScore(accuracy);

            Color c = color.color;
            c.a = 0.5f;
            color.color = c;

            PlaySound();
            isPressed = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
{
    if (!isPressed)
    {
        Debug.Log("Fine");
    }
    else if (col.collider.tag == "End_Line")
    {
        SceneManager.LoadScene(3);
    }
}
}