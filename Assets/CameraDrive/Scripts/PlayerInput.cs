using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Player player;
    public GameManager gm;
    public BasicController ctl;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) gm.reset();

        if (Input.GetKey(KeyCode.Space)) player.fire();

        if (ctl.clicked && ctl.isLooking && ctl.isLookingAt.StartsWith("Base")) {
            GameObject.Find(ctl.isLookingAt).GetComponent<Base>().doIsVisited();
        }
	}
}
