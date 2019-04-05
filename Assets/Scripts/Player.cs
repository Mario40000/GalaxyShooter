using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Variables
    [SerializeField]
    private float _axisSpeed = 0.0f;
    [SerializeField]
    public GameObject _laserShoot;
    [SerializeField]
    public Transform _laserSpawner;
    private float _nextFire = 0.0f;

    public float fireRate = 0.0f;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        Movement();
    }

    // Update is called once per frame
    private void Update()
    {
        //Comprobamos si se ha pulsado fuego
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    //Metodo para el movimiento
    private void Movement ()
    {
        //Movimiento sin fisicas
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * _axisSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _axisSpeed * verticalInput * Time.deltaTime);

        //No podremos pasar de los limites de la pantalla
        if (transform.position.y > 4.25)
        {
            transform.position = new Vector3(transform.position.x, 4.25f, 0);
        }
        else if (transform.position.y < -4.25)
        {
            transform.position = new Vector3(transform.position.x, -4.25f, 0);
        }
        else if (transform.position.x > 7.3)
        {
            transform.position = new Vector3(7.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.3)
        {
            transform.position = new Vector3(-7.3f, transform.position.y, 0);
        }
    }

    //Metodo para disparar
    private void Shoot()
    {
        //Comprobamos si ha pasado el cooldown
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            Instantiate(_laserShoot, _laserSpawner.position, Quaternion.identity);
        }
    }
}
