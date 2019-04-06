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

    public int playerLives;

	// Use this for initialization
	void Start ()
    {
        Instantiate(_playerPrefab, _playerSpawner.position, Quaternion.identity);
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
}
