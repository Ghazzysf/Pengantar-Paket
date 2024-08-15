using TMPro;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] RectTransform prefab;
    [SerializeField] Transform player;

    private RectTransform waypoint;
    private TMP_Text distanceText;

    private float minX, maxX, minY, maxY;

    void Start()
    {
        var canvas = GameObject.Find("Waypoints").transform;

        waypoint = Instantiate(prefab, canvas);
        distanceText = waypoint.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        minX = waypoint.rect.width;
        maxX = Screen.width - minX;
        minY = waypoint.rect.height;
        maxY = Screen.height - minY;

        if (screenPos.z < 0)
        {
            if (screenPos.x < Screen.width / 2)
            {
                screenPos.x = maxX;
            }
            else
            {
                screenPos.x = minX;
            }

            if (screenPos.y < Screen.height / 2)
            {
                screenPos.y = maxY;
            }
            else
            {
                screenPos.y = minY;
            }
        }

        screenPos.x = Mathf.Clamp(screenPos.x, minX, maxX);
        screenPos.y = Mathf.Clamp(screenPos.y, minY, maxY);

        waypoint.position = screenPos;

        distanceText.text = Vector3.Distance
        (player.position, transform.position).ToString("0") + "m";
    }

    void OnDestroy()
    {
        Destroy(waypoint.gameObject);
    }
}