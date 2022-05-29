namespace Mars_Rover_Project.Command;

public class WriteOnFile
{
    public string _fileName{get;set;}
    public string _content{get;set;}
    
    public WriteOnFile(string fileName, string content)
    {
        _fileName = fileName;
        _content = content;
    }

    public void Execute()
    {
        File.WriteAllText(_fileName, _content);
    }
}
 