-- Средние зарплаты по отделам
select avg(emp.emp_sal), emp.emp_dept_no
from db_exam.emp
group by emp.emp_dept_no
order by avg(emp.emp_sal) desc
limit 1;

-- Найти номера отделов, в которых средняя зарплата является максимальной среди средних значений зарплаты каждого отдела
select emp.emp_dept_no
from db_exam.emp
group by emp.emp_dept_no
having avg(db_exam.emp.emp_sal) = (select avg(emp.emp_sal)
                                   from db_exam.emp
                                   group by emp.emp_dept_no
                                   order by avg(emp.emp_sal) desc
                                   limit 1);
