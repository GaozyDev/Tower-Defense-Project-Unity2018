using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    public GameObject buildEffect;
    [HideInInspector]
    public bool isUpgraded = false;
    
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void BuildTurret(GameObject turretPrefab)
    {
        isUpgraded = false;
        turretGo = GameObject.Instantiate(turretPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }

    void OnMouseEnter()
    {
        if (turretGo == null && !EventSystem.current.IsPointerOverGameObject())
        {
            _renderer.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }
}
