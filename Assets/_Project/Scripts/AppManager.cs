using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class AppManager : MonoBehaviour
{
    [SerializeField] private Button btnActiveET;
    [SerializeField] private Button btnDisableET;

    private PositionalDeviceTracker deviceTracker;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        VuforiaARController.Instance.RegisterVuforiaInitializedCallback(OnVuforiaInitialized);
    }

    private void Start()
    {
        btnActiveET.onClick.AddListener(OnButtonActiveETClicked);
        btnDisableET.onClick.AddListener(OnButtonDisableETClicked);
    }

    private void OnVuforiaInitialized()
    {
        VuforiaConfiguration.Instance.DeviceTracker.FusionMode = FusionProviderType.OPTIMIZE_IMAGE_TARGETS_AND_VUMARKS;
        deviceTracker = TrackerManager.Instance.InitTracker<PositionalDeviceTracker>();
        OnButtonDisableETClicked();
    }

    private void OnButtonActiveETClicked()
    {
        deviceTracker.Start();
    }

    private void OnButtonDisableETClicked()
    {
        deviceTracker.Stop();
    }
}