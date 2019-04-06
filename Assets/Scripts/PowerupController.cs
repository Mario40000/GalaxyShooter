using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour {

    //Variables
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private int powerUpID;//0 = triple shot, 1 = speed boost, 2 = shields
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    //Miramos si hemos colisionado con algo
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Player")
        {
            //Accedemos a los componentes del jugador
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                if(powerUpID == 0)
                {
                    player.TripleShotPowerOn();
                }
                else if(powerUpID == 1)
                {
                    player.SpeedPowerOn();
                }
                else if(powerUpID == 2)
                {

                }
                
            }
            Destroy(gameObject);
        }
    }
}
