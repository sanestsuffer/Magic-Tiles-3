using UnityEngine;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public SongData selectedSong;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

