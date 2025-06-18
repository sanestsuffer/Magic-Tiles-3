using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongButtonUI : MonoBehaviour
{
    public Text titleText; 
    private SongData song;
    private Image borderImage;
    private void Awake()
    {
        borderImage = GetComponent<Image>();
    }
    public void Init(SongData songData)
    {
        song = songData;
        titleText.text = song.songName;

        if (borderImage != null)
        {
            borderImage.color = song.color;
        }
        
        GetComponent<Button>().onClick.AddListener(OnSelect);
    }

    void OnSelect()
    {
        SongManager.Instance.selectedSong = song;
        SceneManager.LoadScene(2);
    }
}