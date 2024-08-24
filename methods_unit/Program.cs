using System;

class Program
{
    static void Main(string[] args)
    {
        var user = EnterUser();
        ShowUserInfo(user);
    }

    static (string Name, string Surname, int Age, string[] PetNames, string[] Colors) EnterUser()
    {
        string name = EnterString("Введите ваше имя: ");
        string surname = EnterString("Введите вашу фамилию: ");
        int age = GetValidInt("Введите ваш возраст: ");

        bool hasPet = HasPet();

        string[] petNames = Array.Empty<string>();
        if (hasPet)
        {
            int petCount = GetValidInt("Введите количество питомцев: ");
            petNames = GetPetNames(petCount);
        }

        int colorCount = GetValidInt("Введите количество любимых цветов: ");
        string[] colors = GetFavoriteColors(colorCount);

        return (name, surname, age, petNames, colors);
    }

    static int GetValidInt(string message)
    {
        int number;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);

        return number;
    }

    public static bool ContainsNoDigits(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    public static string EnterString(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
        } while (!(ContainsNoDigits(input)));
        return input;
    }

    static bool HasPet()
    {
        string mes;
        do
        {
            Console.Write("Есть ли у вас питомец? (да/нет): ");
            mes = Console.ReadLine().ToLower();

            if (mes == "да")
            {
                return true;
            }
            else if (mes == "нет") return false;

        } while (true);
    }

    static string[] GetPetNames(int count)
    {
        string[] petNames = new string[count];
        for (int i = 0; i < count; i++)
        {
            petNames[i] = EnterString($"Введите кличку питомца {i + 1}: ");
        }
        return petNames;
    }

    static string[] GetFavoriteColors(int count)
    {
        string[] favoriteColors = new string[count];
        for (int i = 0; i < count; i++)
        {
            favoriteColors[i] = EnterString($"Введите любимый цвет {i + 1}: ");
        }
        return favoriteColors;
    }

    static void ShowUserInfo((string Name, string Surname, int Age, string[] PetNames, string[] FavoriteColors) userData)
    {
        Console.WriteLine(userData.Name);
        Console.WriteLine(userData.Surname);
        Console.WriteLine(userData.Age);

        if (userData.PetNames.Length > 0)
        {
            Console.WriteLine("Питомцы:");
            foreach (var petName in userData.PetNames)
            {
                Console.WriteLine(petName);
            }
        }
        else
        {
            Console.WriteLine("Питомцев нет.");
        }

        Console.WriteLine("Любимые цвета:");
        foreach (var color in userData.FavoriteColors)
        {
            Console.WriteLine(color);
        }
    }
}