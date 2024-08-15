using UnityEngine;
using TMPro;
public class HoneySpawn : MonoBehaviour
{
    [SerializeField] Transform[] honeyLoc;
    [SerializeField] Transform buildingLoc;
    [SerializeField] GameObject building, honey;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] AudioSource coinSfx;
    [SerializeField] AudioClip coinSoud;
    public TimerAndScore timer;
    private Vector3 offset = new Vector3(2, -2, 0);
    private int score;
    private bool honeyDelivered,hasHoney,buildingSpawn = false;

    void Start()
    {
        PickHoneyLoc();
    }

    void Update() 
    {   
        if (honeyDelivered == true && hasHoney == false)
        {
            print("1");
            PickHoneyLoc();
        }

        if (buildingSpawn == false && honeyDelivered == false && GameObject.Find("Honey(Clone)") == null)
        {
            print(" Func 2");
            coinSfx.PlayOneShot(coinSoud);
            timer.timeAmount += 10;
            hasHoney = true;
            SpawnBuilding();
        }
        
        if(buildingSpawn == true && hasHoney == true)
        {
            DeliverHoney();
        }
    }

    void PickHoneyLoc()
    {
        int pickNum = Random.Range(0, honeyLoc.Length);
        GameObject honeyclone = Instantiate(honey, honeyLoc[pickNum].position, honeyLoc[pickNum].rotation);
        honeyDelivered = false;
        print("Madu Sudah di Spawn!");
    }

    void SpawnBuilding()
    {
        print("spawn");
        GameObject buildingclone = Instantiate(building, buildingLoc.position, Quaternion.identity);
        buildingSpawn = true;
    }
    void DeliverHoney()
    {
        if(GameObject.Find("Building(Clone)") == null)
        {
            coinSfx.PlayOneShot(coinSoud);
            score += 1;
            scoreTxt.text = "Score: " + score.ToString();
            PlayerPrefs.SetInt("Score", score);

            buildingSpawn = false;
            honeyDelivered = true;
            hasHoney = false;
        }
    }
}