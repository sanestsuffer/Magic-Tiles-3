using UnityEngine;

[CreateAssetMenu(menuName = "MagicTiles/Song")]
public class SongData : ScriptableObject
{
    public string songName;
    public AudioClip audioClip;
    public float bpm;
    public Color color;
}
