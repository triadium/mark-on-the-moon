using UnityEngine;

public class PlayerState {
    private float _oxygenLevel;
    private int _stonesCount;
    private int _repairsCount;
    private int _helmetHitsCount;
    private int _armorHitsCount;

    public float OxygenLevel => _oxygenLevel;
    public int StonesCount => _stonesCount;
    public int HelmetHitsCount => _helmetHitsCount;
    public int ArmorHitsCount => _armorHitsCount;
    public int RepairsCount => _repairsCount;

    private float _oxygenOutSpeed;
    private float _minOxygenLevel;
    private float _maxOxygenLevel;

    public PlayerState(float oxygenLevel, int stonesCount, int repairsCount, int helmetHitsCount, int armorHitsCount) {
        _oxygenLevel = oxygenLevel;
        _stonesCount = stonesCount;
        _repairsCount = repairsCount;
        _helmetHitsCount = helmetHitsCount;
        _armorHitsCount = armorHitsCount;

        _oxygenOutSpeed = 0.5f;

        _minOxygenLevel = 0f;
        _maxOxygenLevel = 100f;
        
    }

    public void IncreaseOxygenLevel(float count) {
        _oxygenLevel = CheckLimits(_oxygenLevel, count, _minOxygenLevel, _maxOxygenLevel);
    }

    public void DecreaseOxygenLevelAuto() {
        _oxygenLevel = CheckLimits(_oxygenLevel,  -_oxygenOutSpeed * Time.deltaTime, _minOxygenLevel, _maxOxygenLevel);
    }

    public void IncreaseOxygenOutSpeed(float count) {
        _oxygenOutSpeed += count;
    }
    
    public void IncreaseOxygenLevelAuto() {
        _oxygenLevel += 3f * Time.deltaTime;
    }

    public void IncreaseStonesCount(int count) {
        _stonesCount += count;
    }

    public void DecreaseStonesCount() {
        _stonesCount--;
    }

    public void IncreaseHelmetHitsCount() {
        _helmetHitsCount++;
    }

    public void DecreaseHelmetHitsCount() {
        _helmetHitsCount--;
    }

    public void IncreaseArmorHitsCount() {
        _armorHitsCount++;
    }

    public void DecreaseArmorHitsCount() {
        _armorHitsCount--;
    }

    public void IncreaseRepairsCount() {
        _repairsCount++;
    }

    public void DecreaseRepairsCount() {
        _repairsCount--;
    }

    private float CheckLimits(float curVal, float diff, float min, float max) {
        float val = curVal + diff;
        if (val > max) return max;
        if (val < min) return min;
        return val;
    }

    private int CheckLimits(int curVal, int diff, int min, int max) {
        int val = curVal + diff;
        if (val > max) return max;
        if (val < min) return min;
        return val;
    }
}