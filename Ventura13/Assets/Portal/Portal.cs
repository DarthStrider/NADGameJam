using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public GameObject otherPortal;
    public float cooldownTime;
    public float cooldownTimer;
    public AudioSource portalSound;
    public GameObject xButton;
    private GameObject tempXButton;

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
                portalSound.Play();
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
            tempXButton = Instantiate(xButton, new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z), Quaternion.identity) as GameObject;
            tempXButton.transform.parent = GameObject.FindGameObjectWithTag("Ship").transform;
            tempPlayer = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject == tempPlayer)
        {
            Destroy(tempXButton);
            tempPlayer = null;
        }
    }
}
