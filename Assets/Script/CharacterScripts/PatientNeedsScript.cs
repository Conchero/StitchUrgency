using UnityEngine;

public enum EPatientNeeds
{
    FIRST_SPRAY_DISINFECT,
    CLEAN_WOUND_WITH_PAD,
    SECOND_SPRAY_DISINFECT,
    LIDOCAINE_INJECTION,
    STERILE_SHEET_APPLIED,
    HAVE_NEEDLE_AND_THREAD,
    MAX
}

public class PatientNeedsScript : MonoBehaviour
{

    public int GetCurrentNeedIndex() { return currentNeed; }

    [SerializeField]
    bool[] patientNeedsCheckArray;
    int currentNeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Create patient needs array and set it all to false
        patientNeedsCheckArray = new bool[(int)EPatientNeeds.MAX];
        for (int i = 0; i < patientNeedsCheckArray.Length; i++)
        {
            patientNeedsCheckArray[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CompletePatientNeed(EPatientNeeds _pn)
    {
        //Check if the given need is the correct one if yes check the current and go to the next one
        if ((int)_pn == currentNeed)
        {

            patientNeedsCheckArray[currentNeed] = true;

            if (currentNeed == (int)EPatientNeeds.STERILE_SHEET_APPLIED)
            {
                ActivateSterileSheet();
            }

            AdviceScript.Instance.ShowTaskSuccessText(currentNeed);

            PlayPatientAnimation(true);

            currentNeed++;
        }
        else
        {
            PlayPatientAnimation(false);
            AdviceScript.Instance.ShowTaskFailText(currentNeed);
        }

        //Win behavior
        if (currentNeed >= patientNeedsCheckArray.Length)
        {
            if (transform.root.GetComponent<PatientScript>())
            {
                transform.root.GetComponent<PatientScript>().PatientWoundScript.SetWoundState(true);
            }
            GameManager.Instance.ChangeScene(EScenes.MENU, 5.0f);
        }
    }

    //Patient Animation
    void PlayPatientAnimation(bool _success)
    {
        if (transform.root.GetComponent<Animator>())
        {

            if (_success)
            {
                transform.root.GetComponent<Animator>().Play("PatientYes");
            }
            else
            {
                transform.root.GetComponent<Animator>().Play("PatientNo");
            }
        }
    }


    void ActivateSterileSheet()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>(true))
        {
            if (t.CompareTag("SterileSheetPatient"))
            {
                t.gameObject.SetActive(true);
            }
        }
    }

}
