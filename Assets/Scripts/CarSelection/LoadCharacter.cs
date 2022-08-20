using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using RVP;


public class LoadCharacter : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;
	public TMP_Text label;

	void Awake()
    {
        int selectedCharacter = GetSelectedCharacter();
        
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject player = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        CameraControl cameraControl = FindObjectOfType<CameraControl>();
        cameraControl.target = player.transform;
        cameraControl.Initialize();
        VehicleHud Vehiclehud = FindObjectOfType<VehicleHud>();
        Vehiclehud.targetVehicle = player;
        PowerupUIController powerupUIController= FindObjectOfType<PowerupUIController>();

        powerupUIController.MyPowerupScript = player.GetComponentInChildren<mypowerupscript>();
        //label.text = prefab.name;
    }

    private static int GetSelectedCharacter()
    {
        if (!PlayerPrefs.HasKey("selectedCharacter"))
            PlayerPrefs.SetInt("selectedCharacter", 0);
        return PlayerPrefs.GetInt("selectedCharacter");

    }

   

    

}
