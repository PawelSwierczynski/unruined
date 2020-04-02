using UnityEngine;

public class LevelInformations : MonoBehaviour
{
    public int LeftBorderPositionX { get; private set; }
    public int RightBorderPositionY { get; private set; }
    public int DownBorderPositionY { get; private set; }

    void Start()
    {
        LeftBorderPositionX = 0;
        RightBorderPositionY = 22;
        DownBorderPositionY = 40;
    }
}
