using System;

class Project
{

    public static void Main()
    {
        PersonConverter personConverter = new PersonConverter();

        Person person = new Person()
        {
            FirstName = "Travis",
            LastName = "Findley",
            Salary = 100000,
            BirthDate = DateTime.Parse("06-22-2007 09:09:09"),
            Converter = personConverter
        };

        Console.WriteLine(person);

    }

}

record Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age {
        get
        { 
            int age = DateTime.Now.Year - BirthDate.Year;

            if (DateTime.Now < BirthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }

    }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }

    public IMultiValueConverter Converter { get; set; }

    public override string ToString()
    {
        if (Converter == null)
        {
            return "ERROR";
        }
        return Converter.Converter(this);
    }
}

class PersonConverter : IMultiValueConverter
{
    public string Converter(Person input)
    {
        return $"{input.LastName}, {input.FirstName} (Age: {input.Age}, Salary: {input.Salary}, Birth Date: {input.BirthDate}";
    }
}

interface IMultiValueConverter
{
    public string Converter(Person input);
}

// "LastName, FirstName (Age: Age, Salary: Salary, Birth Date: BirthDate)".