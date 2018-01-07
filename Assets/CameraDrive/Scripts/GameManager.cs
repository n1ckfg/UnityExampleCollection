using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState { PLAY, END };
    public GameState gameState = GameState.PLAY;
    public Base[] bases;
    public Fader fader;
    public Player player;

    void Update() {
        switch (gameState) {
            case GameState.PLAY:
                bool goToEnd = true;
                for (int i = 0; i < bases.Length; i++) {
                    if (!bases[i].isVisited) goToEnd = false;
                }
                if (goToEnd) gameState = GameState.END;
                break;

            case GameState.END:
                fader.fadeOut();
                break;
        }
	}

    public void reset() {
        gameState = GameState.PLAY;
        for (int i=0; i<bases.Length; i++) {
            bases[i].reset();
        }
        player.reset();
        fader.fadeIn();
    }

}
