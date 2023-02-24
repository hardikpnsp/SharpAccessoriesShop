using System.Collections;
using UnityEngine;


public class PatienceUISpawner : MonoBehaviour
{
    [SerializeField]
    PatienceUI prefab;

    PatienceUI ui;

    private PatienceController controller;

    private WorldCanvasController worldCanvasController;

    private void Start()
    {
        worldCanvasController = WorldCanvasController.Instance;

        controller = gameObject.GetComponentInParent<PatienceController>();

        controller.PatienceTimerStarted.AddListener(CreatePatienceUI);

        controller.PatienceTimerEnded.AddListener(RemovePatienceUI);
        controller.PatienceTimerStoped.AddListener(RemovePatienceUI);
    }

    private void Update()
    {
        if(ui != null && controller.timer != null)
        {
            float value = (controller.timer.secondsLeft / controller.lengthSeconds);
            ui.SetFill(value);

            ui.transform.position = transform.position;
        }
    }

    private void CreatePatienceUI()
    {
        ui = worldCanvasController.InstantiateToWorldCanvas(prefab.gameObject, this.transform.position).GetComponent<PatienceUI>();
    }

    private void RemovePatienceUI()
    {
        if(ui != null)
        {
            Destroy(ui.gameObject);
            ui = null;
        }

    }
}
