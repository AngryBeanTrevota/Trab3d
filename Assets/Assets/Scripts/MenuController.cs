using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioHandler audioHandler;
    private void Awake()
    {
        Screen.SetResolution(1280, 720, false);
    }
    void Start()
    {
        audioHandler = FindObjectOfType<AudioHandler>();
        audioHandler.Play("glockInMyRari");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(1);
        audioHandler.Stop("glockInMyRari");
    }


    public void Exit()
    {
        Application.Quit();
    }
}
