using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    public int player;
    public GameObject arma1;
    public GameObject arma2;
    public GameObject ArmaCogida;

    private float angulo;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1){
            /*ArmaCogida.SetActive(false);
            arma1.SetActive(true);
            StartCoroutine(Temporizador(0.5));
            arma1.SetActive(false);
            arma1.SetActive(true);
           StartCoroutine(Temporizador(0.5));
            for(int i = 0; i <= 360; i + 10){
            transform.rotation= Quaternion.Euler(0,0,i);
            }*/
        } else{
            
        }

         
    }

    private IEnumerator Temporizador(float segundos){
        
        yield return new WaitForSeconds(segundos);
        

    }
}
