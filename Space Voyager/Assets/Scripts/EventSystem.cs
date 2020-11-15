using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    
    public enum RepairType {
        HELMET,
        ARMOR
    }
    
    public enum Result {
        SUCCESS,
        FAIL
    }
    
    public delegate void InitUi(float oxygenLevel, int stonesCount, int repairsCount, int helmetHitsCount, int armorHitsCount);
    public event InitUi OnInitUiEv;
    
    public delegate void RepairsCountChanged(int count);
    public event RepairsCountChanged OnRepairsCountChangedEv;
    
    public delegate void OxygenLevelChanged(float level);
    public event OxygenLevelChanged OnOxygenLevelChangedEv;
    
    public delegate void StonesCountChanged(int count);
    public event StonesCountChanged OnStonesCountChangedEv;
    
    public delegate void HelmetHitsCountChanged(int count);
    public event HelmetHitsCountChanged OnHelmetHitsCountChangedEv;
    
    public delegate void ArmorHitsCountChanged(int count);
    public event ArmorHitsCountChanged OnArmorHitsCountChangedEv;
    
    public delegate void RepairEnded(RepairType type, Result result);
    public event RepairEnded OnRepairEndedEv;

    public void OnInitUi(float oxygenLevel, int stonesCount, int repairsCount, int helmetHitsCount, int armorHitsCount) {
        OnInitUiEv?.Invoke(oxygenLevel, stonesCount, repairsCount, helmetHitsCount, armorHitsCount);
    }
    public void OnRepairsCountChanged(int count) {
        OnRepairsCountChangedEv?.Invoke(count);
    }
    public void OnOxygenLevelChanged(float level) {
        OnOxygenLevelChangedEv?.Invoke(level);
    }
    public void OnStonesCountChanged(int count) {
        OnStonesCountChangedEv?.Invoke(count);
    }
    public void OnHelmetHitsCountChanged(int count) {
        OnHelmetHitsCountChangedEv?.Invoke(count);
    }
    public void OnArmorHitsCountChanged(int count) {
        OnArmorHitsCountChangedEv?.Invoke(count);
    }
    public void OnRepairEnded(RepairType type, Result result) {
        OnRepairEndedEv?.Invoke(type, result);
    }
    
    
}
