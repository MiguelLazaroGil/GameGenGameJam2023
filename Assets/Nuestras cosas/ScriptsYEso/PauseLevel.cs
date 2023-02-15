using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseLevel : MonoBehaviour
{
    public Button Continue;
     public RectTransform ExitUI;
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
           exit.onClick.AddListener(Salir_Si);
        Continue.onClick.AddListener(Salir_No);
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
        SceneManager.LoadScene(0);
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
