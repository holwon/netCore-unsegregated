

Person person = new("Nancy", "Davolio");
Console.WriteLine(person);
// output: Person { FirstName = Nancy, LastName = Davolio }

public record Person(string FirstName, string LastName);