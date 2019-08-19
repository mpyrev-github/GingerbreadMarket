# GingerbreadMarket
# Language / Язык
* [English version](https://github.com/vastXgithub/gingerbreadmarket/blob/master/README.md#test-task-for-66bit-company)
* [Русская версия](https://github.com/vastXgithub/gingerbreadmarket/blob/master/README.md#%D1%82%D0%B5%D1%81%D1%82%D0%BE%D0%B2%D0%BE%D0%B5-%D0%B7%D0%B0%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%B2-%D0%BA%D0%BE%D0%BC%D0%BF%D0%B0%D0%BD%D0%B8%D1%8E-66bit)
# Test task for 66bit company
## Task:
Create an exchange in the form of a web-system on ASP .NET MVC.
This solution is presented using the postgreSQL database.
### Try the program
If you want to try my program, you can [download](https://github.com/vastXgithub/gingerbreadmarket/archive/master.zip) project.
For the program to work, initially, you must install postgreSQL and create the OrdersDb database.
And add webuser user with webuser password. He must be the owner of the tables.
Database structure:
* OrdersDb
  * Deals
    * Id (bigint)
    * DealDate (date)
    * BuyDate (date)
    * SellDate (date)
    * Price (double precision)
    * Count (bigint)
    * BuyEmail (text)
    * SellEmail (text)
  * Orders
    * Id (bigint)
    * Date (date)
    * Price (double precision)
    * Count (bigint)
    * IsSell (boolean)
    * Email (text)
<br />

> Don\`t forget to start the database before starting the program!
## The authors
* **Mikhail Pyryev** - *Main work* - [vastXgithub](https://github.com/vastXgithub).

---

<br /><br />

# Тестовое задание в компанию 66bit
## Поставленная задача:
Создать биржу в виде web-системы на ASP .NET MVC.
Данное решение представлено с использованием базы данных postgreSQL.
### Попробовать программу
Если вы хотите попробовать мою программу, вы можете [скачать](https://github.com/vastXgithub/gingerbreadmarket/archive/master.zip) проект.
Для работоспособности программы, первоначально, необходимо установить postgreSQL и создать базу данных OrdersDb.
И добавить пользователя webuser с паролем webuser. Он должен являться владельцем таблиц.
Структура базы данных:
* OrdersDb
  * Deals
    * Id (bigint)
    * DealDate (date)
    * BuyDate (date)
    * SellDate (date)
    * Price (double precision)
    * Count (bigint)
    * BuyEmail (text)
    * SellEmail (text)
  * Orders
    * Id (bigint)
    * Date (date)
    * Price (double precision)
    * Count (bigint)
    * IsSell (boolean)
    * Email (text)
<br />

> Не забудьте запустить базу данных перед запуском программы!
## Авторы
* **Михаил Пырьев** - *Основная работа* - [vastXgithub](https://github.com/vastXgithub).

<br /><br />
