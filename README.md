# 🧩 ToDoBe Backend (.NET 8)

Backend aplikacji **ToDoBe** – systemu zarządzania zadaniami (To-Do).  
Zbudowany w oparciu o **.NET 8**, **Entity Framework Core**, **PostgreSQL** i **Wolverine**.

---

## ⚙️ Technologie

- **.NET 8**  
- **C# 12**  
- **Entity Framework Core** (ORM)  
- **PostgreSQL** (baza danych)  
- **Wolverine** (asynchroniczne przetwarzanie komunikatów)  
- **MediatR** (wzorzec CQRS)  
- **Mapster** (mapowanie obiektów)  
- **xUnit** (testy jednostkowe)  
- **Moq** (mockowanie w testach)

---

## 🧱 Wymagania

| Narzędzie         | Wersja minimalna |
|-------------------|-----------------|
| [.NET SDK](https://dotnet.microsoft.com/download) | 8.x |
| [PostgreSQL](https://www.postgresql.org/) | 15.x |
| [EF Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) | najnowsze |
| [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/) | 8.x |

---

## 🚀 Uruchomienie projektu

### 1️⃣ Klonowanie repozytorium

```
git clone https://github.com/<twoje-repo>/to-do-be.git
cd to-do-be
```

### 2️⃣ Konfiguracja bazy danych
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ToDoBeDb;Username=<user>;Password=<password>"
}

```
### 3️⃣ Migracje bazy danych

Aby utworzyć lub zaktualizować schemat bazy danych:
```
dotnet ef database update

```
### 4️⃣ Uruchomienie backendu
```
dotnet test
```
## 🧪 Testy
Uruchomienie testów jednostkowych:
```
dotnet test

```
