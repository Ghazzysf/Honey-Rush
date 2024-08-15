using UnityEngine;
using TMPro;

public class Waypoint : MonoBehaviour
{
    [SerializeField] RectTransform prefab;

    private Transform player;
    private RectTransform waypoint;
    private TMP_Text distanceText;
    private Vector3 offset =  new Vector3(0, 2f, 0);

    private float minX, maxX, minY, maxY;

    void Start()
    {
        var canvas = GameObject.Find("Waypoints").transform;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        waypoint = Instantiate(prefab, canvas);
        distanceText = waypoint.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position + offset);

        minX = waypoint.rect.width / 2;
        maxX = Screen.width - minX;
        minY = waypoint.rect.height / 2;
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
