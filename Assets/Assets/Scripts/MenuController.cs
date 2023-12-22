using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Screen.SetResolution(1280, 720, false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(1);

    }


    public void Exit()
    {
        Application.Quit();
    }
}
