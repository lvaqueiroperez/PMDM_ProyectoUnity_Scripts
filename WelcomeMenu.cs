using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla el Menú Inicial que aparecerá al iniciar el juego tras darle a "play"
public class WelcomeMenu : MonoBehaviour {

	public GameObject welcomeMenu;

	// Use this for initialization
	void Start () {
		//Pausamos la escena tan pronto se cargue
		Time.timeScale = 0f;
		//Activamos el GameObject de nuestro menú inical (es decir, activamos el canvas para que aparezca el menú)
		welcomeMenu.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Este método público será el que estará asociado al menú y el que usará el botón del menú en su evento "OnClick"
	public void Comenzar(){

		//Cuando accionamos el botón, escondemos el menú
		welcomeMenu.SetActive(false);
		//Y reanudamos el juego
		Time.timeScale = 1f;


	}
}
