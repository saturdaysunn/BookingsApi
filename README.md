# Buggy-Bookings
När det gäller DI valde jag att använda BookingController konstruktorn för att injecera instansen av BookingService. 
Jag registrerade även BookingService och BookingRepository (som BookingService beror på), samt respektive interface, som 
Scroped tjänster i DI-containern så att samma instanser av tjänsterna används mellan klasserna under varje enskild HTTP request. 

När det gäller DRY valde jag att ta bort HasOverlap kontrollen från BookingController eftersom denna kontrollen redan
implementeras i BookingService, som ansvarar för business logiken. BookingController ansvarar nu exklusivt för HTTP kommunikation 
och fångar istället en InvalidOperationException samt returnerar ett Conflict() svar ifall en ny bokning överlappar med en befintlig. 