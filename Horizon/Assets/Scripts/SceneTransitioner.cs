using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public string sceneToGoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transitionScene();
    }

    public void transitionScene()
    {
        SceneManager.LoadScene(sceneToGoTo);
    }
}
