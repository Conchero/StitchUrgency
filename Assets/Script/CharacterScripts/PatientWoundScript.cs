using UnityEngine;

public class PatientWoundScript : MonoBehaviour
{
    [SerializeField]
    Material woundOpen;

    [SerializeField]
    Material woundClosed;

    //Change material of the wound when all patient's needs are complete
    public void SetWoundState(bool _closed)
    {
        if (_closed)
        {
            GetComponent<Renderer>().material = woundClosed;
        }
        else
        {
            GetComponent<Renderer>().material = woundOpen;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
