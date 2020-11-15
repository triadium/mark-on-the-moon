using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public EventSystem eventSystem;
    
    public OxygenBarController uiOxygenBar;
    public Text uiHelmetHitsText;
    public Text uiArmorHitsText;
    public Text uiStonesCountText;
    public Text uiRepairsCountText;

    public Button repairHelmetSuccessBtn;
    public Button repairArmorSuccessBtn;
    public Button repairHelmetFailBtn;
    public Button repairArmorFailBtn;
    
    private void OnEnable() {
        eventSystem.OnInitUiEv += InitUI;
        eventSystem.OnRepairsCountChangedEv += SetRepairsCount;
        eventSystem.OnOxygenLevelChangedEv += SetOxygenLevel;
        eventSystem.OnStonesCountChangedEv += SetStonesCount;
        eventSystem.OnArmorHitsCountChangedEv += SetArmorHitsCount;
        eventSystem.OnHelmetHitsCountChangedEv += SetHelmetHitsCount;
        
        repairHelmetSuccessBtn.onClick.AddListener(RepairHelmetSuccessBtnListener);
        repairArmorSuccessBtn.onClick.AddListener(RepairArmorSuccessBtnListener);
        repairHelmetFailBtn.onClick.AddListener(RepairHelmetFailBtnListener);
        repairArmorFailBtn.onClick.AddListener(RepairArmorFailBtnListener);
        
    }
    
    private void RepairHelmetSuccessBtnListener() {
        eventSystem.OnRepairEnded(EventSystem.RepairType.HELMET, EventSystem.Result.SUCCESS);
    }
    private void RepairArmorSuccessBtnListener() {
        eventSystem.OnRepairEnded(EventSystem.RepairType.ARMOR, EventSystem.Result.SUCCESS);
    }
    private void RepairHelmetFailBtnListener() {
        eventSystem.OnRepairEnded(EventSystem.RepairType.HELMET, EventSystem.Result.FAIL);
    }
    private void RepairArmorFailBtnListener() {
        eventSystem.OnRepairEnded(EventSystem.RepairType.ARMOR, EventSystem.Result.FAIL);
    }

    public void InitUI(float oxygenLevel, int stonesCount, int repairsCount, int helmetHitsCount, int armorHitsCount) {
        uiOxygenBar.slider.value = oxygenLevel;
        uiHelmetHitsText.text = helmetHitsCount.ToString();
        uiArmorHitsText.text = armorHitsCount.ToString();
        uiStonesCountText.text = stonesCount.ToString();
        uiRepairsCountText.text = repairsCount.ToString();
    }

    public void SetOxygenLevel(float oxygenLevel) {
        uiOxygenBar.slider.value = oxygenLevel;
    }

    public void SetHelmetHitsCount(int helmetHitsCount) {
        uiHelmetHitsText.text = helmetHitsCount.ToString();
    }

    public void SetArmorHitsCount(int armorHitsCount) {
        uiArmorHitsText.text = armorHitsCount.ToString();
    }

    public void SetStonesCount(int stonesCount) {
        uiStonesCountText.text = stonesCount.ToString();
    }

    public void SetRepairsCount(int repairsCount) {
        uiRepairsCountText.text = repairsCount.ToString();
    }
    
}
