using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyUI : MonoBehaviour
{

    public Sprite Red_X;
    public Sprite White_X;

    public Image penaltyPrefab;
    public List<Image> panelties;

    PenaltyTracker PenaltyTracker;

    private void Start()
    {
        PenaltyTracker = FindObjectOfType<PenaltyTracker>();

        panelties = new List<Image>();
        for (int i= 0; i < PenaltyTracker.MaxStrikes; i++)
        {
            panelties.Add(Instantiate(penaltyPrefab, transform));
        }

        UpdatePenalty(PenaltyTracker.Strikes);
        PenaltyTracker.PlayerFined.AddListener(() => UpdatePenalty(PenaltyTracker.Strikes));
    }

    private void UpdatePenalty(int count)
    {
        if(count > panelties.Count)
        {
            return;
        }

        int index = 0;

        for(index = 0; index < count; index++)
        {
            panelties[index].sprite = Red_X;
        }

        for(index = count; index < panelties.Count; index++)
        {
            panelties[index].sprite = White_X;
        }
    }
}