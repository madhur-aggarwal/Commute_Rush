using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public float speed = 1.0f;
    public int damage = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, (-Time.deltaTime * speed) / 10, 0);
    }

    public int GetDamage() {
        return damage;
    }
}
