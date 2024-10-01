using UnityEngine;


public class MedicalGloves : BasicObject, IWearable
{
    [SerializeField] Material gloveMaterial;


    public void Wear(GameObject _characterToDress)
    {
        if (_characterToDress != null)
        {
            PlayerScript player = null;

            //check if the gameobject asking to wear have the player script if not get the player script
            if (_characterToDress.GetComponent<PlayerScript>())
            {
                 player = _characterToDress.GetComponent<PlayerScript>();
               
            }
            else if (_characterToDress.transform.root.GetComponent<RedirectionToPlayerScript>())
            {
                 player = _characterToDress.transform.root.GetComponent<RedirectionToPlayerScript>().GetPlayerScript();
            }

            //once player script gotten wear gloves
            if (player != null && player.GetWearGloves() == false)
            {
                player.WearGloves(gloveMaterial);
            }
        }
    }


    public override void CustomInteractorAction(GameObject _interactor)
    {
        base.CustomInteractorAction(_interactor);
        Wear(_interactor);
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
