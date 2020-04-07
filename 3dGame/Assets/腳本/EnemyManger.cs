using UnityEngine;

public class EnemyManger : MonoBehaviour
{


	public Enemy enemy;

	void Start()
    {
		print(enemy.atk);
		enemy.damage = 500;
		print(enemy.damage);
    }

    
}
