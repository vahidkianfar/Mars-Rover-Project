namespace Mars_Rover_Project.Command;

public class WriteOnFile
{
    private string _fileName{get;set;}
    private string _content{get;set;}
    
    public WriteOnFile(string fileName, string content)
    {
        _fileName = fileName;
        _content = content;
    }

    public void Write()=>File.WriteAllText(_fileName, _content);
    
}
 