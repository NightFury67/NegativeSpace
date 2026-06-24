using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucontrols : MonoBehaviour
{
   public void NewGameButton()
    {
        SceneManager.LoadScene("Main-Cave");
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Main-Cave");
    }
}
