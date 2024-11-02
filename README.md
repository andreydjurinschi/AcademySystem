# Academy System
## Работа c 30.10.2024

- Создание проекта
- Создание первых моделей (для базы данных)
- Подключение через connection string

## Добавление пакетов Nuget

1. **AutoMapper** — библиотека, которая помогает автоматически преобразовывать данные из одного объекта в другой. Например, если у вас есть объект с информацией о пользователе из базы данных и вам нужно скопировать его данные в другой объект (например, модель, используемую для отображения на сайте), AutoMapper упростит эту задачу, не требуя ручного копирования каждого поля.

2. **Microsoft.AspNetCore.Authentication.JwtBearer** — пакет для настройки безопасности в приложении с помощью токенов JWT (JSON Web Token). Это полезно, если ваше приложение работает с аутентификацией и авторизацией (например, требует, чтобы пользователи входили в систему). Токены позволяют безопасно передавать данные о пользователе между клиентом и сервером.

3. **Microsoft.EntityFrameworkCore.SqlServer** — этот пакет необходим для работы с базой данных SQL Server. Если ваше приложение хранит данные (например, данные о пользователях или продуктах), этот пакет поможет легко взаимодействовать с базой, отправляя и получая данные.

4. **Microsoft.EntityFrameworkCore.Tools** — набор инструментов, которые помогают управлять базой данных прямо из Visual Studio. Этот пакет позволяет создавать и изменять таблицы в базе данных, а также настраивать структуру данных, используя так называемые миграции (последовательные изменения в структуре базы данных).

5. **Swashbuckle.AspNetCore** — пакет, который добавляет поддержку Swagger. Swagger автоматически создаёт документацию для вашего API. Это полезно, если вы хотите видеть описание всех доступных запросов, которые ваше приложение поддерживает, и даже тестировать их через веб-интерфейс.

6. **Swashbuckle.AspNetCore.Annotations** — расширение для Swagger, которое позволяет добавлять пояснительные аннотации к методам и моделям. Например, можно добавить описание, для чего нужен каждый метод в вашем API, что улучшит документацию.

7. **Swashbuckle.AspNetCore.SwaggerUI** — компонент, который добавляет веб-страницу для тестирования API. С его помощью вы можете открыть интерфейс Swagger прямо в браузере и отправлять запросы к вашему API для проверки работы.

**Большинство пакетов взяты из источников в Google, не факт, что применение найдется и будет полезно каждого пакета**

## Добавление контекст базы данных
Создаю папку DbContexts, в ней класс для взаимодействия с базой данных
```cs
using Microsoft.EntityFrameworkCore;
namespace Academy.Services.CoursesAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) 
        {
        }
    }
}
```
плюс добавляю этот контекст в файл конфигурации
```cs
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```
метод добалвяет мой класс в контейнер зависимостей для использования базы данных из других частей приложения, так же определяю строку подключения:
```json
    "DefaultConnection": "Server=;Database=;Trusted_Connection=True;
    MultipleActiveResultSets=True"
```

Далее указываю, что ```Course``` - это сущность, которая представляет таблицу ```Courses```
```cs
public DbSet<Course> Courses { get; set; }
```
