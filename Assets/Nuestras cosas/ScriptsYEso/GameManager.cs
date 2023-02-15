using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int piezasentregadas=0; //Cuando seentreguen todas se acaba el juego supongo
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate=60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void entregarpieza(){
        piezasentregadas++;
        if(piezasentregadas==4){
            AcabarJuego();
        }
    }
    private void AcabarJuego(){
        SceneManager.LoadScene(0); //Esto te lleva ala menu. Pero habría que poner una animación o algo y eso. Se puede cambiar a uqe sean los creditos.
    }
}
