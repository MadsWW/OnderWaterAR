using System;

public class Player  {

    private int score;
    private string name;

    public Player (string playerName)
    {
        name = playerName;
        score = 0;
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }
}