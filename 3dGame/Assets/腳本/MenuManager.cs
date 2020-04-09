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
		textloading.text = ("99.9%");
		imageloading.fillAmount = 0.999f;
		//SceneManager.LoadScene("關卡1");
		StartCoroutine("Loading");
	}

	public IEnumerator Loading()
	{
		AsyncOperation ao = SceneManager.LoadSceneAsync("關卡1");
		print(ao.progress);
		yield return null;
		print(ao.progress);
		yield return null;
		print(ao.progress);
		yield return null;
	}
}
