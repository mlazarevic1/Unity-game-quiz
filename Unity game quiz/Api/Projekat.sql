CREATE DATABASE Kviz;
GO

CREATE TABLE player (
    playerID int IDENTITY PRIMARY KEY NOT NULL,
    username varchar(50) NOT NULL UNIQUE,
    password nvarchar(200),
	brojBodova int NOT NULL DEFAULT 0
    
);

GO;

CREATE TABLE question (
    pitanjeID int IDENTITY PRIMARY KEY NOT NULL,
    pitanje varchar(300) NOT NULL,
    level varchar(15) NOT NULL,
	iskorisceno bit DEFAULT 0 
	
);

CREATE TABLE answer(
	odgovorID int IDENTITY PRIMARY KEY NOT NULL,
    pitanjeID int NOT NULL CONSTRAINT FK_pitanjeID FOREIGN KEY(pitanjeID) REFERENCES question(pitanjeID),
	odgovor varchar(300),
	tacnost bit
);
GO


--Proc za level=1

ALTER PROC dbo.IzlistajPitanja
AS
SET LOCK_TIMEOUT 3000;
SELECT pitanjeID, pitanje, level, iskorisceno
FROM question
ORDER BY NEWID()
GO


------------Proc za izlacenje odgovora---------------------------------

ALTER PROC dbo.OdgovorZaPitanje
AS
SET LOCK_TIMEOUT 3000;
SELECT odgovor, pitanjeID, pitanjeID,  tacnost
FROM answer 
ORDER BY NEWID()
GO
--




