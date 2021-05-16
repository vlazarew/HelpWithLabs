insert into medical_clinic.credentials (login, password, is_admin) values ('admin', 'admin', true);
insert into medical_clinic.credentials (login, password, is_admin) values ('test', 'test', false);

insert into medical_clinic.type_of_service (name) values ('Прием врача');
insert into medical_clinic.type_of_service (name) values ('УЗИ');
insert into medical_clinic.type_of_service (name) values ('Лабораторные исследования');

insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-аллерголога', 40);
insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-пульмонолога', 40);
insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-ортопеда', 40);
insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-гинеколога', 40);
insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-уролога', 40);
insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-офтальмолога', 40);
insert into medical_clinic.service (type_of_service_id, name, price) values (1, 'Первичный прием врача-оториноларинголога', 40);

insert into medical_clinic.service (type_of_service_id, name, price) values (2, 'Органы брюшной полости и почек', 49);
insert into medical_clinic.service (type_of_service_id, name, price) values (2, 'Почки и надпочечники', 28);
insert into medical_clinic.service (type_of_service_id, name, price) values (2, 'Почки, надпочечники и мочевой пузырь', 30);
insert into medical_clinic.service (type_of_service_id, name, price) values (2, 'Почки, надпочечники и мочевой пузырь с определением остаточной мочи', 32);
insert into medical_clinic.service (type_of_service_id, name, price) values (2, 'Мочевой пузырь с определением остатка мочи', 23);

insert into medical_clinic.service (type_of_service_id, name, price) values (3, 'Общий анализ крови', 15);
insert into medical_clinic.service (type_of_service_id, name, price) values (3, 'Общий анализ мочи', 10);
insert into medical_clinic.service (type_of_service_id, name, price) values (3, 'Исследование мочи', 5);
insert into medical_clinic.service (type_of_service_id, name, price) values (3, 'Исследование мочи методом Ничепоренко', 8);
insert into medical_clinic.service (type_of_service_id, name, price) values (3, 'Исследование крови методом МРП перед вакуум-аспирацией', 15);

