
public class Spray : GrabbableObjects
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //override so the needs change when first one complete
    public override void TryCompleteNeed(PatientNeedsScript _need)
    {
        base.TryCompleteNeed(_need);
        if (needCompleted == EPatientNeeds.FIRST_SPRAY_DISINFECT)
        {
            needCompleted = EPatientNeeds.SECOND_SPRAY_DISINFECT;
        }
    }
}
