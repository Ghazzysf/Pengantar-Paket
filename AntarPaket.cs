using UnityEngine;
using UnityEngine.SceneManagement;

public class AntarPaket : MonoBehaviour
{
    [SerializeField] Transform spawner;
    [SerializeField] GameObject prefab;
    [SerializeField] AudioClip deliverySound, bumpingSound;

    AudioSource audioSource;

    private int currentLvl;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentLvl = SceneManager.GetActiveScene().buildIndex;
        print(currentLvl);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Barrier")
        {
            PlayerPrefs.SetInt("PrevLvl", currentLvl);
            PlayerPrefs.SetString("ResultString", "YOU LOSE!");
            SceneManager.LoadScene(1);
        }
        if(other.tag == "Paket")
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(deliverySound);
            Instantiate(prefab, spawner.position, Quaternion.identity);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            audioSource.PlayOneShot(bumpingSound);
        }
    }
}