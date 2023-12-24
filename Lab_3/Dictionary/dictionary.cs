using Lab_3.Core;
using Lab_3.Model;

namespace Lab_3.Dictionary;

public class dictionary
{
    private IWordRepository _wordRepository;

    public dictionary(IWordRepository wordRepository) {
        _wordRepository = wordRepository;
    }
    
    
    public SortedSet<Word> ListWords() {
        Console.WriteLine("List Words: ");
        var words = changeData();
        foreach (var word in words)
            Console.WriteLine(word.GetWord());
        return words;
    }

    public void AddWord(string word) {
        if (!checkWord(word)) {
            Console.Write($"Unknown word. Want to add it to the dictionary? (Y/N)");
            if (Console.ReadLine().Equals("Y")) {
                Word newWord = new Word(word);
                AddNewWord(newWord);
            }
            return;
        }
        Console.WriteLine("Famous words:");
        var WordsFromTheSameRoot = SameRoot(word);
        foreach (var w in WordsFromTheSameRoot)
            Console.WriteLine(w);
    }

    public bool checkWord(string word) {
        if (_wordRepository.GetAll().Count == 0) return false;
        return changeData().Any(w => w.fullWord == word);
    }
    
    public void AddNewWord(Word word) {
        var newWord = new WordModel() {
            fullWord = word.fullWord,
            root = word.root,
            suffixes = word.GetSuffixes()
        };
        _wordRepository.AddNewWord(newWord);
        Console.WriteLine($"The word {word.fullWord} has been added.");
    }

    public SortedSet<string> SameRoot(string w) {
        return new SortedSet<string>(
            _wordRepository.SameRoot(w)
            .Select(word => word.fullWord)
        );
    }

    private SortedSet<Word> changeData() {
        return new SortedSet<Word>(
            _wordRepository.GetAll()
                .Select(word => new Word(word.root, word.changSuffixes()))
            );
    }
}