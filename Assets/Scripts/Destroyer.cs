using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //Destruimos cualquier gameObject que lleve enganchado este script
    //como por ejemplo animaciones y efectos

    [SerializeField]
    private float _delayTime;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, _delayTime);
	}
	
}
