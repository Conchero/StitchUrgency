using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableFromStack : GrabbableObjects
{

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();

        if (interactableComponent)
        {
            interactableComponent.selectEntered.AddListener(ShowObject);
        }
    }


    void ShowObject(SelectEnterEventArgs args)
    {
        if (GetComponent<MeshRenderer>())
            GetComponent<MeshRenderer>().enabled = true;
    }


    void HideObject()
    {
        if (GetComponent<MeshRenderer>())
            GetComponent<MeshRenderer>().enabled = false;
    }

    //Hide the object + set it back in place
    protected override void SetObjectBackInPose()
    {
        base.SetObjectBackInPose();
        HideObject();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
