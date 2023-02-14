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
    private Vector2 movimientoInput= Vector2.zero;
    private bool atacado=false;
    private bool puedeMover=true; //Se pondrá en false cuando le golpeen. Durante el golpe si le empujan y el aturdimiento
  
    void Start()
    {
       
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
      // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(movimientoInput.x, movimientoInput.y, 0);

        if(puedeMover){
           rb.velocity= move * playerSpeed;
        }
        
   
    }

    public void OnMove(InputAction.CallbackContext context){ //Se ejecuta cuando el jugador Se mueve. EL contexto será un Vector2
        movimientoInput= context.ReadValue<Vector2>();

    }
    public void OnAttack(InputAction.CallbackContext context){
        if(!puedeMover){ return;}
        atacado = context.action.triggered;
        hitBox.SetActive(true);
        rb.velocity+=new Vector2(0.01f, 0.01f); //Le meto un pelin de velocidad para que haga el check de la collision (que habia un bug cuando atacabas parado).Esto no es definitivo obv, Si cambiamos el sistema de ataque quitamos esta tonteria

       

    }
    public void Empujado(Vector3 posicion, float empuje){ //Cuando un enemigo o aliado le golpea y hace un empujón
        Debug.Log("Empujado" + gameObject.name);
        Vector3 impulso3d= transform.position-posicion; //Cuando veamos 
        Vector3.Normalize(impulso3d); //Cojo sólo la direccion del golpe
        impulso3d*= empuje; //Multiplico la direccion del empuje por el impulso que queremos que de
       
        puedeMover=false; //Esto va a pasar a la corrutina
        rb.velocity+= new Vector2(impulso3d.x, impulso3d.y);
         StartCoroutine(TemporizadorInmovil(0.3f));
    }
    public void Aturdido(){

    }
    private IEnumerator TemporizadorInmovil(float segundos){
        puedeMover=false;
        yield return new WaitForSeconds(segundos);
        puedeMover=true;

    }

    public void OnTriggerEnter2D(Collider2D col){
       // El codigo que habia aqui ahora está en el hitbox
    }
  
}
