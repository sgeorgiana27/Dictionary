public class Word
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string ImagePath { get; set; }
    public bool ShowImage { get; set; } 

    public Word(string name, string description, string category, string imagePath)
    {
        Name = name;
        Description = description;
        Category = category;
        ImagePath = imagePath;
        ShowImage = false; 
    }
}
