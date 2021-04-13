-- task #3
SELECT *
FROM test_schema.employee;

SELECT *
FROM test_schema.workplace;

SELECT *
FROM test_schema.operation;

SELECT *
FROM test_schema.work_activity;

-- task #4
select distinct address
from test_schema.employee;

select distinct company
from test_schema.workplace;

SELECT DISTINCT day, day_id
FROM test_schema.work_activity
ORDER BY day_id;

-- task #5
SELECT id_contract, day
FROM test_schema.work_activity
WHERE work_activity.total_price >= 14000;

SELECT DISTINCT address, tax
FROM test_schema.employee
WHERE address IN ('Выкса', 'Навашино');

SELECT name, price, address
FROM test_schema.operation
WHERE operation.price > 10000
  AND name LIKE 'Инъекция%'
ORDER BY address, price;

-- task #6
select day, e.surname, w.company, o.name
from test_schema.work_activity
         left join test_schema.employee e on e.id = work_activity.employee_id
         left join test_schema.workplace w on w.id = work_activity.workplace_id
         left join test_schema.operation o on o.id = work_activity.operation_id;

select id_contract, w.company, count_of_operation, total_price
from test_schema.work_activity
         left join test_schema.workplace w on w.id = work_activity.workplace_id
order by total_price;

-- task #7
select distinct e.surname, e.address
from test_schema.work_activity wa
         join test_schema.employee e on e.id = wa.employee_id and wa.count_of_operation > 1
         join test_schema.operation o on o.id = wa.operation_id and o.name = 'Наложение гипса';

select distinct o.name
from test_schema.work_activity
         join test_schema.workplace w on w.id = work_activity.workplace_id and lower(w.company) LIKE '%больница'
         join test_schema.operation o on o.id = work_activity.operation_id
         join test_schema.employee e on e.id = work_activity.employee_id and e.address in ('Выкса', 'Вознесенское');

select distinct w.company, w.tax, e.surname, e.tax
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id and (e.tax between 7 and 16)
         join test_schema.workplace w on w.id = work_activity.workplace_id
order by w.tax desc, e.tax desc;

select distinct day, o.id, e.surname
from test_schema.work_activity wa
         join test_schema.employee e on e.id = wa.employee_id
         join test_schema.operation o on o.id = wa.operation_id and o.price >= 7000;

select distinct day, o.id, e.surname
from test_schema.work_activity wa
         join test_schema.employee e on e.id = wa.employee_id and e.id in (select e.id
                                                                           from test_schema.work_activity wa
                                                                                    join test_schema.employee e
                                                                                         on e.id = wa.employee_id and
                                                                                            (wa.total_price / wa.count_of_operation) >= 7000
                                                                           group by e.id
                                                                           having sum(wa.count_of_operation) > 1)
         join test_schema.operation o on o.id = wa.operation_id and o.price >= 7000;

-- task #8
update test_schema.work_activity wa
set total_price = wa.total_price * (100 - (select distinct tax
                                           from test_schema.employee e
                                           where e.id = wa.employee_id)) / 100;

select total_price
from test_schema.work_activity;

-- task #9
alter table only test_schema.work_activity
    add column company_tax_value smallint NOT NULL check ( company_tax_value >= 0 ) default 0;

with temp_table as (
    select distinct w.tax * wa.total_price / 100 as tax_value, wa.id_contract
    from test_schema.workplace w
             join test_schema.work_activity wa on w.id = wa.workplace_id
)
update test_schema.work_activity wa
set company_tax_value = temp_table.tax_value
from temp_table
where wa.id_contract = temp_table.id_contract;

-- task #10 (В условии написано что персонал из Навашино, рабочее место - Выкса, но таких записей нет.
-- Если свапнуть адреса - то будет одна запись)
select e.surname
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id
    and e.address IN ('Выкса')
--                                             and e.address IN ('Навашино')
         join test_schema.operation o
              on o.id = work_activity.operation_id and o.name IN ('Инъекция поливитаминов', 'Инъекция алоэ')
         join test_schema.workplace w on w.id = work_activity.workplace_id
    and w.address IN ('Навашино');
--                                              and w.address IN ('Выкса');

select *
from test_schema.operation
where id NOT IN (select distinct o.id
                 from test_schema.work_activity
                          join test_schema.operation o on o.id = work_activity.operation_id
                 where day in ('Понедельник', 'Вторник'));

select distinct w.company, w.tax, e.surname, e.tax
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id
         join test_schema.workplace w on w.id = work_activity.workplace_id
where e.id IN (select e1.id
               from test_schema.employee e1
               where e1.tax between 7 and 16)
order by w.tax desc, e.tax desc;

select distinct day, o.id, e.surname
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id
         join test_schema.operation o on o.id = work_activity.operation_id
where o.id IN (select o1.id
               from test_schema.operation o1
               where o1.price >= 7000);