INSERT INTO question(pitanje, level)
VALUES('U programskom jeziku C# umesto getter/setter metoda u klasama se definišu:', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Potrebno je da polje x neke klase može da ima celobrojnu vrednost ili null. Ovo polje treba definisati na sledeći način:', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Sta radi System.Out("hello world")?', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('U Windows Forms aplikaciji za definisanje prozora koristi se klasa:', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Metodu OnFinished je moguće pretplati na događaj Finished objekta na koji ukazuje referenca alg?', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Za brzo citanje redova jedan po jedan iz rezultata dobijenog izvršenjem komande na SQL serveru koristi se objekat ADO.NET klase:', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih iskaza u vezi sa konverzijom je tačan?', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Klasa B nasleđuje klasu A. Da bi se ostvario polimorfizam metoda doIt u klasama A i B može da ima sledeci potpis:', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih metoda je pocetna tacka u programskom jeziku c# u konzolnoj aplikaciji', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih su tipovi vrednosti u C #?', 'easy');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji se od sledecih tipova podataka može koristiti sa enumom?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('String je ___________?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Svi nizovi startuju sa pozicije ___________?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od ponudjenih odgovora je korektan za deklaraciju niza u c#', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Tip podataka promenljive deklarisane sa using', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih tipova izbegava proveru tipa tokom kompajliranja; umesto toga, on rešava tip u vreme izvodjenja?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih tipova podataka treba koristiti za monetarnu vrednost?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Sta je od navedenog podrazumevani modifikator pristupa clanova klase?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Koja je od sledecih izjava niza validna?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Koja je od sledecih tvrdnji istinita?', 'medium');
GO

INSERT INTO question(pitanje, level)
VALUES('Sta od navedenog nije podrzano u C #?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Koja je od sledecih tvrdnji nije tacna', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Koja od sledecih kljucnih reci se koristi da ukaze na to da polje moze modifikovati više niti koje se izvrsavaju istovremeno?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Asinhroni metod moze imati koji od sledecih povratnih tipova?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih operatora ne izuzima izuzetak ako "cast" ne uspe?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Sta se od navedenog naziva i statickim polimorfizmom?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Sta je od navedenog tacno o C # strukturama u odnosu na C # klase?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji operater poziva konstruktor klase?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Koje od sledecih generickih ogranicenja ogranicava parametar generickog tipa na objekat klase koji implementira IEnumerable interfejs?', 'hard');
GO

INSERT INTO question(pitanje, level)
VALUES('Koji od sledecih tipova moze ucestvovati u nasledjivanju u C #?', 'hard');
GO



SELECT * FROM question

--prvo pitanje
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(1, 'Svojstva', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(1, 'Delegati', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(1, 'Polja', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(1, 'indekseri', 0);
GO

--drugo pitanje
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(2, 'private int? x', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(2, 'private int x', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(2, 'private nullable int x', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(2, 'Ovako nešto nije moguće', 0);
GO

--trece pitanje

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(3, 'Ispisuje hello world', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(3, 'ne postoji ta komanda', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(3, 'restartuje aplikaciju', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(3, 'dadaje instancu klase', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(4, 'Window', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(4, 'WindowForm', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(4, 'WinForm', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(4, 'Form', 1);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(5, 'alg.Finished.register(OnFinished)', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(5, 'alg.Finished = OnFinished;', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(5, 'alg.Finished += OnFinished;', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(5, 'alg.Finished(OnFinished);', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(6, 'SqlDataReader', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(6, 'DataSet', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(6, 'SqlConnection', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(6, 'SqlCommand', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(7, 'Moguće je definisati i implicitnu i eksplicitnu konverziju', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(7, 'Moguće je definisati samo implicitnu konverziju', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(7, 'Moguće je definisati samo eksplicitnu konverziju', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(7, 'Nije moguće definisati konverziju u C#-u', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(8, 'Klasa A: public void doIt() Klasa B: public void doIt()', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(8, 'Klasa A: public virtual void doIt() Klasa B: public void doIt()', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(8, 'Klasa A: public void doIt() Klasa B: public override void doIt()', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(8, 'Klasa A: public virtual void doIt() Klasa B: public override void doIt()', 1);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(9, 'public static void Program()', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(9, 'public static void Main', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(9, 'public static void main', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(9, 'Nijedan od ponudjenih', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(10, 'Int32', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(10, 'Double', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(10, 'Decimal', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(10, 'Svi ponudjeni', 1);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(11, 'int', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(11, 'string', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(11, 'boolean', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(11, 'Sve ponudjeno', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(12, 'Nepromenljiv', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(12, 'Promenljiv', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(12, 'Static', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(12, 'Vrednosni tip', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(13, '0', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(13, '1', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(13, '-1', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(13, '0.0', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(14, 'int[] intArray = new int[5]', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(14, 'int intArray = new int[5]', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(14, 'int[] intArray = new int[]', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(14, 'int[5] intArray = new int[5]', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(15, 'vreme kompajliranja', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(15, 'Runtime', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(15, 'any time', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(15, 'App init time', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(16, 'dynamic', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(16, 'var', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(16, 'undefined', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(16, 'null', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(17, 'decimal', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(17, 'float', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(17, 'double', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(17, 'long', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(18, 'private', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(18, 'public', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(18, 'Internal', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(18, 'Protected internal', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(19, 'Sve ponudjeno', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(19, 'int[] arr = new int[5]', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(19, 'int[,] arr = new int[5, 2]', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(19, 'int[][,] arr = new int[5][,]', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(20, 'Polje samo za citanje moze se inicijalizovati ili u deklaraciji ili u konstruktoru.', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(20, 'Polje samo za citanje moze se inicijalizovati ili u deklaraciji ili u konstruktoru ili statickim metodama.', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(20, 'Polje samo za citanje moze se inicijalizovati samo u konstruktoru.', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(20, 'Polje samo za citanje moze se pokrenuti samo u deklaraciji.', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(21, 'Sve ponudjeno', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(21, 'Klasa moze naslediti jednu ili vise klasa', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(21, 'Struktura moze naslediti jednu ili vise klasa', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(21, 'Interfejs može naslediti jednu ili više klasa', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(22, 'Nista od ponudjenog', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(22, 'Public clanovi  su uvek dostupni i postaju deo izvedenog objekta klase.', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(22, 'Zasticeni clanovi su dostupni u izvedenoj klasi, ali ne mogu biti deo izvedene klase objekta.', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(22, 'Interni clanovi su dostupni i postaju deo izvedenog objekta klase ako su osnovna klasa i izvedena klasa u istom sklopu.', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(23, 'volatile', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(23, 'unsafe', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(23, 'virtual', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(23, 'extern', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(24, 'void', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(24, 'int', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(24, 'ask<TResult>', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(24, 'Task', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(25, 'as', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(25, 'is', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(25, '()', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(25, '=', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(26, 'Function overloading', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(26, 'Function overriding', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(26, 'Inheritance', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(26, 'Multiple interface inheritance', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(27, 'Sve ponudjeno', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(27, 'Klase su referentni tipovi, a strukture su vrednosni tipovi.', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(27, 'Strukture ne podrzavaju nasledjivanje.', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(27, 'Strukture ne mogu imati podrazumevani konstruktor', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(28, 'new', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(28, '=', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(28, '()', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(28, 'Var', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(29, 'class Processor<T> where T: class:IEnumerable', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(29, 'class Processor<T> T: interface:IEnumerable', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(29, 'class Processor<T> where T: IEnumerable', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(29, 'class Processor<T> where T: new', 0);
GO

INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(30, 'Class, Struct, Interface', 1);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(30, 'Class, Enum, Interface', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(30, 'Class and Struct', 0);
GO
INSERT INTO answer(pitanjeID, odgovor, tacnost)
VALUES(30, 'Sve reference', 0);
GO

SELECT * FROM answer
SELECT * FROM question


--Dodavanje bodova

CREATE PROC dbo.DodajBodove
@username varchar(50),@brojBodova int
AS
IF EXISTS(SELECT * FROM player WHERE username = @username AND  brojBodova < @brojBodova)
		BEGIN
			Update player
			SET brojBodova = @brojBodova
			WHERE username = @username
			RETURN 1
		END
GO

EXEC dbo.DodajBodove 'asdf', 50



--Proc za level=2


SELECT TOP 10 * FROM Sales.Customers
ORDER BY NEWID();
GO


CREATE PROC dbo.IzlistajPitanjaLVLEasy
AS
SET LOCK_TIMEOUT 3000;
SELECT TOP 20 * 
FROM question AS q
INNER JOIN answer AS a
ON q.pitanjeID = a.pitanjeID
WHERE level = 'easy'
ORDER BY NEWID();
GO
--Proc za level=3

ALTER PROC dbo.IzlistajPitanjaLVLEasy
AS
SET LOCK_TIMEOUT 3000;
SELECT TOP 5 pitanje 
FROM question
WHERE level = 'easy'
ORDER BY NEWID();
GO

CREATE PROC dbo.IzlistajPitanjaLVL1
AS
SET LOCK_TIMEOUT 3000;
SELECT TOP 10 * 
FROM question
WHERE level = 3
ORDER BY NEWID();
GO

INSERT INTO player(username, password, brojBodova) 
VALUES('Marko',  N'asfd', null);

--Proc za LeaderBoard

ALTER PROC dbo.LeaderBoard
AS
SET LOCK_TIMEOUT 3000;
SELECT username, brojBodova
FROM player
ORDER BY brojBodova DESC
GO

--Proc za izlistavanje korisnika

CREATE PROC dbo.Korisnik
@playerID int
AS
SET LOCK_TIMEOUT 3000;
SELECT *
FROM player
WHERE playerID = @playerID
GO

--Proc za login

ALTER PROC dbo.Login
@username varchar(50), @password varchar(30) 
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT username FROM player WHERE username=@username AND password = HASHBYTES('SHA2_512', @password))
		BEGIN
			PRINT 'ASD'
			RETURN 1
		END
		ELSE
		BEGIN
			RETURN -4;
		END
END TRY
BEGIN CATCH 
	RETURN ERROR_NUMBER();
END CATCH
GO;

EXEC dbo.Login 'asdf', 'asdf';

--Proc za registraciju


ALTER PROC dbo.Register
@username varchar(50), @password varchar(30), @brojBodova int = 0
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF(LEN(@username) < 4 OR LEN(@username) > 50)
		BEGIN
			RETURN -3;
		END
	ELSE IF(LEN(@password) < 4 OR LEN(@password) > 30)
		BEGIN
			RETURN -2;
		END
	ELSE
		BEGIN
			INSERT INTO player(username, password, brojBodova)
			VALUES(@username, HASHBYTES('SHA2_512', @password), @brojBodova)
			RETURN 0;
		END
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH 
Go;

EXEC dbo.Register 56465, 5655;

SELECT * FROM player;