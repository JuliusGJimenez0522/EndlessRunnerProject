using UnityEngine;
using System.Collections;

public class StriderController : MonoBehaviour 
{
	Animator anim;



	public GameObject swordSlashPrefab = null;
	public Transform leftSpawner = null;
	public Transform rightSpawner = null;
	
	public float slashRate;
	public float nextSlash;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKeyDown (KeyCode.S)) 
		{
			gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
		}*/
		if (Input.GetKey(KeyCode.A) && Time.time >= nextSlash) 
		{
			nextSlash = Time.time + slashRate;
			Instantiate (swordSlashPrefab, leftSpawner.position, leftSpawner.rotation);
		}
		if (Input.GetKey(KeyCode.D) && Time.time >= nextSlash) 
		{
			nextSlash = Time.time + slashRate;
			Instantiate (swordSlashPrefab, rightSpawner.position, rightSpawner.rotation);
		}
	}
}
