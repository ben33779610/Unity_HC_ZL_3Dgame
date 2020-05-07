using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	[Header("載入畫面")]
	public GameObject panelloading;
	[Header("百分比")]
	public Text textloading;
	[Header("進度條")]
	public Image imageloading;

	/// <summary>
	/// 開始載入
	/// </summary>
	public void StartLoading()
	{
		print("開始載入");
		panelloading.SetActive(true);
		//SceneManager.LoadScene("關卡1");
		StartCoroutine("Loading");
	}

	/// <summary>
	///場景載入 
	/// </summary>
	public IEnumerator Loading()
	{
		AsyncOperation ao = SceneManager.LoadSceneAsync("關卡1");
		ao.allowSceneActivation = false;
		while (!ao.isDone)
		{
			textloading.text = ao.progress / 0.9f * 100 + "%";
			imageloading.fillAmount = ao.progress / 0.9f;

			if (ao.progress == 0.9f)
				ao.allowSceneActivation = true;

			yield return null;

			

		}
		
	}

	private void Start()
	{
		Screen.SetResolution(450, 800,false);
	}
}
