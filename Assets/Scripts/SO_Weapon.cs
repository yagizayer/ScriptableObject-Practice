/// Author: Yağız A. AYER
/// Github: github.com/yagizayer
/// Date: 30 May 2021
/// Used Style guide: Google C# StyleGuide (https://google.github.io/styleguide/csharp-style.html)

using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 1)]
public class SO_Weapon : ScriptableObject
{
    public enum ShootingMethods
    {
        SemiAutomatic,
        Automatic
    };

    [Tooltip("Shooting Mode of Weapon")]
    public ShootingMethods ShootingMethod = ShootingMethods.SemiAutomatic;
    [Tooltip("Sprite of Weapon")]
    public Sprite Sprite;
    [Tooltip("Sprite of Weapons Shooting Projectile")]
    public Sprite ProjectileSprite;
    [Tooltip("Reload Time of Weapon")]
    [Range(0.01f, 1)] public float ReloadTime = .1f;
    [Tooltip("Projectile Speed of Weapon")]
    [Range(0.1f, 10)] public float ProjectileSpeed = 5f;

}
