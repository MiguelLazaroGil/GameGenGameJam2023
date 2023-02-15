using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hitBox; 

    
    private Rigidbody2D rb;
    public float playerSpeed = 2.0f;
    public float playerSpeedPieza = 1.5f;
    public float currentSpeed;
    public float tiempoAturdidoEmpujado= 0.5f;
    public float tiempoAturdidoGolpeado=0.75f;
    public float tiempoRecargaAtaque=1f;
    public bool llevaPieza=false;

    private float tiempodeAtaqueRestante;
    private bool puedeAtacar=true;
    private bool puedeMover=true; //Se pondrá en false cuando le golpeen. Durante el golpe si le empujan y el aturdimiento
        private Vector2 movimientoInput= Vector2.zero;
  
    void Start()
    {
       tiempodeAtaqueRestante=tiempoRecargaAtaque;
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentSpeed=playerSpeed;
    }
      // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(movimientoInput.x, movimientoInput.y, 0);

        if(puedeMover){
            //Cosas del movimiento
            rb.velocity= move * currentSpeed;
            if(move.sqrMagnitude>0.1){
                float angle = (Mathf.Atan2(movimientoInput.y, movimientoInput.x) * Mathf.Rad2Deg)+90;
           transform.rotation= Quaternion.Euler(0,0,angle);
            }
           


           //Cosas del ataque
           if(!puedeAtacar && tiempodeAtaqueRestante>0&& !llevaPieza){ //recargo el ataque sólo cuando se puede mover y aacar, y cuando no lo tenga cargado ya.
                tiempodeAtaqueRestante-=Time.deltaTime;
                if(tiempodeAtaqueRestante<=0){ //si ya no queda tiempo de recagr, podrá atacar
                    puedeAtacar=true;
                }
           }
        }
        
   
    }

    public void OnMove(InputAction.CallbackContext context){ //Se ejecuta cuando el jugador Se mueve. EL contexto será un Vector2
        movimientoInput= context.ReadValue<Vector2>();

    }
    public void OnAttack(InputAction.CallbackContext context){

        if(!puedeAtacar){ return;}
        Debug.Log("Ha atacado"+ gameObject.name);
        puedeAtacar = !context.action.triggered;
     //TODO esto hay que cambiarlo por la animción
        StartCoroutine(AtaqueSprite());
        rb.velocity+=new Vector2(0.01f, 0.01f); //Le meto un pelin de velocidad para que haga el check de la collision (que habia un bug cuando atacabas parado).Esto no es definitivo obv, Si cambiamos el sistema de ataque quitamos esta tonteria

        puedeAtacar=false;
        tiempodeAtaqueRestante=tiempoRecargaAtaque; //inicio el contador del ataque
       
    }
    public void Empujado(Vector3 posicion, float extraempuje){ //Cuando un enemigo o aliado le golpea y hace un empujón. SIN ANIMACION


        //Calculo del impulso
        Vector3 impulso3d= transform.position-posicion; //Cuando veamos 
        Vector3.Normalize(impulso3d); //Cojo sólo la direccion del golpe
        impulso3d*= 15+extraempuje; //Multiplico la direccion del empuje por el impulso que queremos que dé. El 15 es el empuje base
              rb.velocity= new Vector2(impulso3d.x, impulso3d.y);
       
       // Consecuencias
   
         StartCoroutine(TemporizadorInmovil(segundos: tiempoAturdidoEmpujado));
    }
    public void Aturdido(float extrastun){ //Cuando un jefe o tu compañero te aturde con un golpe, aturdir y golpear se confunde en estos caso (está mal progrmado por mi parte, sorry) CON ANIMACION
        //Aqui haced lo de la animacion

        //Consecuencias
  
        StartCoroutine(TemporizadorInmovil(segundos: tiempoAturdidoGolpeado+extrastun));



    }
    public void CogerPieza(){
        llevaPieza=true;
        puedeAtacar=false;
        currentSpeed=playerSpeedPieza;
        
    }
    public void QuitarPieza(){
        if(!llevaPieza){return;}
        llevaPieza=false;
        
        currentSpeed=playerSpeed;
        
        //Apagar todas las piezas, depende de cómo lo hagamos
        
    }
    private IEnumerator TemporizadorInmovil(float segundos){
        puedeMover=false;
        puedeAtacar=false;
        yield return new WaitForSeconds(segundos);
        puedeMover=true;
        puedeAtacar=true;

    }
    private IEnumerator AtaqueSprite(){
           hitBox.SetActive(true);
        yield return new WaitForSeconds(0.25f);
           hitBox.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D col){
       // El codigo que habia aqui ahora está en el hitbox
    }
  
}
