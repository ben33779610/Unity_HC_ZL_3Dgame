using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//prop唯獨屬性{取得,設定}
	public float hp { get; set; }
	public float atk
	{ get	{return 50;}

	}
	public float def
	{
		get { return 50; }

	}

	private float _damage;
	public float damage
	{	set{	_damage = Mathf.Clamp( value - def,1,99999);}
		get{	return _damage;		}


	}


	void Start()
    {
        
    }


}
