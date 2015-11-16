using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter(Collider2D other)
	{
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
