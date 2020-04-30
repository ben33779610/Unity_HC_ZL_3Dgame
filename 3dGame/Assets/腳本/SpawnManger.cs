using UnityEngine;
using System.Collections;

public class SpawnManger : MonoBehaviour
{
	public SpawnData Sdata;
	private Vector3 posmon;
	private void Start()
	{
		
	}

	private IEnumerator StartSpawn()
	{
		for (int i = 0; i < Sdata.spawn.Length; i++)
		{
			yield return new WaitForSeconds(Sdata.spawn[i].time);
			print(Sdata.spawn[i].name);
			for (int y = 0; y < Sdata.spawn[i].monsters.Length; y++)
			{
				posmon = new Vector3(Sdata.spawn[i].monsters[i].x, 19.02f, 15);
				//Instantiate(Sdata.spawn[i].monsters[i].Monster, posmon);
			}
		}
	}
}
