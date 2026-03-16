using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Injected Defination")]
    [SerializeField] private GunDefination Defination;

    [Header("Sockets / Components")]
    [SerializeField] private Transform artworkSocket;
    [SerializeField] private AudioSource audioSource;

    [Header("Runtime Data")]
    [SerializeField] private GameObject currentArtwork;
    [SerializeField] private float fireRate;
    [SerializeField] private float projectileForce;
    [SerializeField] private float projectileSpread;
    [SerializeField] private int ammo;
    [SerializeField] private AudioClip firingSound;
    [SerializeField] private AudioClip chamberSound;
    [SerializeField] private ParticleSystem muzzleEffectPrefab;

    private void Start()
    {
       

    }

    public void InjectDefinition(GunDefination def)
    {
        Defination = def;

        fireRate = def.fireRate;
        projectileForce = def.projectileForce;
        projectileSpread = def.projectileSpread;
        ammo = def.ammoCount;

        firingSound = def.firingSound;
        chamberSound = def.chamberSound;
        muzzleEffectPrefab = def.muzzleEffect;

        InjectArtwork();

        if(audioSource != null && chamberSound != null)
        {
            audioSource.PlayOneShot(chamberSound);
        }
    }

    private void InjectArtwork()
    {
        if(artworkSocket == null)
        {
            Debug.LogWarning("Gun has no artwork socket assigned");
            return;
        }

        if(currentArtwork != null)
        {
            Destroy(currentArtwork);
        }

        if(Defination == null || Defination.artworkPrefab == null)
        {
            Debug.LogWarning("No artwork prefab found on GunDefinition");
            return;
        }

        currentArtwork = Instantiate(Defination.artworkPrefab);

        currentArtwork.transform.SetParent(artworkSocket, false);

        currentArtwork.transform.localPosition = Vector3.zero;
        currentArtwork.transform.localRotation = Quaternion.identity;
        currentArtwork.transform.localScale = Vector3.one;
    }
}
