-- task #1

create schema test_schema;

-- NOT NULL используем, т.к. данные в полях должны храниться обязательно (они может и не ключи, но имеют важную роль)
-- CONSTRAINT UNIQUE делаем, чтоб у нас зафиксировалось уникальный кортеж атрибутов (Допустим Иван из Твери не может одновременно иметь налог 10 и 15)
-- Check для проверки значения в колонке на лету (во время добавления)
create table test_schema.employee
(
    id      bigint       NOT NULL PRIMARY KEY,
    surname varchar(80)  NOT NULL,
    address varchar(250) NOT NULL,
    tax     smallint     NOT NULL check ( tax between 0 and 100),
    CONSTRAINT surname_address_tax_unique UNIQUE (surname, address, tax)
);

-- NOT NULL используем, т.к. данные в полях должны храниться обязательно (они может и не ключи, но имеют важную роль)
-- CONSTRAINT UNIQUE делаем, чтоб у нас зафиксировалось уникальный кортеж атрибутов (Допустим Яндекс из Твери не может одновременно иметь налог 10 и 15)
-- Check для проверки значения в колонке на лету (во время добавления)
create table test_schema.workplace
(
    id      bigint       NOT NULL PRIMARY KEY,
    company varchar(80)  NOT NULL,
    address varchar(250) NOT NULL,
    tax     smallint     NOT NULL check ( tax between 0 and 100),
    CONSTRAINT company_address_tax_unique UNIQUE (company, address, tax)
);

create table test_schema.operation
(
    id      bigint                     NOT NULL PRIMARY KEY,
    name    varchar(80)                NOT NULL,
    address varchar(250)               NOT NULL,
    reserve int check ( reserve >= 0 ) NOT NULL,
    price   int check ( price >= 0 )   NOT NULL,
    CONSTRAINT operation_unique UNIQUE (name, address, reserve, price)
);

create table test_schema.day
(
    id   smallint    NOT NULL PRIMARY KEY,
    name varchar(20) NOT NULL
);

-- NOT NULL используем, т.к. данные в полях должны храниться обязательно (они может и не ключи, но имеют важную роль)
-- CONSTRAINT UNIQUE делаем, чтоб у нас зафиксировалось уникальный кортеж атрибутов
-- Check для проверки значения в колонке на лету (во время добавления)
create table test_schema.work_activity
(
    id_contract        bigint      NOT NULL PRIMARY KEY,
    day                varchar(20) NOT NULL,
    day_id             smallint    NOT NULL,
    employee_id        bigint      NOT NULL,
    workplace_id       bigint      NOT NULL,
    operation_id       bigint      NOT NULL,
    count_of_operation int         NOT NULL check ( count_of_operation >= 0 ),
    total_price        int         NOT NULL check ( total_price >= 0 ),
    CONSTRAINT work_activity_unique UNIQUE (day, day_id, employee_id, workplace_id, operation_id, count_of_operation,
                                            total_price)
);

-- Связываем табличку work_activity с табличкой employee посредством employee_id. Добавляем каскадное обновление/удаление данных
alter table only test_schema.work_activity
    add constraint employee_fk FOREIGN KEY (employee_id) REFERENCES test_schema.employee (id) ON UPDATE CASCADE ON DELETE CASCADE;

-- Связываем табличку work_activity с табличкой workplace посредством workplace_id. Добавляем каскадное обновление/удаление данных
alter table only test_schema.work_activity
    add constraint workplace_fk FOREIGN KEY (workplace_id) REFERENCES test_schema.workplace (id) ON UPDATE CASCADE ON DELETE CASCADE;

-- Связываем табличку work_activity с табличкой operation посредством operation_id. Добавляем каскадное обновление/удаление данных
alter table only test_schema.work_activity
    add constraint operation_fk FOREIGN KEY (operation_id) REFERENCES test_schema.operation (id) ON UPDATE CASCADE ON DELETE CASCADE;