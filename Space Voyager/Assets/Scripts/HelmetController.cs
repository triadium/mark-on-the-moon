using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetController : MonoBehaviour {
    public PlayerController player;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("wall")) {
            player.state.IncreaseHelmetHitsCount();
            player.state.IncreaseOxygenOutSpeed(3);
            player.eventSystem.OnHelmetHitsCountChanged(player.state.HelmetHitsCount);
        }
    }
}
