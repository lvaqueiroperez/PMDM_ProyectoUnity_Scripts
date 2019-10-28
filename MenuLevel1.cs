using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevel1 : MonoBehaviour {

	//Script que controla el Menú de bienvenida al Nivel 1

public GameObject menu;

	void Start () {
		//El GameObject del menú se activa nada más entrar en la escena, pausándola
		Time.timeScale = 0f;
		menu.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Método usado en el evento "OnClick" del botón del menú que hará que el menú se oculte y que se reanude el juego
	public void Comenzar(){

		Time.timeScale = 1f;
		menu.SetActive(false);

	}
}
