-- task #3
SELECT *
FROM test_schema.employee;

SELECT *
FROM test_schema.workplace;

SELECT *
FROM test_schema.operation;

SELECT *
FROM test_schema.work_activity;

-- task #4 (Some troubles with month)
select distinct address
from test_schema.employee;

select distinct company
from test_schema.workplace;

SELECT DISTINCT month
FROM test_schema.work_activity
ORDER BY month DESC;

-- task #5
SELECT id_contract, month
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
select month, e.surname, w.company, o.name
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
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id and count_of_operation > 1;

select o.name
from test_schema.work_activity
         join test_schema.workplace w on w.id = work_activity.workplace_id and lower(w.company) LIKE '%больница'
         join test_schema.operation o on o.id = work_activity.operation_id
         join test_schema.employee e on e.id = work_activity.employee_id and e.address in ('Выкса', 'Вознесенское');

select distinct w.company, w.tax, e.surname, e.tax
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id and (e.tax between 7 and 16)
         join test_schema.workplace w on w.id = work_activity.workplace_id
order by w.tax desc, e.tax desc;

select distinct month, o.id, e.surname
from test_schema.work_activity
         join test_schema.employee e on e.id = work_activity.employee_id
         join test_schema.operation o on o.id = work_activity.operation_id and o.price >= 7000;

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
where wa.id_contract = temp_table.id_contract
