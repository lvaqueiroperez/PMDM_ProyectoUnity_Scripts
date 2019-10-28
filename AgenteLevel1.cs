using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script para el comportamiento del Enemy del Nivel 1, un agente que perseguirá al player a través del Nivel 1
//Nota: el código que hace que el jugador pierda si choca con el enemigo está en el script "PlayerLevel1"

public class AgenteLevel1 : MonoBehaviour {

    //recogemos la posición del plauer
    public Transform jugador;
    //recogemos el componente "Agent" de nuestro enemigo
    UnityEngine.AI.NavMeshAgent enemigo;
    //controlamos con un bool si el enemigo ha tocado o no al player
    private bool dentro = false;

    public GameObject loseMenu;

   //medimos la proximidad del enemigo al player con un float
    public float proximidad;
   
	void Start () {
        
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();

        
	}

	void Update () {
		//mientras el enemigo no haya entrado en el "área" del player, su destino ".destination" será la posición actual del player
        if (!dentro)
        {
            enemigo.destination = jugador.position;
            
            
        }       

        
	}
    
}