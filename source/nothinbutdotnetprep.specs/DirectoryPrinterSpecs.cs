using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetprep.codekata;
using nothinbutdotnetprep.tests.utility;

namespace nothinbutdotnetprep.specs
{
  class DirectoryPrinterSpecs
  {
    public abstract class file_library_concern : Observes<FileList>
    {
      protected static IList<FileItem> file_collection;

      Establish c = () =>
      {
        file_collection = new List<FileItem>();
        depends.on(file_collection);
      };
    } ;

    public class when_iterating : file_library_concern
    {
      static IEnumerable<FileItem> all_files;

      Establish c = () =>
        Enumerable.Range(1, 100).each(x => file_collection.Add(new FileItem()));

      Because b = () =>
        all_files = sut.all_files();


      It should_iterate = () =>
      {
        all_files.First();
      };
    }

    [Subject(typeof(FileList))]
    public class when_counting_the_number_of_files : file_library_concern
    {
      static int number_of_files;

      Establish c = () =>
        file_collection.add_all(new FileItem(), new FileItem());

      Because b = () =>
        number_of_files = sut.all_files().Count();

      It should_return_the_number_of_all_files_in_the_library = () => { number_of_files.ShouldEqual(2); };
    }
  
  }
}
