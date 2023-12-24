using Lab_3.Model;

namespace Lab_3.Core;

public class WordRepository:IWordRepository {
    private readonly WordContext _dbContext;

    public WordRepository(WordContext dbContext) {
        _dbContext = new WordContext();
        _dbContext.Database.EnsureCreated();
    }
    
    public List<WordModel> GetAll() {
        if (_dbContext.Words == null) return new List<WordModel>();
        return _dbContext.Words.ToList();
    }

    public void AddNewWord(WordModel newWord) {
        _dbContext.Words.Add(newWord);
        _dbContext.SaveChanges();
    }

    public List<WordModel> SameRoot(string word) {
        return _dbContext.Words.Where(w => word.Contains(w.root)).ToList();
    }
}