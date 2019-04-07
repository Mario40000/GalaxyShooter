using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool _isGameStart = false;

    public int playerLives;
    public float startGameDelay = 0.0f;
    public float enemySpawnDelay = 0.0f;
    public float powerUpsDelay = 0.0f;

    public Sprite[] livesImages;
    public GameObject livesPoster;
    public GameObject titleImage;
    public Text startText;
    public Text scoreText;
    public int score = 0;

	// Use this for initialization
	void Start ()
    {
        //Instantiate(_playerPrefab, _playerSpawner.position, Quaternion.identity);
        TitleScreenOn();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(_isGameStart == false)
        {
            if(Input.GetButtonDown("Jump"))
            {
                TitleScreenOff();
            }
        }
    }

    //Metodo para la pantalla inicial y empezar el juego
    void TitleScreenOff ()
    {
        titleImage.SetActive(false);
        startText.text = "";
        _isGameStart = true;
        scoreText.text = "Score: " + score.ToString();
        livesPoster.SetActive(true);
        StartCoroutine(StartCounter());
    }
    //Metodo para mostrar la pantalla de titulo antes de empoezar y al acabar
    void TitleScreenOn ()
    {
        _isGameStart = false;
        titleImage.SetActive(true);
        livesPoster.SetActive(false);
        startText.text = " Press Space bar to start";
        scoreText.text = "";

    }
    //Metodo para eliminar al player
    public void PlayerRespawn ()
    {
        if(playerLives > 0)
        {
            playerLives--;
            UpdateLives();
            StartCoroutine(RespawnCounter());
        }
        else
        {
            TitleScreenOn();
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
        
        score = 0;
        playerLives = 3;
        UpdateScore();
        UpdateLives();
        yield return new WaitForSeconds(startGameDelay);
        Instantiate(_playerPrefab, _playerSpawner.position, Quaternion.identity);
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowers());
    }

    //Metodo para instanciar enemigos
    IEnumerator SpawnEnemies()
    {
        while (_isGameStart == true)
        {
            yield return new WaitForSeconds(enemySpawnDelay);
            Vector3 spawn = new Vector3(Random.Range(-7.0f, 7.0f), 6.0f, 0.0f);
            if(_isGameStart)
            {
                Instantiate(_enemyShip, spawn, Quaternion.identity);
            }
        }
        //Destruimos todos los enemigos que queden en pantalla
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int a = 0;a < enemies.Length;a++)
        {
            Destroy(enemies[a]);
        }
    }

    //Metodo para instanciar powerUps
    IEnumerator SpawnPowers ()
    {
        while (_isGameStart == true)
        {
            yield return new WaitForSeconds(powerUpsDelay);
            Vector3 spawn = new Vector3(Random.Range(-7.0f, 7.0f), 6.0f, 0.0f);
            GameObject power = _powerUps[Random.Range(0, _powerUps.Length)];
            if(_isGameStart)
            {
                Instantiate(power, spawn, Quaternion.identity);
            }
        }
        //Destruimos todos los powers que queden en pantalla
        GameObject[] powers;
        powers = GameObject.FindGameObjectsWithTag("Enemy");
        for (int a = 0; a < powers.Length; a++)
        {
            Destroy(powers[a]);
        }
    }

    //Metodo para actualizar las vidas
    public void UpdateLives ()
    {
        livesPoster.GetComponent<Image>().sprite = livesImages[playerLives];
    }

    //Metodo para actulizar la puntuacion
    public void UpdateScore ()
    {
        if(_isGameStart == true)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            scoreText.text = "";
        }
        
    }
}
