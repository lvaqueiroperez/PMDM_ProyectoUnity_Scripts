using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para que la cámara siempre siga al player
public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//el "offset" es será la distancia que hay ENTRE el jugador y la cámara (transform recoge la posición de la cámara y player.transform la del jugador)
		offset = transform.position - player.transform.position;
		
	}
	
	// LateUpdate es una función igual que Update, pero ASEGURA el funcionamiento correcto
	//en todos los items y elementos que se procesan en el juego por cada frame
	//Se suele usar para cámaras, animación procedural y "gathering"
	void LateUpdate () {
		//controlamos el seguimiento de la cámara al jugador
		transform.position = player.transform.position + offset;

	}
}
