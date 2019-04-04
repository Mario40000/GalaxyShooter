using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Variables
    [SerializeField]
    private float axisSpeed = 0.0f;
    

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
        
    }

    //Metodo para el movimiento
    private void Movement ()
    {
        //Movimiento sin fisicas
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * axisSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * axisSpeed * verticalInput * Time.deltaTime);

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
}
