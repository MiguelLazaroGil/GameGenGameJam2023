using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Button play;
    public Button exit;
    public RectTransform ExitUI;

    // Start is called before the first frame update
    void Start()
    {
        ExitUI.gameObject.SetActive(false);
        play.onClick.AddListener(PlayButtonClicked);
        exit.onClick.AddListener(ExitButtonClicked);
    }

    private void PlayButtonClicked() {
        SceneManager.LoadScene(Escenas/Level1);
    }

    private void ExitButtonClicked() {
        ExitUI.gameObject.SetActive(true);
    }
}
