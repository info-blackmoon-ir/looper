
[System.Serializable]
public class Looper
{
    public int UniqCode;
    public int Number;
    public float Xvalue;
    public float Yvalue;
    public float ZValue;
    public float ZRotation;
    public string HexCode;
    
}

[System.Serializable]
public class LooperData
{
    public Looper[] loopers;

    public LooperData(Looper[] loopers)
    {
        loopers = this.loopers;
    }
}