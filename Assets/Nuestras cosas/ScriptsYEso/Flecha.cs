using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Flecha : MonoBehaviour
{
    public GameObject[] cofres= new GameObject[4];
    private Transform gemMasCercana;
    public GameObject playerAlQueSigue;
      public GameObject otroplayer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarCOfreMasCercano();
        transform.position=playerAlQueSigue.transform.position;
        Vector3 direccion= gemMasCercana.position-transform.position;
        float angle = (Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg);
           transform.rotation= Quaternion.Euler(0,0,angle);
        
    }
    void ComprobarCOfreMasCercano(){
        if(playerAlQueSigue.GetComponent<Movimiento>().llevaPieza || otroplayer.GetComponent<Movimiento>().llevaPieza){ gameObject.GetComponentInChildren<SpriteRenderer>().enabled=false;}else{
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled=true;
        }
        float distancia= Vector3.Distance(cofres[0].transform.position, transform.position);
        float tempDis=0f;
        gemMasCercana=cofres[0].transform;
        for (int i=0; i<4; i++){
      
            tempDis= Vector3.Distance(cofres[i].transform.position, transform.position);
            if(tempDis<distancia){
               
                    gemMasCercana=cofres[i].transform;
                    distancia=tempDis;
                
                

            }
        }
    }
}
