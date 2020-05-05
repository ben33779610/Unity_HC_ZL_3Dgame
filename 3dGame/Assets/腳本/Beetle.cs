using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Beetle : MonoBehaviour
{
	[Header("速度")][Range(1,1000)]
	public float speed;
	public Joystick joy;
	[Header("上限")]
	public float top = 36;
	[Header("下限")]
	public float bottom = 12;
	[Header("子彈")]
	public GameObject bullet;
	[Header("攻擊冷卻")]
	public float cd = 1;
	[Header("子彈速度")]
	public float bulspeed = 1;
	[Header("傷害"),Range(1, 1000)]
	public float atk = 10;
	[Header("血量")]
	public float hp = 100;
	[Header("血條")]
	public Image hpbar;
	[Header("動畫控制器")]
	private Animator ani;

	private float curhp;	//現在血量
	private float timer;    //計時器
	private GameManager gm;

	private void Start()
	{
		ani = GetComponent<Animator>();
		curhp = hp;
		hpbar.fillAmount = hp / 100;
		gm = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		Move();
		Attack();
		
	}

	public void Hit(float damage)
	{
		if (gm.passlv) return;
		if (ani.GetBool("死亡開關")) return;
		curhp -= damage;
		StartCoroutine("Hpbareffect");
		if (curhp <= 0) Dead();
	}
	private void Dead()
	{
		ani.SetBool("死亡開關", true);
		gm.Invoke("Lose",4f);


	}

	private void Move()
	{
		if (ani.GetBool("死亡開關")) return;
		float h = Input.GetAxis("Horizontal")*-1;
		float v = Input.GetAxis("Vertical")*-1;
		transform.Translate(h * Time.deltaTime * speed, 0, v * Time.deltaTime* speed);

		float joyh = joy.Horizontal*-1;
		float joyv = joy.Vertical*-1;
		transform.Translate(joyh * Time.deltaTime * speed, 0, joyv * Time.deltaTime * speed);

		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, 48, 156);
		pos.z = Mathf.Clamp(pos.z, 4.85f, 26);
		transform.position = pos;
	}

	private void EatSP()
	{
		if (ani.GetBool("死亡開關")) return;
		if ( cd > 0.7f) 
			cd -= 0.1f;
	}

	private void  Eathp()
	{
		if (ani.GetBool("死亡開關")) return;
		if ( curhp < hp ) 
			curhp += 10;
		StartCoroutine("Hpbareffect");
	}
	private IEnumerator Hpbareffect()
	{
		
		hpbar.fillAmount = curhp / 100;
		
		yield return null;
	}

	private void Attack()
	{
		if (ani.GetBool("死亡開關")) return;
		timer += Time.deltaTime;
		if (timer > cd)
		{
			timer = 0;
			ani.SetTrigger("攻擊觸發");
			StartCoroutine("Delaybullet");
		}
	}

	private IEnumerator Delaybullet()
	{
		yield return new WaitForSeconds(0.5f);
		Vector3 posbul = transform.position;
		posbul.z += 3f;
		posbul.y += -0.1f;
		GameObject temp =  Instantiate(bullet, posbul, Quaternion.identity);
		temp.AddComponent<Bullet>();
		temp.GetComponent<Bullet>().damage = atk;
		temp.GetComponent<Bullet>().player = true;
		temp.GetComponent<Rigidbody>().AddForce(0, 0, bulspeed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "SP藥水")
		{
			
			EatSP();
			Destroy(other.gameObject);
		}

		if (other.tag == "回血藥水")
		{
			
			Eathp();
			Destroy(other.gameObject);
		}

	}

}
