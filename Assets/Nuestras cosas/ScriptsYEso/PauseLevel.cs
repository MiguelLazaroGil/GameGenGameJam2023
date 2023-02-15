using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLevel : MonoBehaviour
{
    public Button exitSi;
     public RectTransform ExitUI;
    public Button exitNo;
    // Start is called before the first frame update
    void Start()
    {
           exitSi.onClick.AddListener(Salir_Si);
        exitNo.onClick.AddListener(Salir_No);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale==1){
                 PauseGame();
                 ExitUI.gameObject.SetActive(true);
            }else{
                ResumeGame();
                ExitUI.gameObject.SetActive(false);
            }
           
        }
    }
    
    public void Salir_Si(){
        Application.Quit(0);
    }
    public void Salir_No(){
        ExitUI.gameObject.SetActive(false);
        ResumeGame();

    }
    void PauseGame ()
    {
        Time.timeScale = 0;
    }
void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
