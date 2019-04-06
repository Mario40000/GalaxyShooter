using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    //Variables
    [SerializeField]
    private float speed = 0.0f;
    private GameObject _manager;
    [SerializeField]
    private int life = 0;

    public GameObject explosion;
    public GameObject playerExplosion;

	// Use this for initialization
	void Start ()
    {
        _manager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

    private void Update()
    {
        //Si salimos de la pantalla por debajo nos reposicionamos arriba otra vez
        if(transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 6.0f, 0.0f);
        }
    }

    //Miramos si colisionamos con el jugador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _manager.GetComponent<GameManager>().PlayerRespawn();
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            life--;
            //Si el enemigo no tiene resistencia es destruido
            if(life < 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            life--;
            //Si el enemigo no tiene resistencia es destruido
            if (life < 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
