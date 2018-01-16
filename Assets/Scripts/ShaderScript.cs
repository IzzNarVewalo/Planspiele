using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderScript : MonoBehaviour {
    // Kaffetassenshader
    [SerializeField]
    private float _myFloat;
    [SerializeField]
    private float _milchAnteil;
    [SerializeField]
    private float _kaffeAnteil;
    [SerializeField]
    private Color _myColor = new Color(124, 88, 82);
    [SerializeField]
    private Color _brown = new Color(124, 88, 82);

    public Material ShaderMaterial;


    private bool _positionCounter = true;

    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        Graphics.Blit(src, dst, ShaderMaterial);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.G))
            _positionCounter = !_positionCounter;
        if (Input.GetKey(KeyCode.Return) && _positionCounter && _myFloat < 0.95f) {
            _kaffeAnteil += Time.deltaTime * 0.25f;
            _myFloat = _kaffeAnteil + _milchAnteil;
            _myColor = Color.Lerp(Color.white, _brown, _kaffeAnteil / _myFloat * 1.5f);
            Shader.SetGlobalColor("_MyColor", _myColor);
            Shader.SetGlobalFloat("_MyFloat", _myFloat);
        }

        if (Input.GetKey(KeyCode.Return) && !_positionCounter && _myFloat < 0.95f) {
            _milchAnteil += Time.deltaTime * 0.25f;
            _myFloat = _kaffeAnteil + _milchAnteil;
            _myColor = Color.Lerp(Color.white, _brown, _kaffeAnteil / _myFloat * 1.5f);
            Shader.SetGlobalColor("_MyColor", _myColor);
            Shader.SetGlobalFloat("_MyFloat", _myFloat);
        }

        if (Input.GetKey(KeyCode.R)) {
            _myFloat = _kaffeAnteil = _milchAnteil = 0;
            Shader.SetGlobalFloat("_MyFloat", _myFloat);
        }
    }
}
