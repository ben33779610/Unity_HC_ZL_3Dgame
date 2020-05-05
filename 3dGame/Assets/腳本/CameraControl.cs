using UnityEngine;



public class CameraControl : MonoBehaviour
{
	[Header("速度"), Range(0, 100)]
	public float speed = 1.5f;

	/*[Header("上限")]
	public float top = 36;
	[Header("下限")]
	public float bottom = 12;*/

	private Transform player;


	void Start()
	{
		player = GameObject.Find("甲蟲").transform;

	}

	private void LateUpdate()
	{
		Track();
	}

	private void Track()
	{
		Vector3 posP = player.position;
		Vector3 posC = transform.position;
		/*
		posP.x = 0;
		posP.y = 18;
		posP.z += 15;
		

		posC.z = Mathf.Clamp(posC.z, bottom, top);   //Mathf.Clamp(夾住的值,下限,上限)*/
		posP.y = 46.4f;
		posP.z -= 2.6f;
		transform.position = Vector3.Lerp(posC, posP, 0.3f * Time.deltaTime * speed);

	}

}