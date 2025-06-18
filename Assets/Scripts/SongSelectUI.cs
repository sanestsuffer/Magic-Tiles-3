using UnityEngine;

public class SongSelectUI : MonoBehaviour
{
    public GameObject buttonPrefab; 
    public Transform contentParent; 

    void Start()
    {
        SongData[] songs = Resources.LoadAll<SongData>("Songs");

        foreach (SongData song in songs)
        {
            GameObject btn = Instantiate(buttonPrefab, contentParent);
            btn.GetComponent<SongButtonUI>().Init(song);
        }
    }
}