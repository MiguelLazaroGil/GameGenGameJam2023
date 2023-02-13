using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
        private CharacterController controller;
    public float playerSpeed = 2.0f;
    private Vector2 movimientoInput= Vector2.zero;
    private bool atacado=false;
  
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context){ //Se ejecuta cuando el jugador Se mueve. EL contexto será un Vector2
        movimientoInput= context.ReadValue<Vector2>();

    }
    public void OnAttack(InputAction.CallbackContext context){
        atacado = context.action.triggered;
        Debug.Log("Atacado");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(movimientoInput.x, movimientoInput.y, 0);
         controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
