using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBoxScript : MonoBehaviour
{
    public bool empuja;
    public float extrastun;
    public float extraempuje;
    // Start is called before the first frame update
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
         Debug.Log("Colision");
        if(col.gameObject.CompareTag("Player")){
            if(empuja){
                 col.gameObject.GetComponent<Movimiento>().Empujado(transform.position, extraempuje);        
            }else{ //Si sólo aturde
                col.gameObject.GetComponent<Movimiento>().Aturdido(extrastun); 
            }
           
    
            Debug.Log("Golpeado");
        }

    }
}
