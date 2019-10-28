using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script para el comportamiento del Enemy del Nivel 1, un agente que perseguirá al player y que, si lo toca, el player perderá
public class AgenteLevel1 : MonoBehaviour {
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo;
    private bool dentro = false;

    public GameObject loseMenu;

    public static Animator animator;
    public float proximidad;
   
	void Start () {
        
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();

        animator = jugador.GetComponent<Animator>();
	}
	
    //Si nuestro 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = true;
            
        }

    }

	void Update () {
		
        if (!dentro)
        {
            enemigo.destination = jugador.position;
            
            
        }
        if(dentro){

             Time.timeScale = 0f;
             loseMenu.SetActive(true);

        }

        if(enemigo.remainingDistance < proximidad){

            Debug.Log("Peligro");
            animator.SetBool("EstarEnPeligro",true);

        }else{

            Debug.Log("Tranquilo");
            animator.SetBool("EstarEnPeligro",false);

        }
        
	}
    
}