using Lab_3.Model;

namespace Lab_3.Dictionary;

public class Word : IComparable<Word>
{
    public string fullWord { get; set; }
    public string root { get; set; }
    public List<string> suffixes;

    public Word(string word)
    {
        fullWord = word;
        WordConsole(word);
    } 

    public Word(string root, List<string> suffixes) {
        this.root = root;
        this.suffixes = suffixes;
        fullWord = GetWord().Replace("-", "");
    }

    public string GetWord() {
        string word = root;
        foreach (var suffix in suffixes)
            word += $"-{suffix}";
        return word;
    }

    public List<Model.SuffixModel> GetSuffixes()
    {
        return suffixes.Select(s => new Model.SuffixModel()
        {
            Id = Guid.NewGuid(),
            suffix = s
        }).ToList();
    }
    private void WordConsole(string word) {
        Console.WriteLine("Console:");
        Console.Write("Root: ");
        root = Console.ReadLine();
        word = word.Substring(root.Length);
        suffixes = new List<string>();
        while (word.Length != 0) {
            Console.Write("Suffix or ending:");
            string suffix = Console.ReadLine();
            suffixes.Add(suffix);
            word = word.Substring(suffix.Length);
        }
    }

    public int CompareTo(Word other)
    {
        return fullWord.CompareTo(other.fullWord);
    }
}