
public static class DataLevel
{
    public static int CountBomb { get; set; } = 5;

    public static int HP { get; set; } = 5;

    public static int Level { get; private set; } = 1;

    private static int _score = 0;
    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if (_score >= 10 * Level)
            {
                Level++;
                _score = 0;
            }
        }
    }

    public static void ResetAllStats()
    {
        Level = 1;
        _score = 0;
        HP = 5;
    }
}
