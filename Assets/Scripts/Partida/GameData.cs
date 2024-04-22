

[System.Serializable]
public class GameData 
{
    public float x;
    public float y;
    public float z;

    public GameData(MoverCubo moverCubo)
    {
        x = moverCubo.X();
        y = moverCubo.Y();
        z = moverCubo.Z();
    }
}
