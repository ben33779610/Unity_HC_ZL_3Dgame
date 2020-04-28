
using UnityEngine;

public class Monster : MonoBehaviour
{
	public MonsterData Mdata;
	public GameObject propsp;
	public GameObject prophp;
	private Animator ani;
	private float hp;

	private void Start()
	{
		ani = GetComponent<Animator>();
		hp = Mdata.hp;
	}
	public void Hit(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		hp -= damage;
		
		if (hp <= 0) Dead();
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
    
}
