using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
    public const string PlayerSpriteFilenameStart = "Sprites/PlayerSprites/spr_";

	public static int ParentGenderId = 1; // 1: Male, 2: Female
    public static int GenderId = 1; // 1: Boy, 2: Girl
    public static int HairId = 1;
	public static bool MoveFlag = true;
	public static int nearestObjectId = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static string FormSpritePath(string pieceName, int dir)
    {
        string dirString = "";
        switch (dir)
        {
            case 0:
                dirString = "_south";
                break;
            case 1:
                dirString = "_west";
                break;
            case 2:
                dirString = "_east";
                break;
            case 3:
                dirString = "_north";
                break;
            case 4:
                dirString = "_idle";
                break;
        }
        return PlayerSpriteFilenameStart + pieceName + dirString;
    }
}
