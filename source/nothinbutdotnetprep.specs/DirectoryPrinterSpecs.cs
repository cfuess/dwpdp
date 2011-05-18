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

    public abstract class concern_for_searching_and_sorting : file_library_concern
    {
      protected static Movie a_bugs_life;
      protected static Movie cars;
      protected static Movie indiana_jones_and_the_temple_of_doom;
      protected static Movie pirates_of_the_carribean;
      protected static Movie shrek;
      protected static Movie the_ring;
      protected static Movie theres_something_about_mary;

      Establish c = () => { populate_with_default_movie_set(movie_collection); };

      static void populate_with_default_movie_set(IList<Movie> movieList)
      {
        indiana_jones_and_the_temple_of_doom = new Movie
        {
          title = "Indiana Jones And The Temple Of Doom",
          date_published = new DateTime(1982, 1, 1),
          genre = Genre.action,
          production_studio = ProductionStudio.Universal,
          rating = 10
        };
        cars = new Movie
        {
          title = "Cars",
          date_published = new DateTime(2004, 1, 1),
          genre = Genre.kids,
          production_studio = ProductionStudio.Pixar,
          rating = 10
        };

        the_ring = new Movie
        {
          title = "The Ring",
          date_published = new DateTime(2005, 1, 1),
          genre = Genre.horror,
          production_studio = ProductionStudio.MGM,
          rating = 7
        };
        shrek = new Movie
        {
          title = "Shrek",
          date_published = new DateTime(2006, 5, 10),
          genre = Genre.kids,
          production_studio = ProductionStudio.Dreamworks,
          rating = 10
        };
        a_bugs_life = new Movie
        {
          title = "A Bugs Life",
          date_published = new DateTime(2000, 6, 20),
          genre = Genre.kids,
          production_studio = ProductionStudio.Pixar,
          rating = 10
        };
        theres_something_about_mary = new Movie
        {
          title = "There's Something About Mary",
          date_published = new DateTime(2007, 1, 1),
          genre = Genre.comedy,
          production_studio = ProductionStudio.MGM,
          rating = 5
        };
        pirates_of_the_carribean = new Movie
        {
          title = "Pirates of the Carribean",
          date_published = new DateTime(2003, 1, 1),
          genre = Genre.action,
          production_studio = ProductionStudio.Disney,
          rating = 10
        };

        movieList.Add(cars);
        movieList.Add(indiana_jones_and_the_temple_of_doom);
        movieList.Add(pirates_of_the_carribean);
        movieList.Add(a_bugs_life);
        movieList.Add(shrek);
        movieList.Add(the_ring);
        movieList.Add(theres_something_about_mary);
      }
    }
  
  }
}
