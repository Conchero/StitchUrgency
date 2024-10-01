using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum EScenes
{
    MENU,
    MEDICAL_ROOM,
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    float timerBeforeSceneLoad;
    EScenes sceneToGo;
    bool readyToSwitch;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
    }


    public void ChangeScene(EScenes _scene, float _timeBeforeSwitch = 0.0f)
    {
        sceneToGo = _scene;
        timerBeforeSceneLoad = _timeBeforeSwitch;
        readyToSwitch = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToSwitch)
        {
            timerBeforeSceneLoad -= Time.deltaTime;
            if (timerBeforeSceneLoad <= 0.0f)
            {
                readyToSwitch = false;
                SceneManager.LoadScene((int)sceneToGo);
            }
        }
        
    }
}
