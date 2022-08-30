using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    /*
    public void saveScore(int points, string name)
    {
        File.WriteAllText("scores.txt", "1 juan");
        Score newScore = new Score(points, name);
        List<Score> scores = getScores();
        scores.Add(newScore);
        string combinedString = string.Join(",", scores); // Convert to JSON
        File.WriteAllText("scores.txt", combinedString);
    }
    */
    public void saveScore(int points, string name)
    {
        string scores = getStringScores();
        scores += System.Environment.NewLine + points + " " + name;
        
        File.WriteAllText("scores.txt", scores);
    }

    /*
    public List<Score> getScores()
    {
        string fileContent = File.ReadAllText("scores.txt");
        //Convert from JSON to List<Score>
        return new List<Score>();
    }
    */
    public string getStringScores()
    {
        string fileContent = File.ReadAllText("scores.txt");
        //Convert from JSON to List<Score>
        return fileContent;
    }
}
