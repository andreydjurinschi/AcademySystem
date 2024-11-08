## Микросервисы
**Микросервисы** — это архитектурный стиль разработки приложений, при котором приложение делится на множество независимых сервисов. Каждый микросервис решает одну конкретную задачу или предоставляет одну функциональность, имеет свою базу данных и работает независимо от других сервисов. Это дает преимущества в масштабируемости, надежности и гибкости разработки.

**Web API** (интерфейс программирования приложений для веба) — это набор методов, которые позволяют взаимодействовать с приложением через HTTP-протокол. Web API предоставляет интерфейс для обмена данными между клиентом и сервером. API может быть использовано для работы с данными, для взаимодействия с другими системами или для предоставления доступа к функционалу приложения.

Микросервисы и Web API часто используются вместе: микросервисы могут общаться друг с другом через Web API, что позволяет им обмениваться данными и взаимодействовать.

          Микросервисная архитектура в ASP.NET имеет несколько преимуществ:
- **Масштабируемость:** Каждый микросервис можно масштабировать независимо, что позволяет эффективно распределять нарузку.
- **Гибкость в разработке:** Микросервисы можно разрабатывать и развертывать независимо друг от друга. Это позволяет использовать разные технологии для разных сервисов.
- **Устойчивость:** Если один микросервис выходит из строя, остальные продолжают работать. Это повышает общую отказоустойчивость системы.
- **Обновления без простоя:** Микросервисы можно обновлять по отдельности, что минимизирует время простоя всей системы.
- **Упрощенная разработка и тестирование:** Разработка микросервисов обычно сосредоточена на одной задаче, что облегчает понимание, поддержку и тестирование кода.
- **Автономность:** Каждый микросервис управляется своей собственной базой данных, что снижает зависимость между сервисами и упрощает обработку данных.

## Процесс и начало работы
#### 1) Создание проекта
Первым делом я создал пустой проект, где уже в нем создал две папки -> **services** и **frontend**
Во второй папке я создал проект asp.net mvc
**ASP.NET MVC** (Model-View-Controller) — это фреймворк для разработки веб-приложений на платформе .NET, основанный на паттерне проектирования MVC. Этот подход разделяет приложение на три основные части: модель, представление и контроллер. Он позволяет строить гибкие, поддерживаемые и легко тестируемые веб-приложения.

1. **Model** (Модель) — отвечает за данные и логику приложения. Модель взаимодействует с базой данных и содержит бизнес-логику. Она может также содержать объекты, которые представляют данные в приложении.

2. **View** (Представление) — отвечает за отображение данных, предоставляемых моделью, пользователю. Представление не содержит логики обработки данных, а лишь отображает информацию в виде HTML, CSS и JavaScript.

3. **Controller** (Контроллер) — управляет запросами от пользователя. Контроллер обрабатывает пользовательский ввод, вызывает логику модели и возвращает представление, которое будет отображено пользователю.


#### 1) Добавление пакетов Nuget

1. **AutoMapper** — библиотека, которая помогает автоматически преобразовывать данные из одного объекта в другой. Например, если у нас есть объект с информацией о курсе из базы данных и нам нужно скопировать его данные в другой объект (например, модель, используемую для отображения на сайте), AutoMapper упростит эту задачу.

2. **Microsoft.EntityFrameworkCore.SqlServer** — этот пакет необходим для работы с базой данных SQL Server. Если наше приложение хранит данные, этот пакет поможет легко взаимодействовать с базой, отправляя и получая данные.

3. **Microsoft.EntityFrameworkCore.Tools** — набор инструментов, которые помогают управлять базой данных прямо из Visual Studio. Этот пакет позволяет создавать и изменять таблицы в базе данных, а также настраивать структуру данных, используя так называемые миграции (последовательные изменения в структуре базы данных).

4. **Swashbuckle.AspNetCore** — пакет, который добавляет поддержку Swagger. Swagger автоматически создаёт документацию для вашего API, показывает возможные запросы и даже позволяет тестировать их через веб-интерфейс.

6. **Swashbuckle.AspNetCore.Annotations** — расширение для Swagger, которое позволяет добавлять пояснительные аннотации к методам и моделям. Например, можно добавить описание, для чего нужен каждый метод в вашем API, что улучшит документацию.

7. **Swashbuckle.AspNetCore.SwaggerUI** — компонент, который добавляет веб-страницу для тестирования API. С его помощью вы можете открыть интерфейс Swagger прямо в браузере и отправлять запросы к вашему API для проверки работы.


## Добавление контекст базы данных
Создаю папку DbContexts, в ней класс для взаимодействия с базой данных
```csharp
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
```csharp
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


