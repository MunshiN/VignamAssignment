using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    [SerializeField] GameObject ray;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject atomPrefab;
    [SerializeField] GameObject centerPrefab;
    [SerializeField] float spawnPosX = -2.0f;
    [SerializeField] float spawnPosX2 = 1.3f;
    [SerializeField] float spawnPosY = -1.83f;
    private float startDelay = 1;
    private float spawnInterval = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        SpawnAtom();
    }

    public void OnClick()
    {
        if (ray.activeInHierarchy)
        {
            InvokeRepeating("SpawnRandomParticle", startDelay, spawnInterval);
        }
        else
        {
            CancelInvoke();
        }
        
    }
    void SpawnRandomParticle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnPosX, spawnPosX2), spawnPosY, 0);
        Instantiate(particlePrefab, spawnPos, particlePrefab.transform.rotation);
       
    }
    void SpawnAtom()
    {
        Vector3 spawnAtomPos = new Vector3(0, 0, 0);
        Instantiate(atomPrefab, spawnAtomPos, atomPrefab.transform.rotation);
        Instantiate(centerPrefab, spawnAtomPos, centerPrefab.transform.rotation);
       
    }
}
