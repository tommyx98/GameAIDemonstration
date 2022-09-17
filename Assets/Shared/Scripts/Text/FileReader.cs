using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileReader
{
    public string ReadFile(string path) {
        StreamReader reader = new StreamReader(path);
        return reader.ReadToEnd();
    }
}
