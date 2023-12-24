using AutoFixture;
using Lab_3;
using Lab_3.Core;
using Lab_3.Dictionary;
using Lab_3.Model;
using NSubstitute;

namespace TestProject1;

public class UnitTest1
{
    private Fixture _fixture = new Fixture();
    [Fact]
    public void ListWords_ReturnsExpected()
    {
        var suffixes = _fixture.Build<SuffixModel>()
            .With(x => x.suffix, "1")
            .With(x => x.Id, Guid.NewGuid).Create();
        var words = new List<WordModel>
        {
            _fixture.Build<WordModel>()
                .With(x => x.fullWord, "Word1")
                .With(x => x.root, "word")
                .With(x => x.suffixes, new List<SuffixModel> { suffixes }).Create()
        };
        
        var repo = Substitute.For<IWordRepository>();
        repo.GetAll().Returns(words);

        var dictionaryService = new dictionary(repo);
        var result = dictionaryService.ListWords();
        
        Assert.NotNull(result);
        Assert.Equal(1,result.Count);
    }
    
    [Fact]
    public void AddNewWord_ShouldAllNewWordForDataBase() {
        var suffixes = new List<SuffixModel> { new SuffixModel() { Id= Guid.NewGuid(), suffix = "1"}, };
        var word = new WordModel() { fullWord = "word1", root = "word", suffixes = suffixes};
        var repo = Substitute.For<IWordRepository>();
        repo.AddNewWord(word);
        
        repo.Received().AddNewWord(Arg.Is<WordModel>(w => 
            w.fullWord == "word1" && w.root == "word" && suffixes == suffixes));
    }
    
    [Fact]
    public void SameRoot_ShouldAllNewWordForDataBase() {
        var suffixes1 = new List<SuffixModel> { new SuffixModel() { Id= Guid.NewGuid(), suffix = "1"}, };
        var suffixes2 = new List<SuffixModel> { new SuffixModel() { Id= Guid.NewGuid(), suffix = "2"}, };
        var suffixes3 = new List<SuffixModel> { new SuffixModel() { Id= Guid.NewGuid(), suffix = "3"}, };
        
        var word1 = new WordModel() { fullWord = "word1", root = "word", suffixes = suffixes1};
        var word2 = new WordModel() { fullWord = "word2", root = "word", suffixes = suffixes2};
        var word3 = new WordModel() { fullWord = "word3", root = "word", suffixes = suffixes3};
        var repo = Substitute.For<IWordRepository>();
        repo.SameRoot("word").Returns(new List<WordModel> { word1, word2, word3 });
        
        var result = repo.SameRoot("word");
        Assert.Equal(result.Count,3);
    }
}

