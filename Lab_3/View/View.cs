using Lab_3.Dictionary;

namespace Lab_3.View;

public class View
{ 
    private readonly dictionary dictionary;

    public View(dictionary _dictionary) {
        dictionary = _dictionary ?? throw new AggregateException();
    }
    public void start() {
        while (true) {
            string word = Console.ReadLine();
            if (word == "get all") dictionary.ListWords();
            else if (word == "q") break;
            else dictionary.AddWord(word);
        }   
    }
}