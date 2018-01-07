using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletExplosion : MonoBehaviour {

    public float lifeTime = 5f;

	private IEnumerator Start () {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
	}

}
