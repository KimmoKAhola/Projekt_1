# Project 1 .NET 2024 Case
## Del 1 – Shapes
Användaren ska kunna mata in en form och area och omkrets ska räknas fram. Dessa former ska finnas att välja bland när appen startas:
-   Rektangel
- 	Parallellogram
- 	Triangel
-   Romb 
## Krav
- Seeda fram ett resultat och spara till databasen (en för varje form)
-	Det ska vara möjligt att använda CRUD operationer på dessa beräkningar.  
-	All relevant information inklusive Datum då beräkningen gjordes ska sparas till databasen
- Användaren ska få möjlighet att göra en ny beräkning eller returneras till huvudmenyn efter beräkningen har redovisats.

### Ändringar jag har gjort (med kundens godkännande)
Area och omkrets sparas inte till databasen utan dessa räknas ut vid behov då användaren väljer att visa alla uträkningar. Denna ändring gjordes för att uppfylla 3NF, dvs att om en kolumn ändras ska detta inte påverka någon annan kolumn. Om vi låter Area om Omkrets vara en del av tabellen bryter vi mot detta eftersom både Area och Omkrets är en funktion av bredd och höjd. Om vi då ändrar på bredd eller höjd måste vi även uppdatera andra kolumner. I Del 2 - miniräknaren sparades dock svaret i en egen kolumn, trots att det bryter mot 3NF, då detta var en explicit formulering i specen.
Jag gör också antagandet att trianglarna är liksidiga och att ingen felhantering behövs för att kontrollera att formerna i sig är verkliga (alltså att den ska gå att rita på riktigt).

## Del 2 - Miniräknare
Användaren ska kunna mata in två tal och sedan bestämmer vilken operator ska användas. 
-  Addition 
-  Subtraktion
-  Multiplikation
-  Division
-  Roten ur
-  Modulus
## Krav
- Svaren ska redovisas på ett korrekt sätt med 2 decimaler vid behov. 
-	Samtliga egenskaper ska sparas ner i en ny separat tabell fast till samma databas som ’Del 1 Shapes’. 
-	Tal1, Tal2, Operator, resultatet och datum då beräkningen gjordes ska sparas i databasen.
-	Menyn ska finnas i en loop som upprepas tills användaren säger att hen vill lämna appen.
-	Det ska vara möjligt att använda samtliga CRUD operationer på dessa beräkningar.
-	Användaren ska få möjlighet att göra en ny beräkning eller returneras till huvudmenyn efter beräkningen har redovisats.

### Ändringar jag har gjort (med kundens godkännande)
Först och främst har jag vänt på specen och gjort så att användaren väljer operator först och sedan matar in två tal. Ordningen ändrades för att det skulle stämma överens med Del 1:s inmatning.
För operatorn √ har jag istället för att räkna ut kvadratroten låtit användaren istället välja valfri rot enligt. Tal 2 i inmatningen är då den rot användaren väljer.
Exempel: 10 2 motsvarar kvadratroten av 10 och 10 3 motsvarar kubikroten av 10. Det är även möjligt att beräkna en rot som inte är ett heltal, tex 10 3,25. Det bör dock nämnas att pga specens krav om att svaret ska sparas med 2 decimaler blir felmarginalen stor vid högre tal.

## Del 3 - Sten, Sax, Påse
Användaren ska kunna spela Sten, Sax, Påse mot datorn. 
- Resultatet (Vinst, förlust, oavgjort), datum då spelet ägde rum och genomsnittet av hur många gånger du har vunnit mot datorn (genomsnittet av samtliga spel som någonsin har spelats) ska sparas i en ny tabell i samma databas som de andra två tidigare uppgifter.
-	Det behövs ingen CRUD funktionalitet på denna del men användaren ska kunna välja att se en lista (R) över alla tidigare spel. Spelarens drag, datorns drag, om det var en vinst eller förlust och datumet då spelet ägde rum.

# Designval för projektet
Hela projektet har lösts på ett objektorienterat sätt. För att underlätta kodningsprocessen har jag valt att endast ha menyer, autofac samt interfaces som hör till dessa i själva huvudprojektet. Alla andra klasser har lagts i separata bibliotek för att programmet ska bli mer modulärt och uppstyrt. Beräkningarna för miniräknaren och formerna har lagts i samma bibliotek då dessa har mycket gemensamt. Jag har valt att hålla samtliga tabeller skilda från varandra då de inte har någon logisk koppling till varandra. Mer om detta val står i dagboken.

## Kort om Calculations library
Mitt library för beräkningarna består av miniräknaren och formerna. Båda delarna har varsitt interface samt varsin Context-klass då jag har använt mig av strategy pattern för båda delarna. Jag har här valt att göra båda interfacen (IShape, IMath) nullable då jag har valt att inte skicka in en default strategy in i mina menyer - denna strategi väljs helt och hållet av kunden under körning.

## Kort om Rock, paper, scissors library
Mitt library för sten, sax, påse har även det lagt i ett separat bibliotek för att göra programmet modulärt. Spelet består av 3 klasser och 2 enums (gamestate och player moves) där klasserna består av en logikklass för reglerna, en klass för att få spelarnas drag samt en klass för varje "match" av sten, sax, påse. Spelarnas drag injiceras in i konstruktorn för varje match. Varje ny match är ett nytt objekt av sten, sax, påse.
En klass, som jag har valt att kalla för high score, har information om spelarens samlade matcher. Då det bara finns en spelare innehåller denna tabell endast en rad men här finns utrymme för utökning samt koppling till Sten, sax, påse-tabellen om man vill koppla varje match till ett spelar-id i framtiden.

## Kort om UserInputValidation Library
Här har jag tagit biblioteket från förra kursen och jag har i princip all min felhantering här inne. Här har jag även valt att samla olika metoder för att printa meddelanden till användaren i relevanta färger: grön, röd eller gul beroende på vilket resultat som har skett.

## Kort om Database Library
Här har jag valt att samla allt om databasen, dvs min context, seeding, migrations, databasmodeller samt logiken för vad och hur saker ska sparas till databasen. Jag har här använt mig av ett nytt pattern när jag har designat: repository pattern. Här är två länkar med information om detta pattern: 
- https://deviq.com/design-patterns/repository-pattern
- https://www.youtube.com/watch?v=x6C20zhZHw8

Anledningen till att jag har valt mig av detta pattern är för att abstrahera databasen från logiken. Styrkan med detta designval är att om jag väljer att byta databas behöver jag endast göra ändringar i mina repositories. Värt att nämna är att Entity Framework redan implementerar repository pattern men enligt diskussioner på nätet verkar det vara värt att implementera en egen variant av detta pattern oavsett. Alla entiteter som sparas till databasen har sin egna klass i mappen "Repositories". Logiken för varje entitet finns i varsin klass i mappen "Services". 

Interfaces som har använts här är ett generiskt interface, IRepository, för alla klasser som kräver CRUD-funktionalitet. Detta interface ärver även från ett annat interface IEntity som innehåller relevant information för CRUD: datum när entiten har skapats samt datum för när den har uppdaterats. Jag har här valt att inte implementera något interface för Sten, sax, påse eller high score då dessa inte kräver CRUD.

