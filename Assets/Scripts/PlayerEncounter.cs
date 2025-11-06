using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEncounter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
