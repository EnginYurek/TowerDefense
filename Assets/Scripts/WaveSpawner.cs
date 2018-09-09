using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int enemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countDown = 2f;

    private int waveIndex = 0;

    public Text waveCountDownText;

    private void Update()
    {
        if (enemiesAlive > 0)
            return;

        if (countDown <= 0)
        {
            StartCoroutine(spawnWave());

            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator spawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];


        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level WON");
            this.enabled = false;
        }
    }


    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;

    }

}
