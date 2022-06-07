<br />
<p align="center">
<img src="ManagmentApp.png" alt="Logo" width="400" height="90">

  <h3 align="center">Клиент-серверное десктопное приложение</h3>

  <p align="center">
    Проект, представляющий собой тестовое задание в компанию ЛУКОЙЛ-Технологии.
    <br />
    <!--a href="https://fatclient.herokuapp.com/"><strong>Посмотреть демо »</strong></a-->
    <br />
    <br />
    <a href="https://t.me/bisnachauszuvorbei">Телеграм автора</a>
  </p>
</p>

<details open="open">
  <summary>Оглавление</summary>
  <ol>
    <li>
      <a href="#О проекте">О проекте</a>
      <ul>
        <li><a href="#Технологии">Технологии</a></li>
      </ul>
    </li>
    <li><a href="#Демонстрация работы">Демонстрация работы</a></li>
    <li><a href="#Контакты">Контакты</a></li>
  </ol>
</details>

## О проекте

___
Постановка задачи:
Разработать 2 приложения – клиент и сервер.
Сервер должен быть выполнен в виде консольного приложения.
В настройках сервера должна быть возможность задать порт, на котором запускается приложение.
В настройках клиента должна быть возможность задать адрес сервера – ip и порт.
При старте клиента должно запускаться окно, на котором:
* Кнопка СТАРТ
* Кнопка СТОП
* СБРОС
* Поле для отображения значения счётчика
При нажатии кнопки СТАРТ, на сервере должен запускаться счётчик. Период изменения значения счётчика – 1 секунда.
Значение счётчика должно отображаться на всех запущенных клиентах.
При нажатии кнопки СТОП на любом клиенте, счётчик должен останавливаться. Кнопка СТОП на всех клиентах должна переименовываться в ПРОДОЛЖИТЬ.
При нажатии ПРОДОЛЖИТЬ счётчик начинает увеличиваться. Кнопка ПРОДОЛЖИТЬ на всех клиентах должна переименовываться в СТОП.
При нажатии СБРОС счётчик должен обнуляться. Должно отрабатывать в любой момент. И в момент остановки счётчика, и в процессе его увеличения.
___

### Используемые технологии

* [C#]() - язык программирования 
* [.Net framework 4.6]() - среда для создания современных десктоп-приложений для ОС Windows
* [WPF]() - Визуальная часть

Взаимодействие между клиентом и сервером должно быть реализовано двумя способами:
* socket
* websocket
При взаимодействии через websocket данные должны передаваться в формате json.
Способ взаимодействия должен задаваться в настройках клиента.


## Демонстрация работы


![screen-gif](./demo.gif)


## Контакты

Email - [a.sadilov.official@gmail.com](mailto:a.sadilov.official@gmail.com)
Telegram - [@bisnachauszuvorbei](https://t.me/bisnachauszuvorbei)