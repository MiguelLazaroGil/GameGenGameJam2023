using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBoxScript : MonoBehaviour
{
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
            col.gameObject.GetComponent<Movimiento>().Empujado(transform.position, 15);
    
            Debug.Log("Golpeado");
        }

    }
}
