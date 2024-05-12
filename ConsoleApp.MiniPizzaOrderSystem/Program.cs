using System;
using System.Collections.Generic;

List<Pizza> pizzaMenu = new List<Pizza>()
            {
                new Pizza("1. Margherita", 8.99),
                new Pizza("2. Pepperoni", 9.99),
                new Pizza("3. Vegetarian", 10.99),
                new Pizza("4. Hawaiian", 11.99)
            };

result:

Console.WriteLine("Welcome to Pizza Hut!");
Console.WriteLine("Here is our menu:");
Console.WriteLine("===================");
foreach (var pizza in pizzaMenu)
{
    Console.WriteLine($"{pizza.Name} - ${pizza.Price}");
}

Console.WriteLine("\nPlease select a pizza by entering its number:");
int choice;
while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > pizzaMenu.Count)
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}

Pizza selectedPizza = pizzaMenu[choice - 1];

Console.WriteLine($"\nYou have selected: {selectedPizza.Name}");
Console.WriteLine($"Price: ${selectedPizza.Price}");

Console.WriteLine("\nDo you want to add any extras? (Y/N)");
string addExtras = Console.ReadLine().Trim().ToUpper();
if (addExtras == "Y")
{
    AddExtras(selectedPizza);
}

double totalPrice = selectedPizza.Price;
foreach (var extra in selectedPizza.Extras)
{
    totalPrice += extra.Price;
}

string invoiceNumber = GenerateInvoiceNumber();

Console.WriteLine("\nYour invoice:");
Console.WriteLine($"Invoice No: {invoiceNumber}");
Console.WriteLine($"Pizza: {selectedPizza.Name}");
foreach (var extra in selectedPizza.Extras)
{
    Console.WriteLine($"Extra: {extra.Name} - ${extra.Price}");
}
Console.WriteLine($"Total Price: ${totalPrice}");

Console.WriteLine("\nThank you for your order! Enjoy your pizza!");
Console.WriteLine("----------------------------------------------");
Console.WriteLine("");
Console.WriteLine("");
goto result;

void AddExtras(Pizza pizza)
{
    List<Extra> availableExtras = new List<Extra>()
            {
                new Extra("1. Cheese", 1.00),
                new Extra("2. Mushrooms", 0.75),
                new Extra("3. Onions", 0.50),
                new Extra("4. Peppers", 0.75)
            };

    Console.WriteLine("\nAvailable extras:");
    foreach (var extra in availableExtras)
    {
        Console.WriteLine($"{extra.Name} - ${extra.Price}");
    }

    Console.WriteLine("\nPlease select extras by entering their numbers (separated by commas):");
    string[] extraChoices = Console.ReadLine().Split(',');

    foreach (string choice in extraChoices)
    {
        int index;
        if (int.TryParse(choice, out index) && index >= 1 && index <= availableExtras.Count)
        {
            pizza.Extras.Add(availableExtras[index - 1]);
        }
    }
}

string GenerateInvoiceNumber()
{
    DateTime now = DateTime.Now;
    string invoiceNumber = $"{now:yyyyMMddHHmmss}";
    return invoiceNumber;
}