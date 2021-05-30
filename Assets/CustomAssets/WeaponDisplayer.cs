using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class WeaponDisplayer : MonoBehaviour
{
    public Weapon weapon;
    SpriteRenderer spriteRenderer;
    [Range(.1f, 10)]
    public float weaponScale = 1;
    Camera _camera;
    GameObject rotater;
    GameObject displayer;
    bool currentlyShooting = false;


    float lastShotTime;

    private void Start()
    {
        _camera = Camera.main;
        rotater = transform.Find("Rotater").gameObject;
        displayer = rotater.transform.Find("Weapon Display").gameObject;
        spriteRenderer = displayer.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = weapon.sprite;
        displayer.transform.localScale = Vector3.one * weaponScale;
        lastShotTime = Time.time;
    }
    private void Update()
    {
        Ray r = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit))
        {
            rotater.transform.LookAt(hit.point, Vector3.up);
            switch (weapon.shootingMethod)
            {
                case Weapon.ShootingMethods.SemiAutomatic:
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Time.time - lastShotTime > weapon.reloadTime)
                            shootProjectile(transform.position, hit.point);
                    }
                    return;
                case Weapon.ShootingMethods.Automatic:
                    if (currentlyShooting)
                    {
                        shootProjectile(transform.position, hit.point);
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        currentlyShooting = true;
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        currentlyShooting = false;

                    }
                    return;
                default:
                    return;
            }
        }

    }

    void shootProjectile(Vector3 from, Vector3 to)
    {
        lastShotTime = Time.time;
        Vector3 along = to - from;

        GameObject holder = new GameObject();
        holder.transform.parent = GameObject.Find("Projectiles").transform;
        GameObject displayer = new GameObject();
        displayer.transform.parent = holder.transform;
        SpriteRenderer sr = displayer.AddComponent<SpriteRenderer>();

        sr.sprite = weapon.projectileSprite;
        displayer.transform.rotation = Quaternion.Euler(0, 90, 90);
        holder.transform.LookAt(along, Vector3.up);

        BoxCollider collider = holder.AddComponent<BoxCollider>();
        collider.size = new Vector3(.5f, .5f, .5f);
        collider.isTrigger = true;

        Rigidbody rigidbody = holder.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        holder.AddComponent<CollisionController>();

        StartCoroutine(projectileProgress(holder, from, along, weapon.projectileSpeed));
    }
    IEnumerator projectileProgress(GameObject holder, Vector3 from, Vector3 along, float speed)
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
