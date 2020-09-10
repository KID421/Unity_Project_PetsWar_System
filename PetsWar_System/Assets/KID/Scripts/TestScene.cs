using UnityEngine;
using KID;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print(RandomScene.LoadRandomScene());
        }
    }
}
