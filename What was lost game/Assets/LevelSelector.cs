using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public void Select( string LevelName)
    {
        fader.FadeTo(LevelName);
    }
}
