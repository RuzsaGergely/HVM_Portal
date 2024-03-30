# HVM Portal

A HVM Portal a képzeletbeli Hungária Villamos Művek lakossági és üzleti villanyóra-követő rendszere, mely segítségével a felhasználók villanyóraállásokat rögzíthetnek, illetve a rögzítések nyomán információkat kérhetnek le webes illetve Android platformon is.

## Alapadatok

| Kulcs         | Érték                                 |
| --------      | -------                               |
| Intézmény     | BMSZC Petrik Lajos                    |
| Osztály       | 2/14. SL                              |
| Tanév         | 2023/24.                              |
| Fejlesztette  | Ruzsa Gergely Gábor, Bittner István   |

## Felhasznált technológiák

| Típus         | Megnevezése                                       |
| --------      | -------                                           |
| Backend       | ASP.NET Web Core API (8) + Entity Framework 8     |
| Frontend      | Angular - TypeScript nyelven - >= v17 + PrimeNG   |
| Adatbázis     | Microsoft SQL Express                             |
| Android       | Vanilla - Java nyelven                            |

**Fejlesztési elvek:**

- Object Oriented Programming (OOP)
- ~ Domain Driven Design (DDD)

## Mappaszerkezet

```plain
.
├── HVM-Backend/
│   └── ASP.NET Core Web API projekt
├── HVM-Frontend/
│   └── Angular TS projekt
├── HVM-Android/
│   └── Android Gradle (Java) projekt
├── Docs/
│   ├── Felhasználói és adminisztrátori kézikönyv (Markdown)
│   └── Tesztelési jegyzék (Markdown)
└── README
```
