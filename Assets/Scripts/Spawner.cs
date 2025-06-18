using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefabs;
    [SerializeField] private Transform[] spawnLines;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform scoreLine;
    private float spawnY = 3f;
    private float lineY = 0f;
    private float beatInterval;

    private void Start()
    {
        SongData song = SongManager.Instance.selectedSong;
        if (song == null)
        {
            Debug.LogError("No song selected from SongManager!");

            return;
        }
        beatInterval = 60f / song.bpm;  
        audioSource.clip = song.audioClip;
        audioSource.Play();

        InvokeRepeating(nameof(SpawnBeatTile), 0f, beatInterval);
    }

    private void SpawnBeatTile()
    {
        Transform line = GetRandomFreeLine();
        if (line != null)
        {
            Vector3 spawnPos = line.position;
            GameObject tile = Instantiate(tilePrefabs, spawnPos, Quaternion.identity, line);

            float fallDistance = spawnY - lineY;
            float fallSpeed = fallDistance / beatInterval;

            TileAction tileAction = tile.GetComponent<TileAction>();
            if (tileAction != null)
            {
                tileAction.Init(fallSpeed);
                tileAction.SetScoreLine(scoreLine);
            }
        }
    }
    private Transform GetRandomFreeLine()
    {
        List<Transform> freeLines = new List<Transform>();

        foreach (Transform line in spawnLines)
        {
            if (line.childCount == 0)
                freeLines.Add(line);
        }

        if (freeLines.Count > 0)
        {
            int randIndex = Random.Range(0, freeLines.Count);
            return freeLines[randIndex];
        }

        return null;
    }
}

