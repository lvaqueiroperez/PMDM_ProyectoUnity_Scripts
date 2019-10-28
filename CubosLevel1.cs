using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para el comportamiento de los obstáculos cubo
public class CubosLevel1 : MonoBehaviour {

	public GameObject cubo;

	public float speed;

	
	
	private bool colTerreno13 = false;
	private bool collWall13 = false;

	// Use this for initialization
	void Start () {
		




	}
	
	// Update is called once per frame
	void Update () {
		//empiezan hacia abajo los cubos 1, 3 y 4
		//el cubo 2 empieza de abajo a arriba

		//Basándonos en las variables que controlan qué tipo de colisión han hecho, los cubos se desplazarán hacia arriba o hacia abajo
		//En su RigidBody se ha bloqueado su rotación en todos los ejes y su movimiento en los ejes X y Z
		if(!colTerreno13 && !collWall13){

		 cubo.transform.Translate(Vector3.down * speed * Time.deltaTime);
	

		 }

		if(colTerreno13 && !collWall13){

		 cubo.transform.Translate(Vector3.up * speed * Time.deltaTime);


		 }

		 if(!colTerreno13 && collWall13){

		 cubo.transform.Translate(Vector3.down * speed * Time.deltaTime);


		 }




	}


	//Método que permite que los cubos "reboten" cuando colisionan con el terreno o con el techo invisible
	//Controlamos cuando han tocado el terreno o el techo invisible con 2 variables bool
	void OnCollisionEnter(Collision other)
	{
		
		if(other.gameObject.name == "Terreno"){

			colTerreno13 = true;
			collWall13 = false;

			

		}

		if(other.gameObject.name == "InvisibleWall"){

			colTerreno13 = false;
			collWall13 = true;

		
		}


	}

	 
}
