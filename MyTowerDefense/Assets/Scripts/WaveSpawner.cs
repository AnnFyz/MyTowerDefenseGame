using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 10.5f;
    public float timeBetweenEnemies = 0.25f;
    private float countdown = 1f;

    private int waveIndex = 1;

    public TMP_Text countdownText;
    private void Start()
    {
        countdownText.text = Mathf.Round(timeBetweenWaves).ToString();
    }

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", countdown);
        //countdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        Debug.Log("PlayerStats.Rounds " + PlayerStats.Rounds);
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y,0f), Quaternion.identity);
    }
}
