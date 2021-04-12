-- task #1

create schema test_schema;

create table test_schema.employee
(
    id      bigint       NOT NULL PRIMARY KEY,
    surname varchar(80)  NOT NULL,
    address varchar(250) NOT NULL,
    tax     smallint     NOT NULL check ( tax between 0 and 100),
    CONSTRAINT surname_address_tax_unique UNIQUE (surname, address, tax)
);

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

create table test_schema.work_activity
(
    id_contract        bigint      NOT NULL PRIMARY KEY,
--     date               date      NOT NULL,
    month              varchar(20) NOT NULL,
    employee_id        bigint      NOT NULL,
    workplace_id       bigint      NOT NULL,
    operation_id       bigint      NOT NULL,
    count_of_operation int         NOT NULL check ( count_of_operation >= 0 ),
    total_price             int         NOT NULL check ( total_price >= 0 ),
    CONSTRAINT work_activity_unique UNIQUE (month, employee_id, workplace_id, operation_id, count_of_operation, total_price)
);


alter table only test_schema.work_activity
    add constraint employee_fk FOREIGN KEY (employee_id) REFERENCES test_schema.employee (id) ON UPDATE CASCADE ON DELETE CASCADE;

alter table only test_schema.work_activity
    add constraint workplace_fk FOREIGN KEY (workplace_id) REFERENCES test_schema.workplace (id) ON UPDATE CASCADE ON DELETE CASCADE;

alter table only test_schema.work_activity
    add constraint operation_fk FOREIGN KEY (operation_id) REFERENCES test_schema.operation (id) ON UPDATE CASCADE ON DELETE CASCADE;