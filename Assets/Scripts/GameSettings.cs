using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings {
    public static float IdleHoldForce { get; set; }
    public static float MaxPressForce { get; set; }
    public static float TiltThreshold = 45;
    public static float ForceThreshold {
        get {
            if(IdleHoldForce == 0 || MaxPressForce == 0)
            {
                return 300;
            }
            return IdleHoldForce + 0.5f * (MaxPressForce - IdleHoldForce);
        }
    }
    public static float MinPressForce = 300;

    public static Translation.AvailableLanguage Language = Translation.AvailableLanguage.EN;


    private static Dictionary<Ingredients, Object> _meshForIngredient = new Dictionary<Ingredients, Object>();

    public static Object GetMeshForIngredient(Ingredients i) {
        return _meshForIngredient[i];
    }

    public static void AddMeshForIngredient(Ingredients key, UnityEngine.Object value) {
        _meshForIngredient.Add(key, value);
    }
}
