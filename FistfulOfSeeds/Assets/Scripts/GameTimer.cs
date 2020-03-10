using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private static ulong gameTicks = 0;
    public static bool existsInScene;

    /* initialize to false so that no other gameTimers are made*/
    static GameTimer()
    {
        existsInScene = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        /* Check to see if Game Timer exists, and if so, don't create a new one */
        if (!existsInScene)
        {
            existsInScene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* update timer when not paused */
    void FixedUpdate()
    {
        /* Don't update timer when paused */
        if (Time.timeScale != 0)
        {
            ++gameTicks;
        }

    }

    /* Set this when loading */
    public void setTicks(ulong ticks)
    {
        gameTicks = ticks;
    }

    /* Get the current number of ticks*/
    public ulong getTicks()
    {
        return gameTicks;
    }

    /* Reset the timer to 0 */
    public void resetTimer()
    {
        gameTicks = 0;
    }

    /* Get the number of ticks that passed since start */
    public ulong TicksElapsed(ulong start)
    {
        return gameTicks - start;
    }
}
