
using UnityEngine;

public class Monster : MonoBehaviour
{
	public MonsterData Mdata;
	private Animator ani;
	private float hp;

	private void Start()
	{
		ani = GetComponent<Animator>();
		hp = Mdata.hp;
	}
	void Damage(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		hp -= damage;
		
		if (hp <= 0) Dead();
	}

	void Dead()
	{
		ani.SetBool("死亡開關", true);
		Destroy(this);
		Destroy(gameObject, 0.5f);
	}
    
}
