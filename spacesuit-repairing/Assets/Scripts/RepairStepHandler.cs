using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStepHandler : MonoBehaviour
{
    public char Char;
    public delegate void RepairStepProcessed(char Ch);
    public event RepairStepProcessed OnRepairStepProcessed;

    public void OnMouseDown() {
        OnRepairStepProcessed?.Invoke(Char);
        Destroy(gameObject);
    }
}
