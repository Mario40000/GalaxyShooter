using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private Transform _playerSpawner;
    [SerializeField]
    private GameObject _enemyShip;
    [SerializeField]
    private GameObject[] _powerUps;

    public int playerLives;
    public float startGameDelay = 0.0f;
    public float enemySpawnDelay = 0.0f;
    public float powerUpsDelay = 0.0f;

	// Use this for initialization
	void Start ()
    {
        //Instantiate(_playerPrefab, _playerSpawner.position, Quaternion.identity);
        StartCoroutine(StartCounter());
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    //Metodo para eliminar al player
    public void PlayerRespawn ()
    {
        if(playerLives > 0)
        {
            playerLives--;
            StartCoroutine(RespawnCounter());
        }
    }
    //Contador para reinstaciar al player
    IEnumerator RespawnCounter ()
    {
        yield return new WaitForSeconds(2);
        Instantiate(_playerPrefab, _playerSpawner.position, Quaternion.identity);
    }

    //Contador para inicio de la partida
    IEnumerator StartCounter ()
    {
        yield return new WaitForSeconds(startGameDelay);
        Instantiate(_playerPrefab, _playerSpawner.position, Quaternion.identity);
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowers());
    }

    //Metodo para instanciar enemigos
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnDelay);
            Vector3 spawn = new Vector3(Random.Range(-7.0f, 7.0f), 6.0f, 0.0f);
            Instantiate(_enemyShip, spawn, Quaternion.identity);
        }
        
    }

    //Metodo para instanciar powerUps
    IEnumerator SpawnPowers ()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpsDelay);
            Vector3 spawn = new Vector3(Random.Range(-7.0f, 7.0f), 6.0f, 0.0f);
            GameObject power = _powerUps[Random.Range(0, _powerUps.Length)];
            Instantiate(power, spawn, Quaternion.identity);

        }
    }
}
