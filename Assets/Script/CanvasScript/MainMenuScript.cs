using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void LoadMedicalRoomScene()
    {
        GameManager.Instance.ChangeScene(EScenes.MEDICAL_ROOM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
