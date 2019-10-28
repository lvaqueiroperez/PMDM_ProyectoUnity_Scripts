using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinL1 : MonoBehaviour {

//Script asociado al Menú de Victoria que permite volver al Mapa cuando se clicke en el botón "volver"


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BotonVolver(){

		SceneManager.LoadScene(1);


	}
}
