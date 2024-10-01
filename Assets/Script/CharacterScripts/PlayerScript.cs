using UnityEngine;



public class PlayerScript : MonoBehaviour
{

    public GameObject[] hands = new GameObject[2];


    public bool GetWearGloves() { return wearGloves; }

    bool wearGloves;

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor for ergonomy and get hands references
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hands = new GameObject[2];

        foreach (Hand hand in GetComponentsInChildren<Hand>())
        {
            hands[(int)hand.GetHandType()] = hand.gameObject;
        }

    }



    public void WearGloves(Material _gM)
    {
        wearGloves = true;

        foreach (GameObject hand in hands)
        {
            hand.GetComponent<Hand>().handMeshRenderer.material = _gM;
        }
    }





    // Update is called once per frame
    void Update()
    {

    }
}
