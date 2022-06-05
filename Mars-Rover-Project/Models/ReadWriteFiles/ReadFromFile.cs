namespace Mars_Rover_Project.Models.ReadWriteFiles;

public class ReadFromFile
{
    public readonly DirectoryInfo? DirectoryInfo = 
        Directory.GetParent(
            Directory.GetParent(
                Directory.GetParent
                    (Directory.GetCurrentDirectory())?.ToString()
                ?? string.Empty)?.ToString() ?? string.Empty);

    public IEnumerable<string?> Read()=>File.ReadAllLines(DirectoryInfo + "\\Command\\Instructions.txt");
}