using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para controlar el comportamiento de los Lasers en el Nivel 1
public class LasersLevel1 : MonoBehaviour {

	public GameObject laser;
	private bool laserActive = true;


	// Use this for initialization
	void Start () {
	//El método "InvokeRepeating" permite invocar a un método múltiples veces, esperando un tiempo en segundos antes de activarse por
	//primera vez y especificando un intervalo de repetición en segundos
	InvokeRepeating("laserControl",2,2);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	//Método que controla los Lasers, si el GameObject del laser está activo, éste se desactivará y viceversa usando una variable bool como apoyo
	void laserControl(){
	
	if(laserActive){

		laser.SetActive(false);
		laserActive = false;
		

	}else if(laserActive == false){

			laser.SetActive(true);
			laserActive = true;
	}


	}

	
}
