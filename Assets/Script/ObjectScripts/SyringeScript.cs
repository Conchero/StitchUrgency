using UnityEngine;



public class SyringeScript : GrabbableObjects
{

    EMedication syringeLiquid;

    [SerializeField]
    Renderer liquidMesh;
    [SerializeField]
    Material[] liquidMaterialArray;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FillSyringe(EMedication _liquid)
    {
        syringeLiquid = _liquid;

        liquidMesh.material = liquidMaterialArray[(int)_liquid];
    }

    public void EmptySyringe()
    {
        liquidMesh.material = liquidMaterialArray[0];
        syringeLiquid = EMedication.NONE;

    }

    //Check if the syringe have the right medication 
    public override void TryCompleteNeed(PatientNeedsScript _need)
    {
        if (syringeLiquid == EMedication.LIDOCAINE)
        {
            EmptySyringe();
            base.TryCompleteNeed(_need);
        }
        else
        {
            AdviceScript.Instance.ShowSpecificAdviceText((int)ESpecificAdvice.SYRINGE_WITH_BAD_MED);
        }

    }


}
