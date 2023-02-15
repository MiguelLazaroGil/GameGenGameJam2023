using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button play;
    public Button exit;
    public Button exitSi;
    public Button exitNo;
    public RectTransform ExitUI;

    // Start is called before the first frame update
    void Start()
    {
        ExitUI.gameObject.SetActive(false);
        play.onClick.AddListener(PlayButtonClicked);
        exit.onClick.AddListener(ExitButtonClicked);
        exitSi.onClick.AddListener(Salir_Si);
        exitNo.onClick.AddListener(Salir_No);
    }

    private void PlayButtonClicked() {
        SceneManager.LoadScene(2);
    }

    private void ExitButtonClicked() {
        ExitUI.gameObject.SetActive(true);
    }
    public void Salir_Si(){
        Application.Quit(0);
    }
    public void Salir_No(){
        ExitUI.gameObject.SetActive(false);

    }
}
