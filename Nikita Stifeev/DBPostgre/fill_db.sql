-- task #2

INSERT INTO test_schema.employee
VALUES (001, 'Медина', 'Вознесенское', 14),
       (002, 'Севастьянов', 'Навашино', 14),
       (003, 'Бессонов', 'Выкса', 10),
       (004, 'Губанов', 'Выкса', 10),
       (005, 'Боева', 'Починки', 5);

INSERT INTO test_schema.workplace
VALUES (001, 'Районная больница', 'Вознесенское', 10),
       (002, 'Травм. пункт', 'Выкса', 3),
       (003, 'Больница', 'Навашино', 4),
       (004, 'Род. дом', 'Вознесенское', 12),
       (005, 'Больница', 'Починки', 4),
       (006, 'Травм. пункт', 'Лукояново', 3);

INSERT INTO test_schema.operation
VALUES (001, 'Наложение гипса', 'Выкса', 2000, 18000),
       (002, 'Блокада', 'Навашино', 10000, 14000),
       (003, 'Инъекция поливитаминов', 'Навашино', 20000, 11000),
       (004, 'Инъекция алоэ', 'Навашино', 12000, 11000),
       (005, 'ЭКГ', 'Вознесенское', 115, 10000),
       (006, 'УЗИ', 'Вознесенское', 20, 30000),
       (007, 'Флюорография', 'Выкса', 1000, 5000);

INSERT INTO test_schema.work_activity
VALUES (51040, 'Понедельник', 1, 001, 001, 007, 4, 20000),
       (51041, 'Понедельник', 1, 003, 003, 006, 1, 30000),
       (51042, 'Понедельник', 1, 004, 003, 004, 3, 33000),
       (51043, 'Понедельник', 1, 004, 005, 001, 2, 36000),
       (51044, 'Понедельник', 1, 004, 004, 006, 1, 30000),
       (51045, 'Среда', 3, 002, 002, 005, 3, 30000),
       (51046, 'Четверг', 4, 003, 006, 004, 4, 44000),
       (51047, 'Четверг', 4, 004, 006, 002, 1, 28000),
       (51048, 'Четверг', 4, 005, 003, 003, 4, 44000),
       (51049, 'Пятница', 5, 002, 004, 005, 1, 10000),
       (51050, 'Пятница', 5, 003, 006, 004, 2, 22000),
       (51051, 'Пятница', 5, 003, 003, 001, 2, 36000),
       (51052, 'Пятница', 5, 005, 003, 002, 1, 14000),
       (51053, 'Суббота', 6, 003, 002, 007, 2, 10000),
       (51054, 'Суббота', 6, 004, 006, 004, 1, 11000),
       (51055, 'Суббота', 6, 005, 005, 004, 2, 22000),
       (51056, 'Суббота', 6, 003, 006, 003, 2, 22000);