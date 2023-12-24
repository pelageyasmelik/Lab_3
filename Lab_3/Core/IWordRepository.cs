using Lab_3.Model;

namespace Lab_3.Core;

public interface IWordRepository {
    public List<WordModel> GetAll();
    public void AddNewWord(WordModel newWord);
    public List<WordModel> SameRoot(string word);
}