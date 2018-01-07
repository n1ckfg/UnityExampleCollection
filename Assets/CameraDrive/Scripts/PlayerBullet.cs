using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public PlayerBulletExplosion explosionPrefab;
    public float lifeTime = 5f;
    public float speed = 0.1f;

    private float birthTime = 0f;

	private IEnumerator Start () {
        birthTime = Time.realtimeSinceStartup;
        yield return new WaitForSeconds(lifeTime);
        explode();
	}

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, speed);
    }

    private void OnCollisionEnter(Collision col) {
        if (Time.realtimeSinceStartup > birthTime + 0.1f) explode();
    }

    private void explode() {
        PlayerBulletExplosion p = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform.parent).GetComponent<PlayerBulletExplosion>();
        Destroy(gameObject);
    }

}
