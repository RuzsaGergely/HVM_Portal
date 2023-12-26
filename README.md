# HVM Portal

A HVM Portal a képzeletbeli Hungária Villamos Művek lakossági és üzleti villanyóra-követő rendszere, mely segítségével a felhasználók villanyóraállásokat rögzíthetnek, illetve a rögzítések nyomán információkat kérhetnek le webes illetve Android platformon is.

## Alapadatok

| Adat          | Érték                                 |
| --------      | -------                               |
| Intézmény     | BMSZC Petrik Lajos                    |
| Osztály       | 2/14. SL                              |
| Tanév         | 2023/24.                              |
| Fejlesztette  | Ruzsa Gergely Gábor, Bittner István   |

## Felhasznált technológiák

| Technológia   | Érték                                             |
| --------      | -------                                           |
| Backend       | ASP.NET Web Core API (8) + Entity Framework 8     |
| Frontend      | Angular - TypeScript nyelven - >= v17             |
| Adatbázis     | Microsoft SQL Express                             |
| Android       | Vanilla - JS nyelven                              |

**Fejlesztési elvek:**

- Object Oriented Programming (OOP)
- Domain Driven Design (DDD)
- Command and Query Responsibility Segregation pattern (CQRS)

## Mappaszerkezet

```plain
.
├── HVM_Backend/
│   └── ASP.NET Core Web API projekt
├── HVM_Frontend/
│   └── Angular TS projekt
├── HVM_Android/
│   └── Android Gradle (Java) projekt
├── Manual/
│   ├── Felhasználói és adminisztrátori kézikönyv (Markdown)
│   └── Tesztelési jegyzék (Markdown)
└── README
```
