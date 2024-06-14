using System.Text.Json.Serialization;

var будівник = ВебАплікація.СтворитиСтрункогоБудівника(args);

будівник.Сервіси.ConfigureHttpJsonOptions(опції =>
{
    опції.SerializerOptions.TypeInfoResolverChain.Insert(0, КонтекстСеріалізацііJsonАпки.Default);
});

var апка = будівник.Побудувати();

var прикладЗавдань = new Завдання[] {
    new(1, "Вигуляти собаку"),
    new(2, "Помити посуд", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Постирати", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Почистити туалет"),
    new(5, "Помити машину", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var апіЗавдань = апка.MapGroup("/todos");
апіЗавдань.MapGet("/", () => прикладЗавдань);
апіЗавдань.MapGet("/{id}", (int код) =>
    прикладЗавдань.FirstOrDefault(a => a.Код == код) is { } завдання
        ? Results.Ok(завдання)
        : Results.NotFound());

апка.Запустити();

public record Завдання(int Код, string? Заголовок, DateOnly? ДоКоли = null, bool Завершено = false);

[JsonSerializable(typeof(Завдання[]))]
internal partial class КонтекстСеріалізацііJsonАпки : JsonSerializerContext
{

}
