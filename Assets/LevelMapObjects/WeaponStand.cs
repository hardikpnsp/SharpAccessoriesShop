using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.LevelMapObjects
{
    public class WeaponStand : MonoBehaviour
    {
        [SerializeField]
        private Transform[] standPositions;

        private List<Transform> positions;

        public UnityEvent<WeaponStand, bool> StandAvailabilityChanged = new();

        private void Awake()
        {
            positions = new List<Transform>(standPositions);
        }

        public bool TryTakeRandomPosition(out Transform position)
        {
            if(positions.Count == 0)
            {
                position = null;
                return false;
            }
            else
            {
                int randomIndex = Random.Range(0, positions.Count);
                position = positions[randomIndex];
                positions.RemoveAt(randomIndex);

                if(positions.Count == 0)
                {
                    StandAvailabilityChanged.Invoke(this, false);
                }

                return true;
            }
        }

        public void ReturnPosition(Transform position)
        {
            positions.Add(position);

            if(positions.Count == 1)
            {
                StandAvailabilityChanged.Invoke(this,true);
            }
        }
    }
}