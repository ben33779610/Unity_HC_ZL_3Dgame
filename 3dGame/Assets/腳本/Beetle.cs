using UnityEngine;

public class Beetle : MonoBehaviour
{
	[Header("速度")][Range(1,1000)]
	public float speed;
	public Joystick joy;
	[Header("上限")]
	public float top = 36;
	[Header("下限")]
	public float bottom = 12;

	private void Update()
	{
		Move();
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
		pos.x = Mathf.Clamp(pos.x, 25, 74);
		transform.position = pos;
	}
}
