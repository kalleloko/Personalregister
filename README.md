# C# Övning 1 - Personalregister

Inlämning till uppgift 1 i Lexicon .NET 2025 HT.

## Instruktioner

### Bakgrund
Ett litet företag i restaurangbranschen kontaktar dig för att utveckla ett litet personalregister. De har endast två krav:
1. Registret skall kunna ta emot och lagra anställda med namn och lön. (via inmatning i konsolen, inget krav på persistent lagring)
2. Programmet skall kunna skriva ut registret i en konsol.

### Uppgift 1
Vilka klasser bör ingå i programmet?

### Uppgift 2
Vilka attribut och metoder bör ingå i dessa klasser?

### Uppgift 3
Skriv programmet

Försök göra programmet så robust och framtidssäkert som möjligt!
Ni får gärna lägga på extra funktionalitet!
Bonus för att implementera test! (men inte på bekostnad av att den andra koden blir lidande)
Koden ska ligga uppe på GIT absolut senast 17.00. Lycka till!

## Svar

### Uppgift 1
Program - sköter inmatning och utskrift
Employee - representerar en person i registret
EmployeeRegister - representerar listan på personer

### Uppgift 2
En första outline (innan någon kod skrivits!)

**Program**
- void Main()
- hjälpmetoder för inmatning

**Employee**
- string name
- float salary
- string ToString()

**EmployeeRegister**
- Employee[] employees
- void AddEmployee(Employee)
- void AddEmployee(string name, float salary)
- string ToString()

### Uppgift 3
Se kod
