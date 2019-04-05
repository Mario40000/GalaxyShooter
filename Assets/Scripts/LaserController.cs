using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    //Variables
    [SerializeField]
    private float _laserSpeed = 0.0f;
    [SerializeField]
    private float _destroyTime = 0.0f;

	// Use this for initialization
	void Start ()
    {
        //Destruimos el laser al cabo del tiepo estipulado
        Destroy(gameObject, _destroyTime);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Hacemos que siempre mueva hacia arriba
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
    }
}
