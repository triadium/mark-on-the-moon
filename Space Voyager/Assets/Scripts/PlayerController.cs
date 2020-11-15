using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject stone;
    public PlayerState state;
    public EventSystem eventSystem;
    
    private bool isOnOxygenFlower = false;

    private void OnEnable() {
        eventSystem.OnRepairEndedEv += OnRepairEnded;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        state = new PlayerState(100, 50, 0, 0, 0);
        eventSystem.OnInitUi(100, 50, 0, 0, 0);
    }

    void Update() {
        var mousePos = GetMousePosition(Input.mousePosition);
        if (Input.GetMouseButtonUp(0) && state.StonesCount > 0) {
            state.DecreaseStonesCount();
            eventSystem.OnStonesCountChanged(state.StonesCount);
            var diff = rb.position - mousePos;
            var _stone = Instantiate(stone, rb.position, Quaternion.identity);
            _stone.GetComponent<Rigidbody2D>().AddForce(-diff, ForceMode2D.Impulse);
            rb.AddForce(diff, ForceMode2D.Impulse);
        }
        UpdateState();
        eventSystem.OnOxygenLevelChanged(state.OxygenLevel);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("oxygen_balloon")) {
            state.IncreaseOxygenLevel(20f);
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("stone_heap")) {
            state.IncreaseStonesCount(other.gameObject.GetComponent<StoneHeapController>().stonesCount);
            eventSystem.OnStonesCountChanged(state.StonesCount);
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("repair")) {
            state.IncreaseRepairsCount();
            eventSystem.OnRepairsCountChanged(state.RepairsCount);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("oxygen_flower")) {
            isOnOxygenFlower = true;
        }
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("oxygen_flower")) {
            isOnOxygenFlower = false;
        }
    }

    private void OnRepairEnded(EventSystem.RepairType type, EventSystem.Result result) {
        state.DecreaseRepairsCount();
        eventSystem.OnRepairsCountChanged(state.RepairsCount);
        if (result == EventSystem.Result.SUCCESS) {
            if (type == EventSystem.RepairType.HELMET) {
                state.DecreaseHelmetHitsCount();
                eventSystem.OnHelmetHitsCountChanged(state.HelmetHitsCount);
            }
            if (type == EventSystem.RepairType.ARMOR) {
                state.DecreaseArmorHitsCount();
                eventSystem.OnArmorHitsCountChanged(state.ArmorHitsCount);
            }
        }
    }

    private void UpdateState() {
        if (isOnOxygenFlower) {
            state.IncreaseOxygenLevelAuto();
        }
        else {
            state.DecreaseOxygenLevelAuto();
        }
    }

    private Vector2 GetMousePosition(Vector3 mousePosition)
    {
        Vector3 mouseP = Camera.main.ScreenToWorldPoint(mousePosition);
        return new Vector2(mouseP.x, mouseP.y);
    }
    
    
}
