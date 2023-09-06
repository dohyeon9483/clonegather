using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject testPrefab;




    void Start()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;

    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }
    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}
