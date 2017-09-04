using System;
using System.Collections.Generic;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;

namespace VideoMenuUI
{
    public class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        static void Main(string[] args)
        {
            var video1 = new VideoBO()
            {
                Name = "Generic cat video 329"
            };
            bllFacade.VideoService.Create(video1);

            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = "Something, something clickbait"
            });

            String[] menuItems = {
                "List all Videos",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit\n"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideos();
                        break;
                    case 3:
                        DeleteVideos();
                        break;
                    case 4:
                        EditVideos();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("See ya!");

            Console.ReadLine();
        }

        private static void EditVideos()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                Console.WriteLine("Name: ");
                videoFound.Name = Console.ReadLine();
                bllFacade.VideoService.Update(videoFound);
            }
            var response = videoFound == null ? "The video dosen't exist" : "Video was edited";
            Console.WriteLine(response);
        }

        private static VideoBO FindVideoById()
        {
            Console.WriteLine("Insert Video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return bllFacade.VideoService.Get(id);
        }
        private static void DeleteVideos()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
            var response = videoFound == null ? "The video dosen't exist" : "Video was Deleted";
            Console.WriteLine(response);
        }

        private static void AddVideos()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = name
            });
        }

        private static void ListVideos()
        {
            Console.WriteLine("\nList of Videos");
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine($"Video: {video.Id} Name: {video.Name}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("What do you want to do, select a number between 1-5:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5)
            {
                Console.WriteLine("you need to select a number between 1-5");
            }

            Console.WriteLine("selection: " + selection);
            return selection;
        }
    }
}