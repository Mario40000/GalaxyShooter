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
    public Transform _laserSpawner1;
    [SerializeField]
    public Transform _laserSpawner2;
    [SerializeField]
    public Transform _laserSpawner3;
    private float _nextFire = 0.0f;
    [SerializeField]
    private float _powersCounter = 0.0f;
    
    public float fireRate = 0.0f;
    public bool tripleShoot = false;
    public bool speedBoost = false;
    public float boostSpeed = 0.0f;
    
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

        //Si tenemos el power de velocidad o si no
        if(speedBoost)
        {
            transform.Translate(Vector3.right * _axisSpeed * horizontalInput * Time.deltaTime * boostSpeed);
            transform.Translate(Vector3.up * _axisSpeed * verticalInput * Time.deltaTime * boostSpeed);
        }
        else
        {
            transform.Translate(Vector3.right * _axisSpeed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _axisSpeed * verticalInput * Time.deltaTime);
        }
        
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
            //Si tenemos el triple disparo instaciamos los 3 prefabs
            if(tripleShoot)
            {
                _nextFire = Time.time + fireRate;
                Instantiate(_laserShoot, _laserSpawner1.position, Quaternion.identity);
                Instantiate(_laserShoot, _laserSpawner2.position, Quaternion.identity);
                Instantiate(_laserShoot, _laserSpawner3.position, Quaternion.identity);
            }
            //Si no, lanzamos solo uno
            else
            {
                _nextFire = Time.time + fireRate;
                Instantiate(_laserShoot, _laserSpawner1.position, Quaternion.identity);
            }
        }
    }
    //Metodo para activar el power disparo triple
    public void TripleShotPowerOn ()
    {
        tripleShoot = true;
        StartCoroutine(TripleShotCounter());
    }
    //Metodo para el contador de triple disparo
    IEnumerator TripleShotCounter ()
    {
        yield return new WaitForSeconds(_powersCounter);
        tripleShoot = false;
    }

    //Metdo para activar la super velocidad
    public void SpeedPowerOn ()
    {
        speedBoost = true;
        StartCoroutine(SpeedCounter());
    }
    //Metodo para el contador de la velocidad
    IEnumerator SpeedCounter ()
    {
        yield return new WaitForSeconds(_powersCounter);
        speedBoost = false;
    }
    
}
