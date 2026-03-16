using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guns/gun Defination")]
public class GunDefination : ScriptableObject
{
    public GameObject artworkPrefab;

    public ParticleSystem muzzleEffect;

    public AudioClip firingSound;
    public AudioClip chamberSound;

    public float fireRate;

    public float projectileForce;

    public float projectileSpread;

    public int ammoCount;
}
