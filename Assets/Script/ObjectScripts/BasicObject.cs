using UnityEngine;

public class BasicObject : MonoBehaviour
{

    public EPatientNeeds needCompleted;

    public virtual void CustomInteractorAction(GameObject _interactor)
    {

    }

    public virtual void TryCompleteNeed(PatientNeedsScript _need)
    {
        if (_need)
        {
            _need.CompletePatientNeed(needCompleted);
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
