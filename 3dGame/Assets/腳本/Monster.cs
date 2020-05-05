
using UnityEngine;

public class Monster : MonoBehaviour
{
	public MonsterData Mdata;
	public GameObject propsp;
	public GameObject prophp;
	[Header("子彈")]
	public GameObject bullet;
	private Animator ani;
	private float hp;
	private float timer;

	private void Start()
	{
		ani = GetComponent<Animator>();
		hp = Mdata.hp;
	}
	private void Update()
	{
		Attack();
	}
	public void Hit(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		hp -= damage;
		GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
		Invoke("ResetColor", 0.1f);
		if (hp <= 0) Dead();
	}

	private void ResetColor()
	{
		GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
	}

	void Dead()
	{
		ani.SetBool("死亡開關", true);
		Dropprop();
		Destroy(this);
		Destroy(gameObject, 0.5f);
	}

	private void Dropprop()
	{
		float rsp = Random.Range(0f, 1f);
		if (rsp < Mdata.spr) Instantiate(propsp, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
		float rhp = Random.Range(0f, 1f);
		if (rhp < Mdata.hpr) Instantiate(prophp, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
	}

	private void Attack()
	{
		timer += Time.deltaTime;
		if (timer >= Mdata.atkcd)
		{
			timer = 0;
			ani.SetTrigger("攻擊觸發");
			GameObject temp = Instantiate(bullet, transform.position+transform.forward, Quaternion.identity);
			temp.AddComponent<Move>().speed = Mdata.bspeed;
			temp.AddComponent<Bullet>().damage = Mdata.atk;
		}
	}
}
