// Design Pattern
// 3 ana kategorisi var
// Yaratımsal (Creational)
// Yapısal (Structural)
// Davranışsal (Behavioral)


// Creational Patterns (Yaratımsal Tasarım Kalıpları)
// 1. Sigleton Pattern

using System.Diagnostics.Contracts;

public class Sigleton
{
    private static Sigleton _instance;
    private Sigleton()
    {
        
    }

    public static Sigleton GetInstance()
    {
        _instance = new Sigleton();
        return _instance;
    }
}
// Kullanım alanları (instance sadece bir tane üretilir)
// Log Sınıfları
// Database Bağlantı Sınıfları

// Factory Pattern
// Sınıf nesne yaratma sorumluluğunu kendine almaz bu işi bir Factory sınıfına devreder.

public abstract class Product
{
    public abstract string GetName();
}

public class ConcreteProductA : Product
{
	public override string GetName()
	{
        return "Product A";
	}
}

public class ConcreteProductB : Product
{
	public override string GetName()
	{
        return "Product B";
	}
}

public class ProductFactory
{
    public static Product CreateProduct(string type)
    {
        if (type == "A")
        {
            return new ConcreteProductA();
        }
        else if (type == "B")
        {
			return new ConcreteProductB();
		}
        else
        {
            throw new ArgumentException("Invalid Type");
        }
    }
}

// Structural Patterns (Yapısal Tasarım Kalıpları)
// Nesneler arasındaki ilişkileri düzenler ve bu ilişkileri yapılandırır.


// 1. Adapter Pattern
// Bir interface in mevcut bir sınıfın interface i ile uyumlu hale gelmesi sağlanır

interface ITarget
{
    void Request();
}

class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific Request");
    }
}

class Adapter : ITarget
{
    private Adaptee adaptee = new();
	public void Request()
	{
		adaptee.SpecificRequest();
	}
}

// 2. Decorator Pattern
// Bir nesnesnin davrabışlarıbı değiştirmeden ona yeni sorumluluklar yükler.

public abstract class Beverage
{
    public abstract string GetDescription();
}

class Coffee : Beverage
{
	public override string GetDescription()
	{
        return "Coffee";
	}
}

public abstract class BeverageDecorator : Beverage
{
    protected readonly Beverage _beverage;
    protected BeverageDecorator(Beverage beverage)
	{
		_beverage = beverage;
	}
}

public class MilkDecarator : BeverageDecorator
{
    public MilkDecarator(Beverage beverage) : base(beverage)  
    {
        
    }
	public override string GetDescription()
	{
		return _beverage.GetDescription() + "Milk";
	}
}

// Behavioral Patterns(Davranışsal Tasarım Kalıpları)
// Davranışsal kalıplar, nesneler arasındaki iletişimi ve sorumlulukları tanımlar.


// 1. Observer Pattern
// Bir nesnenin durumundaki değişiklikleri ona bağlı olan diğer nesnelere otomatik olarak bildirilmesini sağlar.

interface IObserver
{
    void Update(string Message);
}

class ConcreteObserver : IObserver
{
	private readonly string _name;

	public ConcreteObserver(string name)
    {
		_name = name;
	}
    public void Update(string Message)
	{
        Console.WriteLine(_name + " received: " + Message);
	}
}

class Subject
{
    private List<IObserver> _observers = new();

    public void Atach(IObserver observer)
    {
        _observers.Add(observer);
    }

    void Notify(string message)
    {
        foreach (var item in _observers)
        {
            item.Update(message);
        }
    }
}

// 3. Command Pattern

// Bir isteği nesneye sarmalayarak parametrize eder ve isteğin çağrıldığı yeri, zamanı ve şeklini kontrol etmeyi sağlar

interface ICommand
{
    void Execute();
}

class LightOnCommand : ICommand
{
	public void Execute()
	{
        Console.WriteLine("Light is on");
	}
}

class LightOffCommand : ICommand
{
	public void Execute()
	{
        Console.WriteLine("Light is off");
	}
}

class RemoteControl
{
    private ICommand _command;
    void SetCommand(ICommand command)
    {
        _command = command;
    }

    void PressButton()
    {
        _command.Execute();
    }
}