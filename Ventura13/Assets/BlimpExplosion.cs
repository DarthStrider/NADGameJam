using UnityEngine;
using System.Collections;

public class BlimpExplosion : MonoBehaviour {
    public GameObject exAnim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject a = Instantiate(exAnim, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(a, .83f);
        GameObject b = Instantiate(exAnim, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(b, .83f);
        GameObject c = Instantiate(exAnim, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(c, .83f);
        GameObject d = Instantiate(exAnim, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(d, .83f);
        GameObject e = Instantiate(exAnim, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(e, .83f);
        GameObject f = Instantiate(exAnim, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(f, .83f);
        GameObject g = Instantiate(exAnim, new Vector3(transform.position.x + 1.2f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
        Destroy(g, .83f);
    }
}
