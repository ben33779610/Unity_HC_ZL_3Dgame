using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("地板陣列")]
	public Transform[] ter;
	[Header("移動速度")]
	[Range(1f, 50f)]
	public float movespeed = 1.5f;

	/// <summary>
	/// 移動地板
	/// </summary>
	public void MoveTerrain()
	{
		for (int i = 0; i < ter.Length; i++)
		{
			if (ter[i].position.z < -100)
			{
				ter[i].position = new Vector3(0, 0, ter[1 - i].position.z + 100);
			}
			ter[i].Translate(0, 0, -movespeed * Time.deltaTime);
			
		}
		
		
	}
	private void FixedUpdate()
	{
		MoveTerrain();

	}
}