insert into medical_clinic.department (name, description) values ('Терапия', '"В нашем центре Вы сможете заказать:

Вызов врача на дом.
Лечебно-диагностический прием.
Профосмотр
Консультации врача высшей категории по заболеваниям:

верхних дыхательных путей (пневмония, бронхиты);
органов желудочно-кишечного тракта (гастриты, язвенная болезнь желудка и двенадцатиперстной кишки и др.);
гипертония, аритмия, ишемическая болезнь сердца и др."');
insert into medical_clinic.department (name, description) values ('Хирургия', '"Амбулаторная хирургия — новый подход к лечению многих недугов. Надо признать, что на Западе большое количество операций осуществляется именно в амбулаторных условиях. Безусловно, хирург в Минске платно не все проблемы может решить таким образом, но неосложненные случаи запросто.

Например, удаление вросшего ногтя, фурункула, доброкачественного новообразования занимает немного времени и уже через несколько часов после операции пациентов отправляют восстанавливаться домой. Конечно, это не значит, что хирург в Минске платно бросит вас. Вовсе нет, все это время вы будете под строгим наблюдением нашего специалиста до полного выздоровления."');
insert into medical_clinic.department (name, description) values ('Маммология', 'Врач-маммолог занимается диагностикой, профилактикой, и, соответственно, лечением заболеваний молочных желез. К сожалению, тенденция такова, что из-за ритма жизни, вредных привычек, стрессов женщины чаще стали жаловаться на проблемы с грудью, но при этом не спешат обращаться к специалисту. А это очень опасно, ведь большинство заболеваний поддаются лечению на ранней стадии, а вот в запущенной форме приходится прибегать к оперативному вмешательству.');
insert into medical_clinic.department (name, description) values ('Аллергология', 'Самое ценное и дорогое, что у нас есть — это здоровье, но безответственное отношение к ему, несвоевременное лечение и просто нежелание встречаться с специалистами в белых халатах может привести к тому, что потребуется экстренная помощь. Часто мы игнорируем первые симптомы, не хотим верить в то, что у нас аллергия, тем самым обрекая себя на мучения. Для исключения таких неприятных последствий при первых же сбоях в организме следует посетить врача-аллерголога');
insert into medical_clinic.department (name, description) values ('Лор', '"Многие пациенты к насморку относятся спокойно, забывая, что нос, ухо, горло находятся рядом с головным мозгом и любое воспаление можете перейти на него, поэтому запускать, пусть даже безобидный насморк не стоит.

Решить проблемы с заболеваниями этих органов поможет лор в Минске, цены на услуги которого доступны каждому. Опытный врач без труда найдет причину воспаления горла, постоянной сухости в носу, храпа и т.п."');
insert into medical_clinic.department (name, description) values ('Дерматология', 'Кожа является основным индикатором состояния здоровья всего организма. При возникновении таких симптомов, как высыпания (угри, пузыри, пятна), жжение, шелушение, болезненность, зуд, изменение цвета (области с более темным или светлым оттенком), необходимо немедленно записаться к дерматологу.');
insert into medical_clinic.department (name, description) values ('Кардиология', 'Кардиолог — специалист, который занимается диагностикой и лечением заболеваний сердечно-сосудистой системы. И если недавно к этому доктору записывались лишь пожилые люди, то сегодня нет возрастных рамок. Дети, молодые и пожилые люди все нуждаются в консультации этого доктора. Он выявляет патологии даже на раннем этапе, но к сожалению, долгие очереди, запись не дает возможность посетить специалиста своевременно, и поэтому платная кардиология в Минске пользуется большой популярностью.');
insert into medical_clinic.department (name, description) values ('Ревматология', '"Ревматолог диагностирует и лечит многочисленные ревматические заболевания:

артрит;
ревматическая лихорадка;
заболевания сосудов;
подагра;
остеопороз.
Данная сфера медицины очень тесно переплетается с иными областями из-за явного нарушения иммунных процессов. Некоторые ошибочно полагают, что вылечить это заболевание невозможно, обходя кабинет с табличкой «врач-ревматолог». На самом деле, все зависит от формы заболевания, но даже самое сложное проявление ревматического заболевания победить можно."');
insert into medical_clinic.department (name, description) values ('Эндокринология', 'Выпадение волос, чрезмерная потливость, утомляемость, чувствительность к холоду и теплу, колебания веса, бессонница — все эти симптомы могут «кричать» о проблемах со щитовидной железой. К сожалению, многие не обращают внимания на них и продолжают сетовать на экологию, стрессы и иные факторы. ормональный обмен — механизм, который поддерживает нормальную работу всего организма. Именно от него зависит функционирование костной и липидной ткани, сердечнососудистой системы, он отвечает за умственное развитие и иные важные факторы. Консультация врача-эндокринолога в нашем медцентре поможет оценить масштаб проблемы, выявить все нарушения эндокринной системы уже на раннем этапе.');

insert into medical_clinic.employee (FIO, department_id) values ('Мухина Раиса Ивановна', 2);
insert into medical_clinic.employee (FIO, department_id) values ('Самойлова Анастасия Сергеевна', 1);
insert into medical_clinic.employee (FIO, department_id) values ('Курин Михаил Степанович', 3);
insert into medical_clinic.employee (FIO, department_id) values ('Вежновец Екатерина Андеервна', 4);
insert into medical_clinic.employee (FIO, department_id) values ('Губар Валерия Александровна', 5);
insert into medical_clinic.employee (FIO, department_id) values ('Седун Алла Викторовна', 6);
insert into medical_clinic.employee (FIO, department_id) values ('Нептун Галина Григоревна', 7);


insert into medical_clinic.registration (date, credentials_id, employee_id, service_id) values ('2021-02-06 10:15:00', 1, 2, 9);
insert into medical_clinic.registration (date, credentials_id, employee_id, service_id) values ('2021-02-07 15:45:00', 1, 2, 10);
insert into medical_clinic.registration (date, credentials_id, employee_id, service_id) values ('2021-02-09 18:30:00', 1, 1, 1);
