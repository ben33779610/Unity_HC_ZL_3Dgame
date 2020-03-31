using UnityEngine;
using UnityEngine.UI;

public class LearnCsharp : MonoBehaviour
{
	[Header("圖片")]
	public SpriteRenderer image;
	[Header("攝影機")]
	public Transform cam;


	private void Start()
	{
		print("Hello World!");
		cam.transform.Rotate(0f, 0f, 90.0f, Space.Self);
	}

	private void Update()
	{
		print("Dlorw OlleH");
		print(Random.value);
		Time.timeScale = 0.1f; //設定時間尺寸
		Cursor.visible = false;
		image.flipX = true;
		print(Mathf.Floor(10.5f));
		
	}
}
