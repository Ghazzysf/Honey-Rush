using Unity.Mathematics;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] Transform spaawner;
    [SerializeField] GameObject[] charPrefab;

    void Awake() 
    {
        Cursor.visible = false;    
    }

    void Start()
    {
        int selectedChar = PlayerPrefs.GetInt("selectedChar");
        GameObject prefab = charPrefab[selectedChar];
        GameObject clone = Instantiate(prefab, spaawner.position, quaternion.identity);
    }
}