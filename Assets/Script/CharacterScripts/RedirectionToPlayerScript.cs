using UnityEngine;

public class RedirectionToPlayerScript : MonoBehaviour
{
    //This script is used to get player script from any child of Player
    public PlayerScript GetPlayerScript() { return playerScript; }

    [SerializeField]
    PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript playerScript = FindFirstObjectByType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
