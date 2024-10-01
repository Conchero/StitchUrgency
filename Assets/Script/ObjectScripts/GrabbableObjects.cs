using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GrabbableObjects : BasicObject
{
    Vector3 basePosition;
    Quaternion baseRotation;
    Vector3 baseScale;




    // Start is called before the first frame update
    protected XRGrabInteractable interactableComponent;
    virtual protected void Start()
    {
        //Add behavior when grabbed and realeased
        interactableComponent = GetComponent<XRGrabInteractable>();
        interactableComponent.selectEntered.AddListener(HideController);
        interactableComponent.selectExited.AddListener(ShowController);

        basePosition = GetComponent<Transform>().position;
        baseRotation = GetComponent<Transform>().rotation;
        baseScale = GetComponent<Transform>().localScale;
    }



    GameObject currentHand = null;
    GameObject leftHandModel;
    GameObject rightHandModel;
    void HideController(SelectEnterEventArgs args)
    {

        GameObject rootObject = args.interactorObject.transform.gameObject;

        //Look if the current object is the left or right hand if not set the obj to the parent of the current obj
        if (args.interactorObject.transform.tag == "LeftHandInteractor")
        {
            while (rootObject.tag != "LeftHand")
            {
                rootObject = rootObject.transform.parent.gameObject;
            }
        }
        else if (args.interactorObject.transform.tag == "RightHandInteractor")
        {
            while (rootObject.tag != "RightHand")
            {
                rootObject = rootObject.transform.parent.gameObject;
            }
        }


        //Get all children of the current hand looking for the hand model when found set active to false
        currentHand = rootObject;
        if (currentHand.GetComponent<Hand>())
        {
            currentHand.GetComponent<Hand>().SetObjectInHand(this.gameObject);
        }
        Transform[] handChildArray = currentHand.GetComponentsInChildren<Transform>();
        foreach (Transform child in handChildArray)
        {
            switch (child.tag)
            {
                case "LeftHandModel":
                    leftHandModel = child.gameObject;
                    leftHandModel.SetActive(false);
                    break;
                case "RightHandModel":
                    rightHandModel = child.gameObject;
                    rightHandModel.SetActive(false);
                    break;
            }
        }

        //Hide Outline when grabbed
        if (GetComponent<HoverOutlineScript>())
        {
            GetComponent<HoverOutlineScript>().HideHoverOutline();
        }

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().useGravity = false;
        }

        if (GetComponent<Collider>())
        {
            GetComponent<Collider>().isTrigger = true;
        }

    }


    void ShowController(SelectExitEventArgs args)
    {
        //activate hand model on exit and loose references for security purpose
        if (leftHandModel != null)
        {
            leftHandModel.SetActive(true);
            leftHandModel = null;
        }
        else if (rightHandModel != null)
        {
            rightHandModel.SetActive(true);
            rightHandModel = null;
        }


        if (GetComponent<Collider>())
        {
            GetComponent<Collider>().isTrigger = false;
        }

        //Set it back in place if in reseter else falls to the ground
        if (currentHand.GetComponent<Hand>())
        {
            if (currentHand.GetComponent<Hand>().GetHandInReseter())
            {
                SetObjectBackInPose();
            }
            else
            {
                GetComponent<Rigidbody>().useGravity = true;
            }

            currentHand.GetComponent<Hand>().SetObjectInHand(null);
        }

        currentHand = null;
    }

    //Show hover outline
    public virtual void CustomHoverEnter()
    {
        if (currentHand == null)
        {
            if (GetComponent<HoverOutlineScript>())
            {
                GetComponent<HoverOutlineScript>().ShowHoverOutline();
            }
        }

    }

    //Hide hover outline
    public virtual void CustomHoverExit()
    {
        if (currentHand == null)
        {
            if (GetComponent<HoverOutlineScript>())
            {
                GetComponent<HoverOutlineScript>().HideHoverOutline();
            }
        }
    }

    //Set it to it's beginning transform
    protected virtual void SetObjectBackInPose()
    {
        transform.position = basePosition;
        transform.rotation = baseRotation;
        transform.localScale = baseScale;
    }





    // Update is called once per frame
    void Update()
    {

    }
}
