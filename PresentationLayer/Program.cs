using ServiceLayer.CRUDControler;
using ServiceLayer.Enums;
using System;
using System.Linq;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray;
            string inputString;
            bool flag = true;
            string message;
            int[] helper1, helper2;

            do
            {
                Console.WriteLine(
@"Choose:
1) Manage Courses
2) Manage Holes
3) Manage Players
4) Find Total parameters for some course
5) Find the average score for players
6) Exit"
                    );

                int firstChose = int.Parse(Console.ReadLine());
                int secondChose;

                switch (firstChose)
                {
                    
                    case 1:
                        secondChose = GetSecondChose();
                        switch (secondChose)
                        {
                            case 1:
                                Console.WriteLine("Enter the name and the number of holes");
                                inputArray = Console.ReadLine().Split();
                                Console.WriteLine("Enter the holes ids");
                                helper1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                Console.WriteLine("Enter the players ids:");
                                helper2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                message = DBManager.Run(ModelType.Course, OperationType.Create, inputArray[0], inputArray[1], helper1, helper2);
                                break;
                            case 2:
                                Console.WriteLine("Enter Id");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Course, OperationType.Read, inputString);
                                break;
                            case 3:                                
                                message = DBManager.Run(ModelType.Course, OperationType.ReadAll);
                                break;
                            case 4:
                                Console.WriteLine("Enter the id of the course, updated name and number of holes:");
                                inputArray = Console.ReadLine().Split();                                
                                Console.WriteLine("Enter the holes ids");
                                helper1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                Console.WriteLine("Enter the players ids:");
                                helper2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                message = DBManager.Run(ModelType.Course, OperationType.Update, inputArray[0], inputArray[1], inputArray[2], helper1, helper2);
                                break;
                            case 5:
                                Console.WriteLine("Enter Id to delete course");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Course, OperationType.Delete, inputString);
                                break;
                            case 6:
                                Console.WriteLine("Enter name to find course:");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Course, OperationType.Find, inputString);
                                break;
                            default:
                                continue;
                        }
                        break;
                    case 2:
                        secondChose = GetSecondChose();
                        switch (secondChose)
                        {
                            case 1:
                                Console.WriteLine("Enter the hole's number, length, par and the course's id");
                                inputArray = Console.ReadLine().Split();                                
                                message = DBManager.Run(ModelType.Hole, OperationType.Create, inputArray[0], inputArray[1], inputArray[2], inputArray[3]);
                                break;
                            case 2:
                                Console.WriteLine("Enter Id");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Hole, OperationType.Read, inputString);
                                break;
                            case 3:
                                message = DBManager.Run(ModelType.Hole, OperationType.ReadAll);
                                break;
                            case 4:
                                Console.WriteLine("Enter the hole's ID, number, length, par and the course's id");
                                inputArray = Console.ReadLine().Split();
                                message = DBManager.Run(ModelType.Hole, OperationType.Update, inputArray[0], inputArray[1], inputArray[2], inputArray[3], inputArray[4]);
                                break;
                            case 5:
                                Console.WriteLine("Enter Id to delete hole");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Hole, OperationType.Delete, inputString);
                                break;
                            case 6:
                                Console.WriteLine("Enter number to find hole:");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Hole, OperationType.Find, inputString);
                                break;
                            default:
                                continue;
                        }
                        break;
                    case 3:
                        secondChose = GetSecondChose();
                        switch (secondChose)
                        {
                            case 1:
                                Console.WriteLine("Enter the name and the Score for the player");
                                inputArray = Console.ReadLine().Split();
                                Console.WriteLine("Enter the courses ids");
                                helper1 = Console.ReadLine().Split().Select(int.Parse).ToArray();                                
                                message = DBManager.Run(ModelType.Player, OperationType.Create, inputArray[0], inputArray[1], helper1);
                                break;
                            case 2:
                                Console.WriteLine("Enter Id");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Player, OperationType.Read, inputString);
                                break;
                            case 3:
                                message = DBManager.Run(ModelType.Player, OperationType.ReadAll);
                                break;
                            case 4:
                                Console.WriteLine("Enter the ID, name and the Score for the player");
                                inputArray = Console.ReadLine().Split();
                                Console.WriteLine("Enter the courses ids");
                                helper1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                message = DBManager.Run(ModelType.Player, OperationType.Create, inputArray[0], inputArray[1], inputArray[2], helper1);
                                break;
                            case 5:
                                Console.WriteLine("Enter Id to delete player");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Player, OperationType.Delete, inputString);
                                break;
                            case 6:
                                Console.WriteLine("Enter name to find player:");
                                inputString = Console.ReadLine();
                                message = DBManager.Run(ModelType.Player, OperationType.Find, inputString);
                                break;
                            default:
                                continue;
                            
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Course id:");
                        secondChose = int.Parse(Console.ReadLine());
                        message = DBManager.Run(ModelType.Course, OperationType.FindTotal, secondChose);
                        break;
                    case 5:
                        message = DBManager.Run(ModelType.Course, OperationType.FindAverage);
                        break;
                    case 6:
                        Console.WriteLine("Are sure about that? (y/n)");
                        inputString = Console.ReadLine().ToLower();
                        if (inputString[0] == 'y')
                        {
                            flag = false;
                        }
                        break;
                    default:
                        break;
                }


            } while (flag);
        }

        private static int GetSecondChose()
        {
            Console.WriteLine(
@"ChooseAgain:
1) Create new
2) Read by id
3) Read all
4) Update existing
5) Delete by id
6) Find by name
"
);

            return int.Parse(Console.ReadLine());
        }
    }
}
