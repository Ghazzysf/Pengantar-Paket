using UnityEngine;

public class LoadCar : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] GameObject[] carPrefab;

    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("selectedCar");
        GameObject prefab = carPrefab[selectedCar];
        GameObject clone = Instantiate(prefab, parent.position,
        parent.localRotation, parent.transform);
    }
}