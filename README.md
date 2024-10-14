# Address Standardization Service

## Описание

Этот проект представляет собой веб-сервис, который выполняет стандартизацию адресов с использованием API Dadata. Сервис принимает "сырой" адрес, отправляет его на обработку в Dadata и возвращает стандартизованный адрес в формате JSON.

## Технологии

- **ASP.NET Core**: Веб-фреймворк для создания API.
- **AutoMapper**: Библиотека для маппинга объектов.
- **HttpClient**: Для выполнения HTTP-запросов к Dadata API.
- **Dependency Injection (DI)**: Для управления зависимостями.
- **Serilog**: Для логгирования.
- **CORS**: Политика для разрешения запросов с внешних ресурсов.

## Установка и запуск

1. **Клонируйте репозиторий**:
    ```bash
    git clone https://github.com/Later9g/DadataTest
    cd Systems\Api\DadataTest.Api
    ```

2. **Настройте файл конфигурации**:
   В `appsettings.json` укажите настройки Dadata:
   ```json
   "DadataSettings": {
       "BaseUrl": "https://cleaner.dadata.ru/api/v1/clean/address",
       "Token": "ваш_токен",
       "Secret": "ваш_секретный_ключ"
   }

3. **Запустите проект:**<br/>
`dotnet run`

4. **Проверьте работоспособность:**<br/>
Отправьте GET-запрос<br/>
`GET http://localhost:<порт>/api/address/standardize?rawAddress=ваш_адрес`

## Пример запроса
`GET http://localhost:5037/api/address/standardize?rawAddress=мск сухонска 11/-89`<br/>

### Ответ
При успешной стандартизации адреса вы получите следующий JSON:

```json
{
    "Country": "Россия",
    "City": "Москва",
    "Region": "Москва",
    "Area": null,
    "Settlement": null,
    "Street": "Сухонская",
    "House": "11",
    "Flat": 89
}
```
## Логирование
Все логи будут записываться в консоль и могут быть сохранены в файлы для дальнейшего анализа.<br/>
