using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SpawnManager is null");
            }
            return _instance;
        }
    }
    public GameObject pipe;
    private float spawnTime = 0.5f;

    void Awake()
    {
        _instance = this;
    }
    void Update()
    {
        if (GameManager.State == GameState.InGame)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                StartSpawning();
                spawnTime = 2.0f;
            }
        }
    }
    public void StartSpawning()
    {
        Vector3 posSpawn = Camera.main.WorldToScreenPoint(transform.position);
        posSpawn.x = Screen.width * 1.01f;
        float posY = Random.Range(Screen.height * 0.3f, Screen.height * 0.8f);
        posSpawn.y = posY;
        GameObject tuyau = Instantiate(pipe, Camera.main.ScreenToWorldPoint(posSpawn), Quaternion.identity);
    }
}
