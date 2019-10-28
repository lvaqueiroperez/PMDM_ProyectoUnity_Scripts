using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
 
 //En este script vamos a configurar el comportamiento del jugador en el mapa, simular la gravedad del planeta/mapa y el efecto de rotación del mapa

  /*
  Fuente:
  https://www.youtube.com/watch?v=UeqfHkfPNh4 (no todo lo explicado en el vídeo fue usado)
   */

//Nota: La cámara siempre seguirá al player porque, en realidad, el player no se mueve de posición, sino que rota el planeta bajo sus pies

public class PlayerOnPlanet : MonoBehaviour
{
    //Variable en la que almacenaremos el GameObject de nuestro planeta
    public GameObject Planet;

    //Variable en la que almacenaremos el componente "Animator" de nuestro player
    public static Animator animator;

    //Variable que permitirá configurar la velocidad del player
    public float speed = 4;
    //La altura de salto del player será almacenada en una variable float
    public float JumpHeight = 1.2f;
    //Almacenamos el valor de la "gravedad" que usaremos en una variable float
    float gravity = 100;
    //Usamos una variable bool para identificar si el jugador está tocando el "suelo" o no
    bool OnGround = false;
 
    //Guardamos la distancia de nuestro personaje al "suelo" en un float
    float distanceToGround;
    //Creamos un vector para usar "vector normal" (es decir, el vector que es perpendicular al suelo en todo momento)
    Vector3 Groundnormal;
    //recogemos el rigidbody del player asociado a este script en una variable Rigidbody
    private Rigidbody rb;
 
    // Start is called before the first frame update
    void Start()
    {
        //Recogemos el rigidbody
        rb = GetComponent<Rigidbody>();
        //IMPEDIMOS que el personaje asociado al rigidbody pueda rotar! (lo único que rotará será el planeta)
        //nota: también se ha impedido el movimiento del personaje en el eje X en la configuración del Rigidbody dentro del propio Unity
        rb.freezeRotation = true;
        
        

        //Recogemos el animator
        animator = GetComponent<Animator>();
        
        //Inicializamos sus variables de animaciones a "false" para impedir errores
        animator.SetBool("movement",false);
        animator.SetBool("movementBack",false);

        
    }
 
    // Update is called once per frame
    void Update()
    {
 
        //MOVIMIENTO
        //Hacemos que el player se pueda mover solo en el eje z
        
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
       
       
        transform.Translate(0, 0, z);
        

        
 
        //ROTACIÓN LOCAL
        //Haremos que pulsando ciertas teclas podamos "rotar localmente" nuestro player, es decir, SOLO EN EL EJE Y
        if (Input.GetKey(KeyCode.E)) {
 
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
 
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }
 
      
 
        //CONTROL DEL PLANETA:
        //Aquí controlaremos y seguiremos la posición del terreno de acuerdo a nuestro player, de manera que podremos determinar
        //cuando el player está tocando el planeta/suelo o no

        //Primero instanciamos un "rayo" que permitirá medir la distancia de nuestro jugador al suelo (variable distanceToGround) e indicar cuando lo está tocando o no a través de una
        //comparación
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10)) {
 
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;
 
            if (distanceToGround <= 0.2f)
            {
                OnGround = true;
            }
            else {
                OnGround = false;
            }
 
 
        }
        //Para simular la gravedad propia del planeta y controlar a la vez su rotación, comparamos la posición del jugador con la del planeta y creamos un vector normal
        //perpendicular al planeta, de manera que el jugador siempre será "atraído por la gravedad" al planeta
 
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
 
        if (OnGround == false)
        {
            rb.AddForce(gravDirection * (-gravity));
 
        }
 
        //Rotamos el planeta a la vez que se mueve nuestro personaje
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;


        //CONTROL DE ANIMACIONES:

        //Las animaciones se activarán o desactivarán según las teclas que se vayan pulsando

        if(Input.GetKeyDown(KeyCode.W) ){

            animator.SetBool("movement",true);
            animator.SetBool("movementBack",false);
            

        }

        if(Input.GetKeyDown(KeyCode.S) ){

            animator.SetBool("movement",false);
            animator.SetBool("movementBack",true);
            

        }

        if(Input.GetKeyUp(KeyCode.W) ||Input.GetKeyUp(KeyCode.S) ){

            animator.SetBool("movement",false);
            animator.SetBool("movementBack",false);

        }
  
}
//COLISIONES Y CAMBIO DE NIVEL:
//Método que controla cuando el RigidBody y collider del jugador colisionan con otro determinado collider del mapa, pasando a una escena nueva si se da el caso
void OnCollisionEnter(Collision other){
		
        if(other.gameObject.CompareTag("Level1")){

            SceneManager.LoadScene(2);


        }



	}


}