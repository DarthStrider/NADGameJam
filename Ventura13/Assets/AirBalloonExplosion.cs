using UnityEngine;
using System.Collections;

public class AirBalloonExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public GameObject exAnim;
    float timer = 0;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            GameObject a = Instantiate(exAnim, new Vector3(transform.position.x + 3, transform.position.y + 3, transform.position.z), Quaternion.identity) as GameObject;
            a.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            Destroy(a, .63f);
        }
        else if (timer > 0.1 && timer < 0.2f)
        {
            GameObject b = Instantiate(exAnim, new Vector3(transform.position.x - 2, transform.position.y - 1, transform.position.z), Quaternion.identity) as GameObject;
            b.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            Destroy(b, .83f);
        }
        else if (timer > 0.2 && timer < 0.3f)
        {
            GameObject c = Instantiate(exAnim, new Vector3(transform.position.x - 4, transform.position.y + 2, transform.position.z), Quaternion.identity) as GameObject;
            c.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            Destroy(c, .83f);
        }
        else if (timer > 0.3 && timer < 0.4f)
        {
            GameObject d = Instantiate(exAnim, new Vector3(transform.position.x + 3, transform.position.y + 3, transform.position.z), Quaternion.identity) as GameObject;
            d.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            Destroy(d, .83f);
        }
        else if (timer > 0.4 && timer < 0.5f)
        {
            GameObject e = Instantiate(exAnim, new Vector3(transform.position.x + 1, transform.position.y - 3, transform.position.z), Quaternion.identity) as GameObject;
            e.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Destroy(e, .83f);
        }
        else if (timer > 0.5f && timer < 0.6f)
        {
            GameObject f = Instantiate(exAnim, new Vector3(transform.position.x - 4, transform.position.y - 2, transform.position.z), Quaternion.identity) as GameObject;
            f.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Destroy(f, .83f);
        }
        else if (timer > 0.7 && timer < 0.8f)
        {
            GameObject g = Instantiate(exAnim, new Vector3(transform.position.x + 3, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
            g.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Destroy(g, .83f);
        }
        else if (timer > 0.8 && timer < 0.9f)
        {
            GameObject h = Instantiate(exAnim, new Vector3(transform.position.x + .5f, transform.position.y - 2, transform.position.z), Quaternion.identity) as GameObject;
            h.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Destroy(h, .83f);
        }
        else if (timer > 1 && timer < 1.1f)
        {
            GameObject i = Instantiate(exAnim, new Vector3(transform.position.x + 2, transform.position.y - 1, transform.position.z), Quaternion.identity) as GameObject;
            i.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Destroy(i, .83f);
        }
        else if (timer > 1.1 && timer < 1.2f)
        {
            GameObject j = Instantiate(exAnim, new Vector3(transform.position.x + .2f, transform.position.y + 2, transform.position.z), Quaternion.identity) as GameObject;
            j.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Destroy(j, .83f);
        }
        timer += Time.deltaTime;

    }
}
