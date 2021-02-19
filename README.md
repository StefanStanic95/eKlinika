# eKlinika

eKlinika je informacijski sistem koji dozvoljava evidentiranje uputnica, pregleda, dijagnoza, uplatnica, lijeka te ostalih podataka potrebnih za digitalizovanje poslovnih procesa jedne klinike.

eKlinika podržava više korisničkih uloga, te za svaku ulogu postoje pristupni podaci namijenjeni za testiranje funkcionalnosti.  
Ovisno o ulozi prijavljenog korisnika, na desktop aplikaciji će biti dostupne razlicite funkcionalnosti odobrene za koristenje od strane te uloge.

## Pristupnci podaci

### Windows Forms Desktop aplikacija

Username: admin  
Password: test

Username: doktor  
Password: test

Username: medsestra  
Password: test

Username: apotekar  
Password: test

Username: referent  
Password: test

### Xamarin Crossplatform aplikacija 

Username: pacijent  
Password: test

## Konfiguracija okruženja za rad aplikacije

1. Run `git clone https://github.com/StefanStanic95/eKlinika.git`
2. U glavnom folderu pokrenuti komandu `docker-compose up`
3. Nakon downloada svakog image-a, pokrenut će se API i SQL server docker container, ali je očekivano da API container daje error u vezi spajanja na database.
4. Logirati se na SQL server preko adrese `localhost,1401` i `SQL Server Authentication` koristeći Login `sa` i Password `eKlinika123!`
5. Uraditi import SQL skripte `eKlinika_skripta.sql` prilikom čega će se kreirati baza podatka sa testnim podacima
6. Po potrebi, restartati container `eklinika-api` ukoliko se nije uspješno upalio u kraćem roku
5. Testirati Windows Forms aplikaciju, Xamarin ili API po želji

## Testiranje online payment sistema

Ovaj projekat koristi Stripe TEST mode integraciju, te je online kupovinu moguće vršiti uz pomoć sljedećih podataka:

Card number: `4242 4242 4242 4242`  
Security code: _(bilo koji 3-cifreni)_ 
Expiration date: _(bilo koji mjesec i godina u budućnosti)_
