using BussinessLayer.DataAccess;
using BussinessLayer.DataAccess.Repositories;
using BussinessLayer.Models;
using ServiceLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CRUDControler
{
    public static class DBManager
    {
        private static GolfContext context;
        private static CourseRepository courseRepository;
        private static HoleRepository holeRepository;
        private static PlayerRepository playerRepository;
        private static DBFinder finder;

        private const int DEFALT_INT_ID = default; 

        static DBManager()
        {
            context = new GolfContext();
            courseRepository = new CourseRepository(context);
            holeRepository = new HoleRepository(context);
            playerRepository = new PlayerRepository(context);
            finder = new DBFinder(context);
        }

        public static string Run(ModelType modelType, OperationType operationType, params object[] args)            
        {
           //Reloads the context, to not get errors from entity tracking
            context = new GolfContext();

            if (operationType == OperationType.FindTotal)
            {
                return FindTotal(int.Parse(args[0].ToString()));
            }
            else if(operationType == OperationType.FindAverage)
            {
                return FindAverage();
            }



            if (modelType == ModelType.Course)
            {
                return ManageCourses(operationType, args);
            }
            if(modelType == ModelType.Hole)
            {
                return ManageHoles(operationType, args);
            }
            if(modelType == ModelType.Player)
            {
                return ManagePlayers(operationType, args);
            }
            return "";
        }

        private static string ManagePlayers(OperationType operationType, object[] args)
        {
            string message = "";
            switch (operationType)
            {
                case OperationType.Create:
                    List<Course> coursesToBeCreated = new List<Course>();
                    if (args.Length > 2)
                    {
                        int[] coursesToBeCreatedId = args[2] as int[];
                        coursesToBeCreated = finder.FindCourses(coursesToBeCreatedId);
                    }

                    Player playerToBeCreated = DBFactory.GetPlayer(DEFALT_INT_ID, args[0], args[1], coursesToBeCreated);
                    playerRepository.Create(playerToBeCreated);
                    break;
                case OperationType.Read:
                    int readKey = int.Parse(args[0].ToString());
                    message = playerRepository.Read(readKey).ToString() + Environment.NewLine;
                    break;
                case OperationType.Delete:
                    int delKey = int.Parse(args[0].ToString());
                    playerRepository.Delete(delKey);
                    break;
                case OperationType.Update:
                    List<Course> coursesToBeUpdated = new List<Course>();
                    if (args.Length > 2)
                    {
                        int[] coursesToBeUpdatedId = args[2] as int[];
                        coursesToBeUpdated = finder.FindCourses(coursesToBeUpdatedId);
                    }

                    Player playerToBeUpdated = DBFactory.GetPlayer(args[0], args[1], args[2], coursesToBeUpdated);
                    playerRepository.Create(playerToBeUpdated);
                    break;
                case OperationType.Find:
                    List<Player> playersFound = playerRepository.Find(args[0].ToString());
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var item in playersFound)
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }
                    message = stringBuilder.ToString();
                    break;
                case OperationType.ReadAll:
                    List<Player> players = playerRepository.ReadAll();
                    stringBuilder = new StringBuilder();
                    foreach (var item in players)
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }
                    message = stringBuilder.ToString();
                    break;                
                default:
                    break;
            }
            return message + "Next:";
        }

        private static string ManageHoles(OperationType operationType, object[] args)
        {
            string message = "";
            switch (operationType)
            {
                case OperationType.Create:
                    Course courseToBeCreated=new Course();
                    if (args.Length > 3)
                    {
                        int courseToBeCreatedId = int.Parse(args[3].ToString());
                        courseToBeCreated = finder.FindCourse(courseToBeCreatedId);
                    }

                    Hole holeToBeCreated = DBFactory.GetHole(DEFALT_INT_ID, args[0], args[1], args[2], courseToBeCreated);
                    holeRepository.Create(holeToBeCreated);
                    break;
                case OperationType.Read:
                    int readKey = int.Parse(args[0].ToString());
                    message = holeRepository.Read(readKey).ToString() + Environment.NewLine;
                    break;
                case OperationType.Delete:
                    int delKey = int.Parse(args[0].ToString());
                    holeRepository.Delete(delKey);
                    break;
                case OperationType.Update:
                    Course courseToBeUpdated = new Course();
                    if (args.Length > 3)
                    {
                        int courseToBeUpdatedId = int.Parse(args[3].ToString());
                        courseToBeUpdated = finder.FindCourse(courseToBeUpdatedId);
                    }

                    Hole holeToBeUpdated = DBFactory.GetHole(args[0], args[1], args[2], args[3], courseToBeUpdated);
                    holeRepository.Create(holeToBeUpdated);
                    break;
                case OperationType.Find:
                    List<Hole> holesFound = holeRepository.Find(args[0].ToString());
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var item in holesFound)
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }
                    message = stringBuilder.ToString();
                    break;                    
                case OperationType.ReadAll:
                    List<Hole> holes = holeRepository.ReadAll();
                    stringBuilder = new StringBuilder();
                    foreach (var item in holes)
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }
                    message = stringBuilder.ToString();
                    break;                
                default:
                    break;
            }
            return message + "Next:";
        }

        private static string ManageCourses(OperationType operationType, params object[] args)
        {
            string message="";
            switch (operationType)
            {
                case OperationType.Create:
                    List<Hole> holesToBeCreated = new List<Hole>();
                    List<Player> playersToBeCreated = new List<Player>();
                    if (args.Length > 3)
                    {
                        int[] holesToBeCreatedId = args[2] as int[];
                        int[] playersToBeCreatedId = args[3] as int[];
                        holesToBeCreated = finder.FindHoles(holesToBeCreatedId);
                        playersToBeCreated = finder.FindPlayers(playersToBeCreatedId);
                    }

                    Course toBeCreated = DBFactory.GetCourse(DEFALT_INT_ID, args[0], args[1], holesToBeCreated, playersToBeCreated);
                    courseRepository.Create(toBeCreated);                    
                    break;

                case OperationType.Read:
                    int readKey = int.Parse(args[0].ToString());
                    message = courseRepository.Read(readKey).ToString() + Environment.NewLine;
                    break;

                case OperationType.Delete:
                    int deleteKey = int.Parse(args[0].ToString());
                    courseRepository.Delete(deleteKey);
                    break; 
                    
                case OperationType.Update:
                    List<Hole> holesToBeUpdated = new List<Hole>();
                    List<Player> playersToBeUpdated = new List<Player>();
                    if (args.Length > 4)
                    {
                        int[] holesToBeUpdatedId = args[3] as int[];
                        int[] playersToBeUpdateId = args[4] as int[];
                        holesToBeUpdated = finder.FindHoles(holesToBeUpdatedId);
                        playersToBeUpdated = finder.FindPlayers(playersToBeUpdateId);
                    }

                    Course toBeUpdated = DBFactory.GetCourse(args[0], args[1], args[2], holesToBeUpdated, playersToBeUpdated);
                    courseRepository.Create(toBeUpdated);
                    break;

                case OperationType.Find:
                    List<Course> coursesFound = courseRepository.Find(args[0].ToString());
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var item in coursesFound)
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }
                    message = stringBuilder.ToString();
                    break;

                case OperationType.ReadAll:
                    List<Course> courses = courseRepository.ReadAll();
                    stringBuilder = new StringBuilder();
                    foreach (var item in courses)
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }
                    message = stringBuilder.ToString();
                    break;               
            }
            return message + "Next:";
        }

        private static string FindAverage()
        {
            double avgPlayerScore = playerRepository.ReadAll().Average(x => x.Score);
            return $"AvgScore: {avgPlayerScore}";
        }

        private static string FindTotal(int key)
        {
            Course currentCourse = courseRepository.Read(key);
            int totalMeters = currentCourse.Holes.Sum(x => x.Length);
            int totalPar = currentCourse.Holes.Sum(x => x.Par);
            return new StringBuilder()
                .Append(currentCourse)
                .AppendLine($"TotalMeters: {totalMeters}")
                .AppendLine($"TotalPar: {totalPar}")
                .ToString();
        }
    }
}
