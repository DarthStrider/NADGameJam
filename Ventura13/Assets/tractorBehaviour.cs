using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class tractorBehaviour : MonoBehaviour {
	public GameObject origin;
    public GameObject conePrefab;
     GameObject cone;
    public float coneAngle;
    public bool pressed;
    bool hitObjects;
    public float tractorBeamSpeed;
	public float tractorDistance;
	GameObject capturedObject;
    public float maxSpeed;
    List<GameObject> objects=new List<GameObject>();
    public TractorRotation tRotation;
    public string[] ignoreLayerMask;
	// Use this for initialization
	void Start () {
        //origin.transform.rotation = transform.rotation;
		pressed = false;
        hitObjects = false;
    }

    // Update is called once per frame
    public void fireTractor(Vector2 triggers)
    {
        LayerMask l = ~LayerMask.GetMask(ignoreLayerMask);

        //Debug.DrawRay(origin.transform.position, transform.up , Color.red, 30);
       // Debug.DrawRay(origin.transform.position, Quaternion.Euler(0, 0, coneAngle) * transform.up, Color.red, 30);
        //Debug.DrawRay(origin.transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up, Color.red, 30);
        if (triggers.y <= 0 && pressed == true)
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

        if (triggers.y > 0 && pressed == false)
        {
            pressed = true;
            cone = Instantiate(conePrefab, transform.position + (transform.up * 6f), transform.rotation) as GameObject;
            cone.transform.parent = origin.transform;
            RaycastHit2D hit = Physics2D.Raycast(origin.transform.position, transform.up, tractorDistance);
            if(hit.collider != null)
            {
                if(hit.collider.tag=="Obstacle" || hit.collider.tag == "Scrap")
                {
                    if (!objects.Contains(hit.collider.gameObject))
                    {
                        objects.Add(hit.collider.gameObject);
                    }
                }
            }

            RaycastHit2D leftHit = Physics2D.Raycast(origin.transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up, tractorDistance);
            if (leftHit.collider != null)
            {
                if (leftHit.collider.tag == "Obstacle" || leftHit.collider.tag == "Scrap")
                {
                    if (!objects.Contains(leftHit.collider.gameObject))
                    {
                        objects.Add(leftHit.collider.gameObject);
                    }
                }
            }
            RaycastHit2D rightHit = Physics2D.Raycast(origin.transform.position, Quaternion.Euler(0, 0, coneAngle) * transform.up, tractorDistance);
            if (rightHit.collider != null)
            {
                if (rightHit.collider.tag == "Obstacle" || rightHit.collider.tag == "Scrap")
                {
                    if (!objects.Contains(rightHit.collider.gameObject))
                    {
                        objects.Add(rightHit.collider.gameObject);
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
            RaycastHit2D hit = Physics2D.Raycast(origin.transform.position, transform.up, tractorDistance);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Obstacle" || hit.collider.tag == "Scrap")
                {
                    if (!temp.Contains(hit.collider.gameObject))
                    {
                        temp.Add(hit.collider.gameObject);
                    }
                }
            }

            RaycastHit2D leftHit = Physics2D.Raycast(origin.transform.position, Quaternion.Euler(0, 0, -coneAngle) * transform.up, tractorDistance);
            if (leftHit.collider != null)
            {
                if (leftHit.collider.tag == "Obstacle" || leftHit.collider.tag == "Scrap")
                {
                    if (!temp.Contains(leftHit.collider.gameObject))
                    {
                        temp.Add(leftHit.collider.gameObject);
                    }
                }
            }
            RaycastHit2D rightHit = Physics2D.Raycast(origin.transform.position, Quaternion.Euler(0, 0, coneAngle) * transform.up, tractorDistance);
            if (rightHit.collider != null)
            {
                if (rightHit.collider.tag == "Obstacle" || rightHit.collider.tag == "Scrap")
                {
                    if (!temp.Contains(rightHit.collider.gameObject))
                    {
                        temp.Add(rightHit.collider.gameObject);
                    }
                }
            }
            Debug.Log(objects.Count);
            foreach (GameObject obj in objects)
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
            Debug.Log(objects.Count);

            if (objects.Count > 0)
            {
                hitObjects = true;
            }
        }

        if (hitObjects == true)
        {
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