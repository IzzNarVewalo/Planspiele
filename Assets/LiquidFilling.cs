using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LiquidFilling : MonoBehaviour {

    Renderer _renderer;

    [Range(0, 1)][SerializeField]
    private float FillLevel;

    private float _worldLiquidLimit;

    // Use this for initialization
    void Start () {
        _renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        float newLimit = _renderer.bounds.min.y + (_renderer.bounds.max.y - _renderer.bounds.min.y) * FillLevel;
        if(_worldLiquidLimit != newLimit)
        {
            _worldLiquidLimit = newLimit;
            _renderer.sharedMaterial.SetFloat("_LiquidHeight", _worldLiquidLimit);
        }
        
    }

    public void SetFillLevel(float level)
    {
        FillLevel = Mathf.Clamp(level, 0, 1);
    }

    private void OnValidate()
    {
        SetFillLevel(FillLevel);
    }
    
}
