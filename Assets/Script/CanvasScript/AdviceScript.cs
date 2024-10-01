using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum ESpecificAdvice
{
    SYRINGE_WITH_BAD_MED,
    PLAYER_NAKED_HAND,
    MAX,
}
public class AdviceScript : MonoBehaviour
{

    public static AdviceScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    [SerializeField]
    Sprite happySnakeImage;
    [SerializeField]
    Sprite angrySnakeImage;

    [SerializeField]
    Image adviceSnake;
    [SerializeField]
    Image adviceSpeechBubble;
    [SerializeField]
    TextMeshProUGUI adviceText;


    bool b_textIsShowing;

    [SerializeField]
    float textShowTimeValue = 5.0f;
    float textShowTimer = 0.0f;

    public string[] PatientSuccessArray;
    public string[] PatientFailArray;
    public string[] SpecificAdviceArray;
    // Start is called before the first frame update
    void Start()
    {

        PatientSuccessArray = new string[((int)EPatientNeeds.MAX)];
        PatientFailArray = new string[((int)EPatientNeeds.MAX)];
        SpecificAdviceArray = new string[(int)ESpecificAdvice.MAX];

        PatientSuccessArray[(int)EPatientNeeds.FIRST_SPRAY_DISINFECT] = "Congratulation! Now you should clean the debris.";
        PatientSuccessArray[(int)EPatientNeeds.CLEAN_WOUND_WITH_PAD] = "The wound is clean from debris but not clean yet";
        PatientSuccessArray[(int)EPatientNeeds.SECOND_SPRAY_DISINFECT] = "The wound is totally clean now but stitching can be painful";
        PatientSuccessArray[(int)EPatientNeeds.LIDOCAINE_INJECTION] = "The patient is locally numbed you can stitch the wound";
        PatientSuccessArray[(int)EPatientNeeds.STERILE_SHEET_APPLIED] = "Bravo! You didn't forget to make the environment sterile";
        PatientSuccessArray[(int)EPatientNeeds.HAVE_NEEDLE_AND_THREAD] = "Excellent! The wound is stitched, a new patient will come in a few seconds";

        PatientFailArray[(int)EPatientNeeds.FIRST_SPRAY_DISINFECT] = "Mmmh maybe you should disinfect the wound..";
        PatientFailArray[(int)EPatientNeeds.CLEAN_WOUND_WITH_PAD] = "There's still debris in a compress should do the trick";
        PatientFailArray[(int)EPatientNeeds.SECOND_SPRAY_DISINFECT] = "With the compress applied you should disinfect it again";
        PatientFailArray[(int)EPatientNeeds.LIDOCAINE_INJECTION] = "Stitching is painful a injection of a medication is required";
        PatientFailArray[(int)EPatientNeeds.STERILE_SHEET_APPLIED] = "It could be deadly to not apply something sterile";
        PatientFailArray[(int)EPatientNeeds.HAVE_NEEDLE_AND_THREAD] = "Stitching a wound is like using your grandma's spool";

        SpecificAdviceArray[(int)ESpecificAdvice.SYRINGE_WITH_BAD_MED] = "What are you doing ? This is the bad medication !";
        SpecificAdviceArray[(int)ESpecificAdvice.PLAYER_NAKED_HAND] = "Not having gloves while the clean is clean is a waste of time";

        HideAdvice();
    }


    public void ShowTaskSuccessText(int _i)
    {
        adviceSnake.sprite = happySnakeImage;
        adviceText.text = PatientSuccessArray[_i];

        adviceSnake.enabled = true;
        adviceSpeechBubble.enabled = true;
        adviceText.enabled = true;

        textShowTimer = textShowTimeValue;
        b_textIsShowing = true;
    }

    public void ShowTaskFailText(int _i)
    {
        adviceSnake.sprite = angrySnakeImage;
        adviceText.text = PatientFailArray[_i];

        adviceSnake.enabled = true;
        adviceSpeechBubble.enabled = true;
        adviceText.enabled = true;

        textShowTimer = textShowTimeValue;
        b_textIsShowing = true;
    }

    //bool is here in case a non negative specific advice is added
    public void ShowSpecificAdviceText(int _i, bool _mistake = true)
    {
        if (_mistake)
        {
            adviceSnake.sprite = angrySnakeImage;
        }
        else
        {
            adviceSnake.sprite = happySnakeImage;
        }

        adviceText.text = SpecificAdviceArray[_i];

        adviceSnake.enabled = true;
        adviceSpeechBubble.enabled = true;
        adviceText.enabled = true;

        textShowTimer = textShowTimeValue;
        b_textIsShowing = true;
    }


    public void HideAdvice()
    {
        adviceSnake.enabled = false;
        adviceSpeechBubble.enabled = false;
        adviceText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (b_textIsShowing)
        {
            textShowTimer -= Time.deltaTime;
            if (textShowTimer <= 0)
            {
                HideAdvice();
            }

        }
    }
}
