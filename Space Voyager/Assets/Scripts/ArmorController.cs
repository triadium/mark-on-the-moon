using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : MonoBehaviour
{
    public PlayerController player;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("wall")) {
            player.state.IncreaseArmorHitsCount();
            player.state.IncreaseOxygenOutSpeed(1);
            player.eventSystem.OnArmorHitsCountChanged(player.state.ArmorHitsCount);
        }
    }
}
