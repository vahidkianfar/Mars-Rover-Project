namespace Mars_Rover_Project.Command;

public class WriteOnFile
{
    private string _path{get;set;}
    private string _content{get;set;}
    
    public WriteOnFile(string path, string content)
    {
        _path = path;
        _content = content;
    }

    public void Write()=>File.WriteAllText(_path, _content);
    
}
 