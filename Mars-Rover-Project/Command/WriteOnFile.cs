namespace Mars_Rover_Project.Command;

public class WriteOnFile
{
    private string _path{get;set;}
    private List<string> _content{get;set;}
    public WriteOnFile(string path, List<string?> positions)
    {
        _path = path;
        _content = positions;
    }

    public void Write()
    {
        var positionCounter = 1;
        var file = File.CreateText(_path);
        foreach (var position in _content)
        { 
            file.WriteLine("Rover "+positionCounter+" "+position);
            positionCounter++;
        }
        file.Close();
    }
}