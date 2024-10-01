using UnityEngine;

public class CustomInteractor : MonoBehaviour
{
    [SerializeField]
    EHands customInteractorType;
    int indexToWearGloves = (int)EPatientNeeds.LIDOCAINE_INJECTION;



    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("ResetObjectPose"))
        {
            GetInteractingHand().SetHandInReseter(true);
        }


        if (other.gameObject.GetComponent<BasicObject>())
        {
            other.gameObject.GetComponent<BasicObject>().CustomInteractorAction(this.gameObject);

        }

        //Function used to trigger Hover outline
        if (other.gameObject.GetComponent<GrabbableObjects>())
        {
            other.gameObject.GetComponent<GrabbableObjects>().CustomHoverEnter();
        }


        if (other.gameObject.GetComponent<PatientNeedsScript>())
        {
            if (transform.root.GetComponent<RedirectionToPlayerScript>())
            {
                if (GetCurrentObjectInHand())
                {
                    PatientNeedsScript patientNeeds = other.gameObject.GetComponent<PatientNeedsScript>();

                    if (patientNeeds.GetCurrentNeedIndex() > indexToWearGloves)
                    {
                        //This line is used to get player script from any child of the character object
                        PlayerScript playerScript = transform.root.GetComponent<RedirectionToPlayerScript>().GetPlayerScript();
                        if (playerScript.GetWearGloves())
                        {
                            GetCurrentObjectInHand().TryCompleteNeed(patientNeeds);
                        }
                        else
                        {
                            AdviceScript.Instance.ShowSpecificAdviceText((int)ESpecificAdvice.PLAYER_NAKED_HAND);
                        }
                    }
                    else
                    {
                        GetCurrentObjectInHand().TryCompleteNeed(patientNeeds);
                    }
                }
            }
        }


        //Behavior done here so the syringe fills only when in player's hand
        if (other.gameObject.GetComponent<VialScripts>())
        {
            if (GetCurrentObjectInHand() != null)
            {
                if (GetCurrentObjectInHand().GetComponent<SyringeScript>())
                {
                    GetCurrentObjectInHand().GetComponent<SyringeScript>().FillSyringe(other.gameObject.GetComponent<VialScripts>().medicationType);
                }
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        //Remove hover outline
        if (other.gameObject.GetComponent<GrabbableObjects>())
        {
            other.gameObject.GetComponent<GrabbableObjects>().CustomHoverExit();
        }

        if (other.gameObject.CompareTag("ResetObjectPose"))
        {
            GetInteractingHand().SetHandInReseter(false);
        }

    }

    BasicObject GetCurrentObjectInHand()
    {
        //This line is used to get player script from any child of the character object
        PlayerScript playerScript = transform.root.GetComponent<RedirectionToPlayerScript>().GetPlayerScript();
        Hand handToInteract = null;
        BasicObject objectInHand = null;

        //Get hand then the object in this hand
        if (playerScript.hands[(int)customInteractorType].GetComponent<Hand>())
        {
            handToInteract = playerScript.hands[(int)customInteractorType].GetComponent<Hand>();
        }
        if (handToInteract && handToInteract.GetObjectInHand() && handToInteract.GetObjectInHand().GetComponent<BasicObject>())
        {
            objectInHand = handToInteract.GetObjectInHand().GetComponent<BasicObject>();
        }

        return objectInHand;
    }


    Hand GetInteractingHand()
    {
        PlayerScript playerScript = transform.root.GetComponent<RedirectionToPlayerScript>().GetPlayerScript();
        Hand handToInteract = null;

        //Get hand parent of this custom interactor
        if (playerScript.hands[(int)customInteractorType].GetComponent<Hand>())
        {
            handToInteract = playerScript.hands[(int)customInteractorType].GetComponent<Hand>();
        }

        return handToInteract;
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
