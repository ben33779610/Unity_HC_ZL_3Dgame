using UnityEngine;
using System.Collections;


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
	[Header("動畫控制器")]
	private Animator ani;

	private float timer;

	private void Start()
	{
		ani = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
		Attack();
	}


	private void Move()
	{
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

	private void Attack()
	{
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
		temp.GetComponent<Rigidbody>().AddForce(0, 0, bulspeed);
	}
	
}
