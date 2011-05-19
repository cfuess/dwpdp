using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure;
using System.IO;

namespace nothinbutdotnetprep.codekata
{
  public class FileList
  {
    readonly IList<FileItem> files;

    public FileList(string path)
    {
      string[] sfiles;
      sfiles = Directory.GetFiles(path);
      foreach (var s in sfiles)
      {
        FileInfo f = new FileInfo(s);
        
        //files.Add(new FileItem());

      }

    }
    
    public FileList(IList<FileItem> list_of_files)
    {
      files = list_of_files;
    }

    public IEnumerable<FileItem> all_files()
    {
      return files.one_at_a_time();
    }

    public void add(FileItem file)
    {
      if (already_contains(file)) return;

      files.Add(file);
    }
     
    bool already_contains(FileItem file)
    {
      return files.Contains(file);
    }


  }
}
