# CoffeeShopASP
Project for ASP, Store which sells coffees

Projekat se odnosi na prodavnicu "Coffee Shop". Glavni cilj jeste prodaja kafe. Svaka kafa ima tip zrna i iz koje zemlje potiče. Takođe, svaka kafa ima svoju količinu pakovanja
i u zavisnosti od količine pakovanja, svoju cenu. Određene kafe imaju samo jedno pakovanje sa određenom količinom, dok druge mogu imati vise pakovanja sa većom ili manjom količinom.
Svaki korisnik, koji nije autorizovan, ima mogućnost registracije kao i log in-a, zatim ima prikaz svih tipova zrna kafe, sa imenima kafa i njihovim opisima, kao i prikaz zemalja
iz kojih kafe mogu da potiču, dostupne količine pakovanja i uz sve to se prikazuju kafe koje pripadaju određenim tipovima zrna kafe ili zemlje porekla ili količine pakovanja.
Postoji mogućnost pretrage količine pakovanja, tako što korisnik ima mogućnost da vrši pretragu preko minimalne i maksimalne količine koju pretražuje, zatim pretraga zemalja iz kojih
kafe mogu da potiču i u zavisnosti od imena zemlje koje korisnik pretražuje, korisniku se prikazuju kafe uz svoja imena i opise. Isto je i za tip zrna kafe. Korisnik unosom imena
određenog zrna, prikazuje sve kafe koje su tipa tog zrna. Korisnik može da vrši i pretragu samih kafa po njihovom imenu, gde za svaku kafu može videti dostupne količine pakovanja
za tu kafu, kao i cenu u zavisnosti od količine pakovanja i kafe.

Autorizovan korisnik ima sve mogućnosti kao i neautorizovan korisnik, s tim što ima mogućnost poručivanja određene kafe, za šta je potrebno uneti adresu i stavke porudžbine.
U stavke porudžbine potrebno je uneti ID kafe, ID količine pakovanja, kao i koliko komada želi da poruči. Vrši se provera da li postoji taj proizvod i da li odgovara količina
pakovanja.

Administrator ima sve mogućnosti kao i autorizovan korisnik. Pored tih mogućnosti, admin ima mogućnost unosa novih tipova zrna, zemlje porekla, za šta je potreban samo Name, zatim
količinu pakovanja, kao i kafe sa cenama. Takođe, ima mogućnost izmene, kao i brisanje svega navedenog u zavisnosti od ID koji admin odabere. Administrator ima mogućnost prikaza 
svih porudžbina, kao i UseCaseLogova. Moguća je pretraga porudžbina, preko imena poručenih kafa, kao i UseCaseLogova preko imena UseCase-a.
