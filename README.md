# Онлайн аукцион с автосозданием лотов

## Описание проекта

Это приложение представляет собой онлайн-аукцион, где каждые 60 минут автоматически создаются новые лоты. Лоты сбрасываются и аукционы перезапускаются каждый день в 00:00. Лоты представлены в виде заглушек (mock objects) и отображаются в интерфейсе как временные объекты.

### Основные особенности:
- Автоматическое добавление нового лота каждый час.
- Полное обнуление всех аукционов в 00:00 UTC.
- Лоты представлены как уникальные NFT-картинки, симулирующие аукционные предметы.
- Вместо стандартной базы данных и авторизации использованы заглушки:
  - **База данных** заменена сервисами синглтон, которые хранят данные в памяти.
  - **Авторизация** реализована в виде заглушек, позволяя легко интегрировать полноценные механизмы в будущем.

## Технологии

Проект реализован с использованием следующих технологий:

- **Blazor**: для построения пользовательского интерфейса.
- **C# (ASP.NET Core)**: для серверной логики и взаимодействия с лотами.
- **Singleton Services**: для хранения данных о лотах и пользователях в памяти без использования базы данных.
- **Timers**: для обновления времени и автоматического создания/обнуления аукционов.
- **Net.Mail**: для отправке сообщений по электронной почте.

## Структура проекта

- **AuctionService**: основной сервис для управления лотами и их состоянием (создание, сброс).
- **EmailService**: отправляет уведомления победителям аукционов (если требуется).
- **Timer**: используется для отслеживания времени до создания новых лотов и сброса аукционов в полночь.

## Как работает приложение

1. **Создание лотов**: Каждые 60 минут добавляется новый лот, который автоматически отображается на главной странице.
2. **Сброс аукционов**: Каждый день в 00:00 происходит сброс всех активных аукционов, и начинается новый цикл.
3. **Заглушки (mock objects)**: В проекте использованы заглушки вместо полноценной базы данных и системы авторизации. Эти заглушки позволяют легко заменить их реальными сервисами в будущем.

## Запуск проекта

1. Склонируйте репозиторий на локальную машину.
   ```bash
   git clone https://github.com/username/auction-project.git
