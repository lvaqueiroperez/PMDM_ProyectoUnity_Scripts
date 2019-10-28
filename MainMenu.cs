using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script que controla el Menú principal del juego asociado a su Canvas
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Simplemente tenemos un método público que será usado por el botón "PlayButton" en su evento "OnClick":
	public void StartGame(){
		//al accionar el botón, con este método cambiamos la escena
		SceneManager.LoadScene(1);


	}

}
