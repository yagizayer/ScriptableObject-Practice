/// Author: Yağız A. AYER
/// Github: github.com/yagizayer
/// Date: 30 May 2021
/// Used Style guide: Google C# StyleGuide (https://google.github.io/styleguide/csharp-style.html)


using System.Collections;
using UnityEngine;


[SelectionBase]
public class WeaponDisplayer : MonoBehaviour
{
    [Tooltip("Scriptable object of Displaying Weapon")]
    [SerializeField] private SO_Weapon _weapon;
    [Tooltip("Size of Displaying weapon")]
    [SerializeField] [Range(.1f, 10)] private float _weaponScale = 1;
    [Tooltip("Rotater object of Weapon displayer(optional)")]
    [SerializeField] private GameObject _rotater;
    [Tooltip("Displayer object of Weapon displayer(optional)")]
    [SerializeField] private GameObject _displayer;
    // Weapon displayers Sprite Renderer component
    SpriteRenderer _spriteRenderer;
    // Main camera(for framely raycast check)
    Camera _camera;
    // is Weapon currently Shooting
    bool _currentlyShooting = false;
    // last shot time(for reload wait)
    float _lastShotTime;

    private void Start()
    {
        if (!_rotater)
            _rotater = transform.Find("Rotater").gameObject;
        if (!_displayer)
            _displayer = _rotater.transform.Find("Weapon Display").gameObject;
        _camera = Camera.main;
        _spriteRenderer = _displayer.GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _weapon.Sprite;
        _displayer.transform.localScale = Vector3.one * _weaponScale;
        _lastShotTime = Time.time;
    }
    private void Update()
    {
        Ray r = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit))
        {
            _rotater.transform.LookAt(hit.point, Vector3.up);
            switch (_weapon.ShootingMethod)
            {
                case SO_Weapon.ShootingMethods.SemiAutomatic:
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Time.time - _lastShotTime > _weapon.ReloadTime)
                            ShootProjectile(transform.position, hit.point);
                    }
                    return;
                case SO_Weapon.ShootingMethods.Automatic:
                    if (_currentlyShooting)
                    {
                        if (Time.time - _lastShotTime > _weapon.ReloadTime)
                            ShootProjectile(transform.position, hit.point);
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        _currentlyShooting = true;
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        _currentlyShooting = false;

                    }
                    return;
                default:
                    return;
            }
        }

    }

    void ShootProjectile(Vector3 from, Vector3 to)
    {
        _lastShotTime = Time.time;
        Vector3 along = to - from;

        GameObject holder = new GameObject();
        holder.transform.parent = GameObject.Find("Projectiles").transform;
        GameObject displayer = new GameObject();
        displayer.transform.parent = holder.transform;
        SpriteRenderer sr = displayer.AddComponent<SpriteRenderer>();

        sr.sprite = _weapon.ProjectileSprite;
        displayer.transform.rotation = Quaternion.Euler(0, 90, 90);
        holder.transform.LookAt(along, Vector3.up);

        BoxCollider collider = holder.AddComponent<BoxCollider>();
        collider.size = new Vector3(.5f, .5f, .5f);
        collider.isTrigger = true;

        Rigidbody rigidbody = holder.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        holder.AddComponent<CollisionController>();

        StartCoroutine(ProjectileProgress(holder, from, along, _weapon.ProjectileSpeed));
    }
    IEnumerator ProjectileProgress(GameObject holder, Vector3 from, Vector3 along, float speed)
    {
        float lerp = 0;
        while (lerp < 1)
        {
            holder.transform.position = Vector3.Lerp(from, along.normalized * 10, lerp);
            lerp += Time.deltaTime * speed;
            yield return null;
        }
        if (lerp > 1)
        {
            GameObject.Destroy(holder);
        }
    }

}
