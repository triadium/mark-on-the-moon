using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStepTimeoutIndicatorHandler : MonoBehaviour
{
    public delegate void RepairStepTimeout(char Ch);
    public event RepairStepTimeout OnRepairStepTimeout;

    [Range(1, 30)]   
    public int timeout = 10;

    private const string _argCutoff = "_Cutoff";
    private char _char;
    private float _currentTimeout;
    private Material _material;

    void Start()
    {
        _char = GetComponentInParent<RepairStepHandler>().Char;
        _currentTimeout = timeout;
        _material = gameObject.GetComponent<SpriteRenderer>().material;
        _material.SetFloat(_argCutoff, 0.0f);        
    }

    void Update()
    {
        _currentTimeout -= Time.deltaTime;
        if(_currentTimeout > 0.0f) {
            _material.SetFloat(_argCutoff, 1.0f - _currentTimeout / timeout);
        }
        else {
            _material.SetFloat(_argCutoff, 1.0f);
            OnRepairStepTimeout?.Invoke(_char);
            Destroy(transform.parent.gameObject);
        }
    }
}
