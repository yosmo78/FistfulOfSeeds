using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToNewGame;
    public string sceneToLoadGame;
    private logan_player_controller player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        player = FindObjectOfType<logan_player_controller>();
        CameraFollow camera = FindObjectOfType<CameraFollow>();
        camera.isFollowing = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        GlobalSceneChange.locationFrom = "MainMenu";
        GlobalSceneChange.sceneFrom = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneToNewGame);
    }

    public void LoadGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
