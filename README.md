Ссылка на Itch.io проекта: https://enelm.itch.io/jmt

Иконки взяты с этого бесплатного сайта: https://game-icons.net/
Шрифт взят с этого бесплатного сайта: https://fonts.google.com/

В проекте используется аналог MVC, более удачно подходящий, по рекомендациям Unity - MVP
Руководствовался данной книгой: https://unity.com/resources/level-up-your-code-with-game-programming-patterns?ungated=true

Версия Unity 2020.3.48f1

Названия файлов в Assets/ говорят за себя
Разбор файлов внутри Scripts/

Проект обязан начинаться в InitScene, а инициализироваться с помощью Game.cs

###О каждом файле в отдельности
- Scripts/Assets нужен для Scriptable объектов, чтобы упростить задачу с именованием файлов для геймдизайнера
- Scripts/Extensions добавляет экстеншены к скриптам. Пока только для Action, где есть безопасный вызов каждого делегата в экшене
- Scripts/Inputs тут не применяется, можно не смотреть
- Scripts/Interfaces ответственен за UI. Есть абстрактный класс Interface, от которого наследуются все презентеры (для интеракции непосредственно с UI)
- Scripts/Interfaces/Elements ответственен за мелочные действия. Сейчас там есть адаптер размеров сеток, чтобы автоматически подстраивать размер ячеек гридов под любой экран
- Scripts/Items содержит в себе данные предметов (доски, метал, пища, т.д.). Как и Products ниже, является моделью
- Scripts/Products содержит в себе данные товаров (набор строительный, набор драгоценностей и т.д.). Интерфейс Scriptable объектов геймдизайнер-френдли, как и в Items
- Scripts/Scenes нужен для отделения работы с сценами
- Scripts/Times хранит в себе таймер для засекания времени и Time, являющийся заменой юнитёвского Update у монобехов, только не привязанным к монобеху, а статическим

В данном случае оверрайды Interface являются презентерами, моделью являются Scriptable объекты, а юнитёвский UI выступает в качестве вью (также есть и свои парочку скриптов, например для отображения ProductPanel и ItemPanel)