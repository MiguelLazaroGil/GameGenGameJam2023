using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mvtoenemigo : MonoBehaviour
{
    //variables
    public Transform personaje;
    private NavMeshAgent agente;
    public Transform [] puntosRuta;
    private int indiceRuta;
    private bool objetivoDetectado; 
    private SpriteRenderer sprite;
    private Transform objetivo;


    private void Awake()
    {
        agente= GetComponent<NavMeshAgent>();
        sprite= GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        agente.updateRotation=false;
        agente.updateUpAxis=false;
    }

    private void Update()
    {
        this.transform.position = new Vector3 (transform.position.x,transform.position.y,0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);
        if (this.transform.position == puntosRuta[indiceRuta].position)
        {
            if(indiceRuta<puntosRuta.Length -1){
                indiceRuta++;
            }
            else if (indiceRuta == puntosRuta.Length -1)
            {
                indiceRuta=0;
            }
        }
        if (distancia<2){
            objetivoDetectado=true;
        }
    
        MovimientoEnemigo(objetivoDetectado);
        RotarEnemigo ();
    }
    void MovimientoEnemigo(bool esDetectado)
    {
        if (esDetectado)
        {
            agente.SetDestination(personaje.position);
            objetivo=personaje;
        }
        else
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            objetivo=puntosRuta[indiceRuta];
        }
    }
    void RotarEnemigo ()
    {
        if (this.transform.position.x > objetivo.position.x)
        {
            sprite.flipX=true;
        }
        else
        {
            sprite.flipX=false;
        }
    }
    
}
