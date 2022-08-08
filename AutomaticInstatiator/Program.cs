using AutomaticInstatiator;

foreach (var item in new Instantiator().CreateInstances())
{
    item.Hello();
}

Console.ReadLine();