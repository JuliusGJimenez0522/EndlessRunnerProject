using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float jumpHeight = 25.0f;
	public Rigidbody rb;

	public bool isFalling = false;

	public GameObject swordSlashPrefab = null;
	public Transform leftSpawner = null;
	public Transform rightSpawner = null;

	public float slashRate;
	public float nextSlash;
	
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.Space) && isFalling == false)
		{
			rb.velocity = new Vector3 (0, jumpHeight, 0);
			isFalling = true;
		}
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
	void OnCollisionStay (Collision collisionInfo)
	{
		isFalling = false;
	}
}
