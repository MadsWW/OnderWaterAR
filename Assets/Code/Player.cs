using System;

public class Player  {

    private int score;

    public int Score
    {
        get
        {
            return score;
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }
}