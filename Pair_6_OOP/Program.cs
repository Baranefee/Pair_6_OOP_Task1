// See https://aka.ms/new-console-template for more information


CustomerManager customerManager = new CustomerManager(new Customer(),new MilitaryCreditManager() );
customerManager.GiveCredit();


class CreditManager
{

    public void Calculate()
    {
        Console.WriteLine("Hesaplandi");
    }

    public void Save()
    {
        Console.WriteLine("Kredi Verildi");
    }
}

interface ICreditManager
{
    void Calculate();
    void Save();
}

abstract class BaseCreditManager : ICreditManager
{
    public abstract void Calculate();

    public virtual void Save()
    {
        Console.WriteLine("kaydedildi");
    }
}

class TeacherCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Öğretmen kredısı hesaplandı");
    }

    public override void Save()
    {
        base.Save();
    }
}

class MilitaryCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Asker kredısı hesaplandı");
    }


}


class Customer
{
    public Customer()
    {
        Console.WriteLine("Musteri esnesi baslatildi");
    }

    public int Id { get; set; }

    public string City { get; set; }
}

class Company:Customer
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
}


class Person:Customer
{
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string NationalIdentity { get; set; }
}

class CustomerManager
{
    private Customer _customer;
    private ICreditManager _creditManager;
    public CustomerManager(Customer customer, ICreditManager creditManager)
    {
        _customer = customer;
        _creditManager = creditManager;

    }
    public void Save()
    {
        Console.WriteLine("Musteri Kaydedildi " );
    }

    public void Delete()
    {
        Console.WriteLine("Musteri Silindi ");
    }

    public void GiveCredit()
    {
        _creditManager.Calculate();
        Console.WriteLine("Kredi Verildi");
    }

}