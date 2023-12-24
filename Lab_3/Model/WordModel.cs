using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Lab_3.Model;

public class WordModel
{
    [Key]
    public string fullWord { get; set; }
    public string root { get; set; }
    public List<SuffixModel> suffixes { get; set; }

    public List<string> changSuffixes() {
        if (suffixes == null) return new List<string>();
        return suffixes.Select(s => s.suffix).ToList();
    }
}
