using System.ComponentModel.DataAnnotations;

namespace Lab_3.Model;

public class SuffixModel
{
    [Key] public Guid Id { get; set; }
    public string suffix { get; set; }
}