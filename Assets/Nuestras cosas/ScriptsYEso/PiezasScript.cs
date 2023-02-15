using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PiezasScript : MonoBehaviour
{
    public Transform ubicacionobjetivo;
    public Vector3 posicionpadre;
    public GameObject GM;
    private bool piezaCogida=true;
    public int codigo= 1; //Codigo de la pieza: 1cubo, 2circulo, 3 estrella 4 triangulo
    // Start is called before the first frame update
    void Start()
    {
        posicionpadre=gameObject.GetComponentInParent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(piezaCogida){

        
        transform.rotation=ubicacionobjetivo.rotation;
        transform.position=ubicacionobjetivo.position;

        }
    }
    public void robar(Transform transformobjetivo){
        ubicacionobjetivo=transformobjetivo;
        piezaCogida=true;
    }
    public void entregarGoblin(){
        ubicacionobjetivo=gameObject.GetComponentInParent<Transform>(); //lo devulve al cofre original
        transform.rotation=ubicacionobjetivo.rotation;
        transform.position=ubicacionobjetivo.position;
    }
    public void entregarPlayer(){
        //Aquí habria que poner una animacion y eso.
        GM.GetComponent<GameManager>().entregarpieza();
        Destroy(gameObject, 2);
    }
}
