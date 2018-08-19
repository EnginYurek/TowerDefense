using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countDown = 2f;

    private int waveIndex = 0;

    public Text waveCountDownText;

    private void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(spawnWave());

            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(countDown).ToString();
    }

    IEnumerator spawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }


    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

}
