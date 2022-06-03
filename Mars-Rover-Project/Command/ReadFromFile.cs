namespace Mars_Rover_Project.Command;

public class ReadFromFile
{
    public readonly DirectoryInfo? directoryInfo = 
        Directory.GetParent(
            Directory.GetParent(
                Directory.GetParent
                    (Directory.GetCurrentDirectory())?.ToString()
                ?? string.Empty)?.ToString() ?? string.Empty);

    public IEnumerable<string?> Read()=>File.ReadAllLines(directoryInfo + "\\Command\\Instructions.txt");
    
}