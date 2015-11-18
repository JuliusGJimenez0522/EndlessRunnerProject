using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject enemy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-3.9f, 9.0f), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
