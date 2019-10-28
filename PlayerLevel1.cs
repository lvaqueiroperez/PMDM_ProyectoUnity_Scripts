using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel1 : MonoBehaviour {

	//Script para el movimiento y comportamiento del player en el Nivel 1 y para el control de menús de Victoria/Derrota
    //Nota: usamos un controlador de movimiento sin la "aceleración" que se aplicaba en otros para una mejor respuesta y gameplay

	private Rigidbody rb;

	public float speed;

	public float jumpforce;

	private bool grounded;

	private Animator animator;

	public GameObject menuLoose;

	public GameObject menuWin;

	public Text Contmonedas;
	
	private int contM = 0;

	void Start () {
		
	rb = GetComponent<Rigidbody>();

	grounded = true;

	animator = GetComponent<Animator>();

	 animator.SetBool("movement",false);
     animator.SetBool("movementBack",false);
	 animator.SetBool("jump",false);

	menuLoose.SetActive(false);
	menuWin.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
		
			//NO multiplicamos por el Time.deltaTime
			rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed ,rb.velocity.y,Input.GetAxis("Vertical") * speed);

			if(Input.GetKeyDown(KeyCode.Space) && grounded ){

				rb.velocity = new Vector3(rb.velocity.x, jumpforce,rb.velocity.z);

			}


			//ANIMACIONES
			if(Input.GetKeyDown(KeyCode.D)){

				animator.SetBool("movement",true);
     			animator.SetBool("movementBack",false);
				animator.SetBool("jump",false);

			}

			if(Input.GetKeyDown(KeyCode.A)){

				animator.SetBool("movement",false);
     			animator.SetBool("movementBack",true);
				animator.SetBool("jump",false);
			}

			if((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A))){

				animator.SetBool("movement",false);
     			animator.SetBool("movementBack",false);
				 animator.SetBool("jump",false);

			}

			if(Input.GetKeyDown(KeyCode.Space) && grounded){

				animator.SetBool("jump",true);
				animator.SetBool("movement",false);
     			animator.SetBool("movementBack",false);

			}

			if(Input.GetKeyUp(KeyCode.Space)){

				animator.SetBool("jump",false);
				

			}

			if((Input.GetKeyUp(KeyCode.Space)) && (Input.GetKeyDown(KeyCode.D))){

				animator.SetBool("jump",false);
				animator.SetBool("movement",true);
				animator.SetBool("movementBack",false);

			}

			if((Input.GetKeyDown(KeyCode.Space)) && (Input.GetKeyDown(KeyCode.D) && grounded)){

				animator.SetBool("movement",false);
     			animator.SetBool("movementBack",false);
				 animator.SetBool("jump",true);

			}
			if((Input.GetKeyDown(KeyCode.Space)) && (Input.GetKeyDown(KeyCode.A)) && grounded){

				animator.SetBool("movement",false);
     			animator.SetBool("movementBack",false);
				 animator.SetBool("jump",true);

			}



			

	}


	//COLISIONES Y ACTIVACIÓN DE MENÚS DE VICTORIA/DERROTA:

	void OnCollisionEnter(Collision other){
		//Control de que el jugador está tocando terreno
		if((other.gameObject.name == "Terreno")|| (other.gameObject.CompareTag("Plataforma"))){
			grounded = true;
		}
		//Menús de Derrota cuando tocamos un obstáculo
		if((other.gameObject.CompareTag("CubeObs")) || (other.gameObject.CompareTag("Enemy")) || (other.gameObject.CompareTag("Laser"))){
			Time.timeScale = 0f;
			menuLoose.SetActive(true);
		}
		//Menú de Victoria si hemos llegado al portal con 4+ monedas, o de derrota si hemos llegado al portal con menos monedas
		if(other.gameObject.CompareTag("portal")){

			if(contM >= 4){
			Time.timeScale = 0f;
			menuWin.SetActive(true);
			}else{

				Time.timeScale = 0f;
				menuLoose.SetActive(true);

			}

		}

		
		
	}
//MONEDAS
//Al collisionar con un trigger de las monedas, éstas desaparecerán y aunmentará el contador de monedas en pantalla (un texto)
	void OnTriggerEnter(Collider other){

		if(other.gameObject.CompareTag("coin")){

			other.gameObject.SetActive(false);
			
			contM = contM + 1;

			Contmonedas.text = "Monedas: " + contM.ToString();
			


		}

	}

	


}
