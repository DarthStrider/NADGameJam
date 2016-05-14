using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public GameObject otherPortal;
    public float cooldownTime;
    public float cooldownTimer;

    private GameObject tempPlayer;
    // Use this for initialization
    void Start ()
    {    
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(tempPlayer != null && cooldownTimer <= 0.0f)
        {
            if (Input.GetButton("X" + tempPlayer.GetComponent<PlayerMovement>().getPlayerNumber()))
            {
                tempPlayer.transform.position = otherPortal.transform.position;
                cooldownTimer = cooldownTime;
                otherPortal.GetComponent<Portal>().cooldownTimer = cooldownTime;
            }
        }
        else if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && tempPlayer == null)
        {
            tempPlayer = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == tempPlayer)
        {
            tempPlayer = null;
        }
    }
}