-- task #11
select *
from test_schema.workplace w
where w.tax = ANY (select min(w1.tax)
                   from test_schema.workplace w1);

-- 11 B ver 1 (Именно сама операция стоит наименьшую величину)
select *
from test_schema.employee e
where e.id = ANY (select wa.employee_id
                  from test_schema.work_activity wa
                  where wa.operation_id IN (select o1.id
                                            from test_schema.operation o1
                                            where o1.price IN (select min(o2.price)
                                                               from test_schema.operation o2)));

-- 11 B ver 2 (total_price наименьший)
select *
from test_schema.employee e
where e.id = ANY (select wa1.employee_id
                  from test_schema.work_activity wa1
                  where wa1.total_price IN (select min(wa2.total_price)
                                            from test_schema.work_activity wa2));

-- 11 C ver 1 (наибольший total cost)
select max(wa1.total_price)
from test_schema.work_activity wa1
where wa1.day = ANY (ARRAY ['Четверг', 'Пятница']);


-- 11 C ver 2 (наибольшая стоимость операции)
select max(wa1.total_price / wa1.count_of_operation)
from test_schema.work_activity wa1
where wa1.day = ANY (ARRAY ['Четверг', 'Пятница']);

select distinct e.surname, e.address
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id
         join test_schema.operation o on o.id = work_activity.operation_id and o.name = 'Наложение гипса'
where NOT count_of_operation = ANY (ARRAY [1]);

-- task #12
-- Работники + места работы
select employee.address
from test_schema.employee
UNION
select workplace.address
from test_schema.workplace;

-- Работники + места проведения операция
select employee.address
from test_schema.employee
UNION
select operation.address
from test_schema.operation;

-- task #13
select *
from test_schema.employee e
where NOT EXISTS(select 1
                 from test_schema.work_activity wa
                 where wa.employee_id = e.id
                   and wa.day = 'Суббота');

-- Изменить у work_activity (id_contact = 51040) workplace_id на 2, operation_id на 7
select *
from test_schema.operation o
where not exists(select *
                 from test_schema.work_activity wa
                          join test_schema.employee e on e.id = wa.employee_id
                          join test_schema.workplace w on w.id = wa.workplace_id
                 where not w.address = 'Выкса'
                   and wa.operation_id = o.id);

select *
from test_schema.workplace w
where exists(select workplace_id, sum(count_of_operation)
             from test_schema.work_activity wa
                      join test_schema.operation o on o.id = wa.operation_id and o.name = 'УЗИ'
             where wa.workplace_id = w.id
             group by wa.workplace_id
             having sum(wa.count_of_operation) <= 1);

select *
from test_schema.workplace w
where not exists(select *
                 from test_schema.work_activity wa
                          join test_schema.employee e on e.id = wa.employee_id
                 where wa.workplace_id = w.id
                   and e.address = w.address);

-- task #14
-- (С разбиение по персоналу)
select count(distinct wa.workplace_id), e.id, e.surname
from test_schema.work_activity wa
         join test_schema.employee e on e.id = wa.employee_id and e.id IN (select wa2.employee_id
                                                                           from test_schema.work_activity wa2
                                                                                    join test_schema.workplace w
                                                                                         on w.id = wa2.workplace_id and w.address = 'Выкса')
group by e.id, e.surname;

select count(distinct wa.workplace_id)
from test_schema.work_activity wa
         join test_schema.employee e on e.id = wa.employee_id and e.id IN (select wa2.employee_id
                                                                           from test_schema.work_activity wa2
                                                                                    join test_schema.workplace w
                                                                                         on w.id = wa2.workplace_id and w.address = 'Выкса');

select avg(e.tax)
from test_schema.employee e
where e.id IN (select distinct wa2.employee_id
               from test_schema.work_activity wa2
                        join test_schema.operation o
                             on o.id = wa2.operation_id and o.name LIKE 'Инъекция%');

select e.*
from test_schema.employee e
         join test_schema.work_activity wa on e.id = wa.employee_id
where (wa.total_price / wa.count_of_operation) = (
    select min(wa1.total_price / wa1.count_of_operation)
    from test_schema.work_activity wa1);

select sum(wa.count_of_operation)
from test_schema.work_activity wa
         join test_schema.employee e on e.id = wa.employee_id and e.surname = 'Губанов'
where (wa.total_price / wa.count_of_operation) <= 15000
  and wa.day = 'Понедельник';

-- task #15
select day, operation_id, sum(1) as sum
from test_schema.work_activity wa
group by day, operation_id, day_id
order by day_id, operation_id;

select employee_id, avg(total_price / work_activity.count_of_operation)
from test_schema.work_activity
group by employee_id;

select workplace_id, sum(total_price)
from test_schema.work_activity
group by workplace_id
having sum(total_price) > 30000;

select day, sum(count_of_operation)
from test_schema.work_activity
group by day, day_id
order by day_id;