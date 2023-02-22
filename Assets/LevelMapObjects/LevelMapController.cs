using Assets.LevelMapObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapController : MonoBehaviour
{
    public static LevelMapController Instance;

    public QueueController QueueController;

    [SerializeField]
    private List<WeaponStand> weaponStands;

    public bool TryGetRandomWeaponStand(out WeaponStand weaponStand)
    {
        if(weaponStands.Count > 0)
        {
            weaponStand = weaponStands[Random.Range(0, weaponStands.Count)];
            return true;
        }
        else
        {
            weaponStand = null;
            return false;
        }
    }

    public static bool CanGetWeaponStand()
    {
        return Instance != null && Instance.weaponStands.Count > 0;
    }

    public static WeaponStand GetRandomWeaponStand()
    {
        if(Instance == null)
        {
            return null;
        }

        if (Instance.weaponStands.Count > 0)
        {
            return Instance.weaponStands[Random.Range(0, Instance.weaponStands.Count)];
        }
        else
        {
            return null;
        }
    }

    private void Awake()
    {
        foreach (WeaponStand weaponStand in weaponStands)
        {
            weaponStand.StandAvailabilityChanged.AddListener(OnWeaponStandEvent);
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        
    }

    private void Update()
    {
        //Debug
        //if((TryGetRandomWeaponStand(out WeaponStand stand)))
        //{
        //    if (stand.TryTakeRandomPosition(out Transform transform))
        //    {
        //        Debug.Log("True " + stand.name + "->" + transform.gameObject.name);
        //    }
        //    else
        //    {
        //        Debug.Log("False " + stand.name);
        //    }
        //}
    }

    private void OnWeaponStandEvent(WeaponStand stand, bool available)
    {
        if (available)
        {
            weaponStands.Add(stand);
        }
        else
        {
            weaponStands.Remove(stand);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
}
