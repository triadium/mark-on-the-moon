using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitRepairing : MonoBehaviour
{
    public GameObject[] RepairSteps;

    private string _repairProcess;
    private string _correctRepairProcess;
    private int _repairStepCount;
    private GameObject[] _repairStepGos;
    // Start is called before the first frame update
    private void Awake()
    {
        _repairProcess = "";
        _repairStepCount = 9;
        _repairStepGos = new GameObject[_repairStepCount];
        for (int i = 0; i < _repairStepGos.Length; i++) {
            _correctRepairProcess = _correctRepairProcess + RepairSteps[i].GetComponent<RepairStepHandler>().Char;
            _repairStepGos[i] = Instantiate<GameObject>(RepairSteps[i], new Vector3(-500 + 140 * i + Random.Range(-10, 10), 0, 0), new Quaternion());
        }
    }

    private void OnEnable() {
        if (_repairStepGos != null) {
            for (int i = 0; i < _repairStepGos.Length; i++) {
                (_repairStepGos[i]?.GetComponentInChildren<RepairStepTimeoutIndicatorHandler>()).OnRepairStepTimeout += OnRepairStepTimeout;
                (_repairStepGos[i]?.GetComponent<RepairStepHandler>()).OnRepairStepProcessed += OnRepairStepProcessed;
            }
        }
        //else { skip }
    }

    private void OnDisable() {
        for (int i = 0; i < _repairStepGos.Length; i++) {
            if (_repairStepGos[i]) {
                (_repairStepGos[i].GetComponentInChildren<RepairStepTimeoutIndicatorHandler>()).OnRepairStepTimeout -= OnRepairStepTimeout;
                (_repairStepGos[i].GetComponent<RepairStepHandler>()).OnRepairStepProcessed -= OnRepairStepProcessed;
            }
            //else { noop }
        }
    }

    private void RepairingDone() {
        Debug.Log("Repairing Done! " + _correctRepairProcess + " ? " + _repairProcess);
        if (_repairProcess == _correctRepairProcess) {
            Debug.Log("Yeah! Spacesuit Not Leaking Now!");
        }
        else {
            Debug.Log("Ouch! Spacesuit Still Leaking!");
        }
    }

    private void RepairStepDone(char Ch) {
        for (int i = 0; i < _repairStepGos.Length; i++) {
            if (_repairStepGos[i] && (_repairStepGos[i].GetComponent<RepairStepHandler>()).Char == Ch) {
                _repairStepGos[i] = null;
                break;
            }
            //else { noop }
        }
        _repairStepCount--;

        if (_repairStepCount <= 0) {
            RepairingDone();
        }
        //else { noop }
    }

    private void OnRepairStepTimeout(char Ch) {
        Debug.Log("Timeout " + Ch);

        RepairStepDone(Ch);
    }

    private void OnRepairStepProcessed(char Ch) {
        Debug.Log("Processed " + Ch);
        _repairProcess += Ch;

        RepairStepDone(Ch);
    }
}
