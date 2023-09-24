using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPrefabInstantiator : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject prefabToInstantiate;
    [SerializeField] float spawnPosX1 = -1.5f;
    [SerializeField] float spawnPosX2 = 1.0f;
    [SerializeField] float spawnPosY1 = -1.5f;
    [SerializeField] float spawnPosY2 = 1.0f;
    private int numberOfPrefabs = 0;
    [SerializeField]TextMeshProUGUI protonText;
    [SerializeField]TextMeshProUGUI neutronText;
    [SerializeField] int previousSliderValue = 10;

    private void Start()
    {
       
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
       
        int difference = Mathf.FloorToInt(value) - Mathf.FloorToInt(previousSliderValue);

        if (difference > 0)
        {
            
            for (int i = 0; i < difference; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(spawnPosX1, spawnPosX2), Random.Range(spawnPosY1, spawnPosY2), 0);
                Instantiate(prefabToInstantiate, spawnPos, prefabToInstantiate.transform.rotation);
                numberOfPrefabs++;
                if(prefabToInstantiate.tag == "Proton")
                    protonText.text = (numberOfPrefabs + 10).ToString();
                else if(prefabToInstantiate.tag == "Neutron")
                    neutronText.text = (numberOfPrefabs + 10).ToString();

            }
        }
        else if (difference < 0)
        {
            
            int prefabsToDestroy = Mathf.Abs(difference);
            GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(prefabToInstantiate.tag);

            for (int i = 0; i < prefabsToDestroy && i < objectsToDestroy.Length; i++)
            {
                DestroyImmediate(objectsToDestroy[i]);
                numberOfPrefabs--;
                if (prefabToInstantiate.tag == "Proton")
                    protonText.text = (numberOfPrefabs+10).ToString();
                else if (prefabToInstantiate.tag == "Neutron")
                    neutronText.text = (numberOfPrefabs + 10).ToString();
            }
        }
        previousSliderValue = (int)value;
    }
}
