using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public enum ShootingMethods
    {
        Laser,
        SemiAutomatic,
        Automatic,
        Explosion
    };
    public ShootingMethods shootingMethod = ShootingMethods.SemiAutomatic;
    public Sprite sprite;
    public Sprite projectileSprite;
    [Range(0.01f, 1)]
    public float reloadTime ;
    [Range(0.1f, 10)]
    public float projectileSpeed ;

}
