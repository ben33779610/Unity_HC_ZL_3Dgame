using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("地板陣列")]
	public Transform[] ter;
	[Header("移動速度")]
	[Range(1f, 50f)]
	public float movespeed = 1.5f;
	[Header("過關畫面")]
	public GameObject win;
	[Header("失敗畫面")]
	public GameObject lose;
	[Header("是否通關")]
	public bool passlv;
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

	/// <summary>
	/// 顯示勝利畫面
	/// </summary>
	public void Win()
	{
		win.SetActive(true);
	}
	/// <summary>
	/// 顯示失敗畫面
	/// </summary>
	public void Lose()
	{

		lose.SetActive(true);

	}

	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Replay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
	}

	public void Quit()
	{
		Application.Quit();
	}

	private void FixedUpdate()
	{
		MoveTerrain();

	}
}
