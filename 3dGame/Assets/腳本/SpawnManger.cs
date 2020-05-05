using UnityEngine;
using System.Collections;

public class SpawnManger : MonoBehaviour
{
	public SpawnData Sdata;
	public GameManager gm;

	private void Start()
	{
		gm = FindObjectOfType<GameManager>();
		StartCoroutine("StartSpawn");
	}

	private IEnumerator StartSpawn()
	{
		for (int i = 0; i < Sdata.spawn.Length; i++)
		{
			yield return new WaitForSeconds(Sdata.spawn[i].time);
			print(Sdata.spawn[i].name);
			for (int j = 0; j < Sdata.spawn[i].monsters.Length; j++)
			{
				Vector3 posmon = new Vector3(Sdata.spawn[i].monsters[j].x, 18.5f, 50);
				Quaternion qua = Quaternion.Euler(0, 180, 0);
				Instantiate(Sdata.spawn[i].monsters[j].Monster, posmon,qua);
			}
		}

		yield return new WaitForSeconds(30);
		gm.passlv = true;
		gm.Win();
	}
}
