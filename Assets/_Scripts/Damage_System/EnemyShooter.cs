using UnityEngine;

public class EnemyShooter : Shooter
{
    Transform playerTr;
    Health myHealth;
    [SerializeField] float engageDistance = 50f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float aimPredictionFactor = 10f;

    [Header ("Weapon properties")]
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bulletPrefab;
}
