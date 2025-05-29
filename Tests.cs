using Lab;

class Tests
{
    public static void RunAll()
    {
        Console.WriteLine("Запуск тестов класса Money...");
        TestConstructorAndToString();
        TestAddKopeks();
        TestUnaryOperators();
        TestTypeConversions();
        TestBinaryOperatorsWithUInt();
        TestExceptionHandling();
        Console.WriteLine("Все тесты завершены.");
    }

    private static void TestConstructorAndToString()
    {
        Console.WriteLine("Тест конструктора и ToString():");
        Money m1 = new Money(10, 50);
        Money m2 = new Money();
        Console.WriteLine($"m1: {m1.Rubles}"); 
        Console.WriteLine($"m2: {m2}"); 
        Console.WriteLine();
    }

    private static void TestAddKopeks()
    {
        Console.WriteLine("Тест AddKopeks:");
        Money m1 = new Money(10, 50);
        Money m2 = m1.AddKopeks(125); 
        Console.WriteLine($"m1 + 125 копеек = {m2}"); 
        Console.WriteLine();
    }

    private static void TestUnaryOperators()
    {
        Console.WriteLine("Тест унарных операторов ++ и --:");
        Money m = new Money(10, 50);
        Console.WriteLine($"Исходное: {m}");
        m++;
        Console.WriteLine($"После ++: {m}"); 
        m--;
        Console.WriteLine($"После --: {m}"); 
        Console.WriteLine();
    }

    private static void TestTypeConversions()
    {
        Console.WriteLine("Тест операций приведения типов:");
        Money m = new Money(10, 50);
        uint rubles = (uint)m; 
        Console.WriteLine($"Явное приведение к uint (рубли): {rubles}"); 
        double totalRubles = m; 
        Console.WriteLine($"Неявное приведение к double (рубли с копейками): {totalRubles}"); 
        Console.WriteLine();
    }

    private static void TestBinaryOperatorsWithUInt()
    {
        Console.WriteLine("Тест бинарных операций с uint:");
        Money m = new Money(10, 50);
        Money addResult = m + 125; 
        Console.WriteLine($"m + 125 копеек = {addResult}"); 
        Money subtractResult = m - 50; 
        Console.WriteLine($"m - 50 копеек = {subtractResult}"); 
        Console.WriteLine();
    }

    private static void TestExceptionHandling()
    {
        Console.WriteLine("Тест обработки исключений:");

        try
        {
            Money invalid = new Money(1, 150);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Поймано исключение при создании: {ex.Message}");
        }

        try
        {
            Money m = new Money(0, 10);
            Money result = m - 20; 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Поймано исключение при вычитании: {ex.Message}");
        }

        Console.WriteLine();
    }
}
