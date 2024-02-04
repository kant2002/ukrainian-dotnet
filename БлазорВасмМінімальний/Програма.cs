using БлазорВасмМінімальний.Компоненти;

var будівник = ВебАплікація.СтворитиБудівника(args);

// Додати сервіси до контейнера.
будівник.Сервіси.ДодатиРазорКомпоненти()
    .ДодатиІнтерактивніСерверніКомпоненти();

var апка = будівник.Побудувати();

// Налаштувати HTTP-запитів pipeline.
if (!апка.Оточення.УРозробці())
{
    апка.ВикористовуватиОбробникПомилок("/Помилка", створюватиОбластьДляПомилок: true);
    // За замовчанням HSTS тримається 30 днів. Ви можете це змінити для виробничих сценаріїв, дивитесь https://aka.ms/aspnetcore-hsts.
    апка.ВикористовуватиHsts();
}

апка.ВикористовуватиПеренаправленняHttps();

апка.ВикористовуватиСтатичніФайли();
апка.ВикористовуватиАнтипідробку();

апка.ВідобразитиРазорКомпоненти<Апка>()
    .ДодатиІнтерактивнийРежимСерверногоРендеру();

апка.Запустити();
