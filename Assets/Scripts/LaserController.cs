using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    //Variables
    [SerializeField]
    private float _laserSpeed = 0.0f;
    
	// Use this for initialization
	void Start ()
    {
           
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Hacemos que siempre mueva hacia arriba
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
        //Destruimos el laser si sale de la pantalla
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

}
