using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class tractorBehaviour : MonoBehaviour {
	public GameObject origin;
    public GameObject conePrefab;
     GameObject cone;
    public float coneAngle;
    bool pressed;
    bool hitObjects;
    public float tractorBeamSpeed;
	public float tractorDistance;
	GameObject capturedObject;
    public float maxSpeed;
    List<GameObject> objects=new List<GameObject>();
	// Use this for initialization
	void Start () {
        //origin.transform.rotation = transform.rotation;
		pressed = false;
        hitObjects = false;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(origin.transform.position, transform.up , Color.red, 30);
        Debug.DrawRay(origin.transform.position, Quaternion.Euler(0, 0, coneAngle) * transform.up, Color.red, 30);
        Debug.DrawRay(origin.transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up, Color.red, 30);
        if (Input.GetAxis("RT1") <= 0 && pressed == true)
        {
            pressed = false;
            hitObjects = false;
            if (objects.Count > 0)
            {
                foreach (GameObject obj in objects)
                {
                    if (obj.tag == "Obstacle")
                    {
                        obj.GetComponent<ObstacleMovement>().tractorBeamed = false;
                        obj.GetComponent<ObstacleMovement>().first = false;

                    }
                }
                objects.Clear();
            }
            Destroy(cone);

        }

        if (Input.GetAxis("RT1") > 0 && pressed == false)
        {
            pressed = true;
            cone = Instantiate(conePrefab, transform.position + (transform.up * 6.7f), transform.rotation) as GameObject;
            cone.transform.parent = origin.transform;
            RaycastHit2D[] hits = Physics2D.RaycastAll(origin.transform.position, transform.up, tractorDistance);
            foreach(RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "Obstacle")
                    {
                        hit.transform.gameObject.GetComponent<ObstacleMovement>().tractorBeamed = true;
                    }
                    objects.Add(hit.collider.gameObject);
                }
            }
            RaycastHit2D[] leftHits = Physics2D.RaycastAll(origin.transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up, tractorDistance);
            foreach (RaycastHit2D hit in leftHits)
            {
                if (hit.collider != null)
                {
                    if (!objects.Contains(hit.collider.gameObject))
                    {
                        if (hit.transform.tag == "Obstacle")
                        {
                            hit.transform.gameObject.GetComponent<ObstacleMovement>().tractorBeamed = true;
                        }
                        objects.Add(hit.collider.gameObject);
                    }
                }
            }
            RaycastHit2D[] rightHits = Physics2D.RaycastAll(origin.transform.position, Quaternion.Euler(0, 0, coneAngle) * transform.up, tractorDistance);
            foreach (RaycastHit2D hit in rightHits)
            {
                if (hit.collider != null)
                {
                    if (!objects.Contains(hit.collider.gameObject))
                    {
                        if (hit.transform.tag == "Obstacle")
                        {
                            hit.transform.gameObject.GetComponent<ObstacleMovement>().tractorBeamed = true;
                        }
                        objects.Add(hit.collider.gameObject);
                    }
                }
            }
            if (objects.Count > 0)
            {
                hitObjects = true;
            }
        }

        if (pressed == true)
        {
            List<GameObject> temp = new List<GameObject>();
            RaycastHit2D[] hits = Physics2D.RaycastAll(origin.transform.position, transform.up, tractorDistance);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "Obstacle")
                    {
                        hit.transform.gameObject.GetComponent<ObstacleMovement>().tractorBeamed = true;
                    }
                    temp.Add(hit.collider.gameObject);
                }
            }
            RaycastHit2D[] leftHits = Physics2D.RaycastAll(origin.transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up, tractorDistance);
            foreach (RaycastHit2D hit in leftHits)
            {
                if (hit.collider != null)
                {
                    if (!temp.Contains(hit.collider.gameObject))
                    {
                        if (hit.transform.tag == "Obstacle")
                        {
                            hit.transform.gameObject.GetComponent<ObstacleMovement>().tractorBeamed = true;
                        }
                        temp.Add(hit.collider.gameObject);
                    }
                }
            }
            RaycastHit2D[] rightHits = Physics2D.RaycastAll(origin.transform.position, Quaternion.Euler(0, 0, coneAngle) * transform.up, tractorDistance);
            foreach (RaycastHit2D hit in rightHits)
            {
                if (hit.collider != null)
                {
                    if (!temp.Contains(hit.collider.gameObject))
                    {
                        if (hit.transform.tag == "Obstacle")
                        {
                            hit.transform.gameObject.GetComponent<ObstacleMovement>().tractorBeamed = true;
                        }
                        temp.Add(hit.collider.gameObject);
                    }
                }
            }
            foreach(GameObject obj in objects)
            {
                if (!temp.Contains(obj))
                {
                    if (obj.tag == "Obstacle")
                    {
                        obj.GetComponent<ObstacleMovement>().tractorBeamed = false;
                        obj.GetComponent<ObstacleMovement>().first = false;

                    }
                    objects.Remove(obj);
                }
              
            }
            objects.Clear();
            objects = temp;
            if (objects.Count > 0)
            {
                hitObjects = true;
            }
        }

        if (hitObjects == true)
        {
            Debug.Log(objects.Count);
            foreach(GameObject obj in objects){
                //obj.transform.position = Vector3.MoveTowards(obj.transform.position, transform.gameObject.transform.position, 2 * Time.deltaTime);
                Vector2 targetToBeam =  origin.transform.position - obj.transform.position;
                targetToBeam.Normalize();
                obj.GetComponent<Rigidbody2D>().AddForce(targetToBeam * (tractorBeamSpeed * Time.deltaTime));
                if (obj.GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
                {
                    Vector2 velocityNormalized = obj.GetComponent<Rigidbody2D>().velocity.normalized;
                    obj.GetComponent<Rigidbody2D>().velocity = velocityNormalized * maxSpeed;
                }


            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Scrap" && hitObjects == true)
        {
            objects.Remove(col.gameObject);
            Destroy(col.gameObject);
        }
        if (col.tag == "Obstacle" && hitObjects == true)
        {
            objects.Remove(col.gameObject);
            Destroy(col.gameObject);
            
        }
    }

	

}