using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour {
    private bool _canPickUp;
    private IEnumerator _rotation;

    [SerializeField]
    private Object _ingredientMeshDEBUG;

    private void Awake() {
        _rotation = Rotate(360);
    }

    // used to debug
    private void Start() {
        List<Ingredient> DEBUG = new List<Ingredient>();
        //Ingredient ing = new Ingredient(1, Unit.Cup, Ingredients.Cup, null);
        /*DEBUG.Add(ing);
        DEBUG.Add(ing);
        DEBUG.Add(ing);
        SetupPlate(DEBUG);*/
    }

    // UpdateMethod to Debug the plate
    private void Update() {
        if (Input.GetKeyDown(KeyCode.S) && !_canPickUp) {
            _canPickUp = !_canPickUp;
            StartCoroutine(_rotation);
            Debug.Log("start");
        }

        if (Input.GetKeyDown(KeyCode.W) && _canPickUp) {
            _canPickUp = !_canPickUp;
            StopCoroutine(_rotation);
            Debug.Log("stop");
        }


    }

    // start the rotation
    private IEnumerator Rotate(float speed) {
        while (_canPickUp) {
            transform.parent.Rotate(Vector3.up * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    // spawns the ingredients on the plate
    public void SetupPlate(List<Ingredient> ingredients) {
        for (int i = 0; i < ingredients.Count; i++) {
            // set angle
            Quaternion angle = Quaternion.AngleAxis(360.0f / ingredients.Count * i, transform.up);
            GameObject tmp = (GameObject)_ingredientMeshDEBUG;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + tmp.transform.localScale.y / 2, transform.position.z);

            //get the correct mesh
            _ingredientMeshDEBUG = ingredients[i].GetMesh();
            //spawn ingredient
            tmp = (GameObject)Instantiate(_ingredientMeshDEBUG, pos, angle, transform.parent);
            //move to the right position
            tmp.transform.position += tmp.transform.localScale.x * transform.localScale.x * tmp.transform.forward;
            //redet angle
            tmp.transform.rotation = Quaternion.identity;
            Debug.Log(pos + " " + angle + " " + tmp.transform.forward);
        }
    }

   /* public Ingredient Select() {
        return transform.GetComponent<IngredientHolder>().GetIngredient();
    }*/
}
