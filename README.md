<br />
<p align="center">


  <h3 align="center">Клиент-серверное десктопное приложение "Multiclient-Counter"</h3>

  <p align="center">
    Проект, представляющий собой тестовое задание в компанию ЛУКОЙЛ-Технологии.
    <br />
    <br />
    <br />
    <a href="https://t.me/bisnachauszuvorbei">Телеграм автора</a>
  </p>
</p>

<details open="open">
  <summary>Оглавление</summary>
  <ol>
    <li><a href="#Формулировка ТЗ">Формулировка ТЗ</a>
      <ul>
        <li><a href="#Технологии">Технологии</a></li>
      </ul>
    </li>
    <li><a href="#Сервер "Multiclient-Counter">Реализация сервера "Multiclient-Counter</a></li>
    <ul>
      <li><a href="#Описание прототипа">Описание прототипа</a></li>
      <li><a href="#Демонстрация работы">Демонстрация работы</a></li>
      <li><a href="#Контакты">Контакты</a></li>
    </ul>
  </ol>
</details>

### Формулировка ТЗ

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

<br />
<br />
<h3 align="center">Сервер "Multiclient-Counter"</h3>
<br />


### Описание прототипа

___
Данный репозиторий включает в себя реализацию сервера для десктопного приложения.<br />
Сервер выполнен в виде классического консольного приложения.<br />
При запуске программы сервера, поткрывается консоль, в которую необходимо ввести Port для запуска сервера (например: 8000), после этого необходимо ввести тип сервера (Socket, WebSocket) после чего произойдет старт сервера к которому в дальнейшем и будут подключаться клиенты.<br />
При нажатии кнопок Start, Stop, Clear на клиенте, на сервер будут передаваться соответсвующие комманды, которые будут запускать, останавливать или сбрасывать на сервере значение счётчика. Период изменения значения счётчика – 1 секунда.<br />
Значение счётчика будет отображаться на всех запущенных клиентах.<br />
При нажатии кнопки Stop на любом из клиентов, при условии того, что клиент сохраняет подключение к серверу, счётчик должен останавливаться и тд.<br />
___

### Демонстрация работы


![screen-gif](./demos/LukoilSocketDemo.gif)


### Контакты

Email - [a.sadilov.official@gmail.com](mailto:a.sadilov.official@gmail.com)
Telegram - [@bisnachauszuvorbei](https://t.me/bisnachauszuvorbei)
