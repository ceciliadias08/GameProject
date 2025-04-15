using UnityEngine;
using UnityEngine.SceneManagement;// Library to restart the phase

public class NextLevelPoint : MonoBehaviour
{
    public string lvlName;
    // Identify when the character touches the next level point
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}
