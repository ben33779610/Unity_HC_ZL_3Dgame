using UnityEngine;

[CreateAssetMenu(fileName ="怪物資料",menuName ="怪物/怪物資料")]
public class MonsterData : ScriptableObject
{
	[Header("血量"),Range(50,2000)]
	public float hp;
	[Header("攻擊力"),Range(1,500)]
	public float atk;
	[Header("速度"),Range(1,150)]
	public float speed;


}
