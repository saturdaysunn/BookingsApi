# Buggy Bookings API

Ett minimalt REST‑API för konferensrums­bokningar. **Uppdraget** är att

1. fixa två buggar,
2. implementera DELETE,
3. refaktorera för korrekt Dependency Injection och DRY‑principen.

---

## Katalogstruktur

```
BookingsApi/
├── API/                 # .NET 8 webb‑API‑projekt
│   ├── Controllers/
│   ├── Models/
│   ├── Repositories/
│   ├── Services/
│   └── Program.cs
└── Tests/               # xUnit‑projekt
```

## Kom igång

```bash
# Återställ paket
dotnet restore

# Bygg och starta API-projektet
dotnet run --project API

# Kör tester
dotnet test
```

När API:t startar visas en URL (oftast `https://localhost:5001`).

```bash
curl -k https://localhost:5001/api/bookings      # GET alla bokningar
curl -k https://localhost:5001/api/bookings/42   # GET bokning 42
```

---

## Dina uppgifter

1. **Bug #1 – dubbelbokning**  
   Tidsöverlapp accepteras ibland. Hitta roten och åtgärda så att testet _CreateBooking_RejectsOverlap2_ passerar.

2. **Bug #2 – DI‑kringgås**  
   `BookingController` instansierar `BookingService` direkt. Flytta till DI‑containern så att beroenden injiceras.

3. **Ny funktion – avboka**  
   Implementera `DELETE /api/bookings/{id}` med

   - 204 No Content på lyckad avbokning
   - 404 om id saknas.

4. **Refaktorera**
   - Inför `IBookingService`, `IBookingRepository`.
   - All överlappslogik ska finnas på **ett** ställe.

---

## Inlämning

- Zip eller git‑push av hela **BookingsApi**‑mappen.
- Lägg till en kort README‑sektion (≤ 10 rader) där du beskriver hur du tänkt kring DI & DRY.

Lycka till!
