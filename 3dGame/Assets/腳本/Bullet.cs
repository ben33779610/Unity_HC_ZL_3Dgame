using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Header("傷害")]
	public float damage;
	public bool player;

	/// <summary>
	/// 勾選Trigger的物件碰撞到執行一次
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		/*		if (!player && other.tag == "Player")
				{
					other.GetComponent<Beetle>().Hit(damage);
					Destroy(gameObject);
				}
				*/
		
		if (other.tag == "Enemy")
		{

			other.gameObject.GetComponent<Monster>().Hit(damage);
			Destroy(gameObject);

		}
		else
		{
			Destroy(gameObject,10);
		}

	}

}
