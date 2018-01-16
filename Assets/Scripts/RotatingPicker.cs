using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ingredient))]
public class RotatingPicker : MonoBehaviour {
    private Ingredient _actualIngredient;
    private int _counter = 0;

    private Coroutine _rotation;
    // Use this for initialization
    void Start() {
        _actualIngredient = GetComponentInChildren<Ingredient>();
        _rotation = StartCoroutine(Rotate(gameObject.transform.childCount));
    }
    
    private IEnumerator Rotate(int numberOfIngredients, int counter = 0) {
        for (int i = _counter; i < numberOfIngredients; i++) {
            _actualIngredient = gameObject.transform.GetChild(i).GetComponent<Ingredient>();
            _counter = i;
            yield return new WaitForSeconds(1.2f);
        }
    }

    public Ingredient Select() {
        StopCoroutine(_rotation);
        return _actualIngredient;
    }

    public void Rotate()
    {
        _rotation = StartCoroutine(Rotate(gameObject.transform.childCount));
    }
}
