using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private int NumberScene;
    [SerializeField] private float scene = 1;
    
    private float rnd;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        loadScene();
    }
    public void loadScene()
    {
        if (Input.GetKeyUp(key))
            SceneManager.LoadScene(NumberScene);
        if (Input.GetKey(KeyCode.J))
        {
            rnd = Random.Range(0, 10000);
            if(scene > rnd)
                Debug.Log("Секретный уровень");
            else
                Debug.Log("Нажми ещё раз!");
        }
    }
}
