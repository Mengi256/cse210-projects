

public class Entry
{
    public string _date;
    public string _prompt;
    public string _answer;
    public string _mood;


    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt} -- {_answer} - (mood:{_mood})");
    }
}