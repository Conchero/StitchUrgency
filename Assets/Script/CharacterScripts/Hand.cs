using UnityEngine;
public enum EHands
{
    LEFT_HAND = 0,
    RIGHT_HAND = 1,
}

public class Hand : MonoBehaviour
{

    public EHands  GetHandType() { return handType; }

    public GameObject GetObjectInHand() { return currentObjectInHand; }

    public void SetObjectInHand(GameObject newObjectInHand) { currentObjectInHand = newObjectInHand; }

    public bool GetHandInReseter() { return b_IsInReseter; }
    public void SetHandInReseter(bool _b) { b_IsInReseter = _b; }


    [SerializeField]
    EHands handType;

    [SerializeField]
    public SkinnedMeshRenderer handMeshRenderer;

    GameObject handModel;


    GameObject currentObjectInHand;

    bool b_IsInReseter;

    // Start is called before the first frame update
    void Start()
    {

        //The following code is to get the hand model 
        string tagToSearch = "";

        switch(handType)
        {
            case EHands.LEFT_HAND:
                tagToSearch = "LeftHandModel";
                break;
            case EHands.RIGHT_HAND:
                tagToSearch = "RightHandModel";
                break;
        }

        foreach (Transform transform in GetComponentsInChildren<Transform>())
        {
            if (transform.CompareTag(tagToSearch))
            {
                handModel = transform.gameObject;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
