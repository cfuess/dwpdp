using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.codekata
{
  public class FileItem
  {

    public string Color { get; internal set; }
    public string Name { get; set; }
    public string Parent { get; set; }
    public itemtype Filetype { get; set; }

    public enum itemtype
    {
      filetype,
      directorytype
    }

    public FileItem(itemtype filetype, string name, string parent)
    {
      Filetype = filetype;
      Name = name;
      Parent = parent;


    }

  }
}
