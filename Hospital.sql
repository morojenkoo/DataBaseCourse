CREATE TABLE IF NOT EXISTS Department (
	Department_ID SERIAL PRIMARY KEY,
	Floor_number INT NOT NULL,
	Inner_phone VARCHAR(20) NOT NULL UNIQUE CHECK (Inner_phone ~ '^\+?[0-9\-\s\(\)]+$'),
	Department_name VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Employee (
	Employee_ID SERIAL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Patronymic VARCHAR(50),
	Surname VARCHAR(50) NOT NULL,
	Gender BIT NOT NULL, -- 1 мужчина, 0 женщина
	Date_of_birth DATE NOT NULL,
	Phone_number VARCHAR(20) NOT NULL UNIQUE CHECK (Phone_number ~ '^\+?[0-9\-\s\(\)]+$'),
	Position INT NOT NULL CHECK (Position IN (1,2,3)), -- 1 доктор, 2 медсестра, 3 санитар
	Department_ID INT NOT NULL,
	Passport_number VARCHAR(11) NOT NULL UNIQUE CHECK (passport_number ~ '^\d{4} \d{6}$'),
	FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID) ON DELETE CASCADE,
	UNIQUE (Employee_ID, Position)
);

CREATE TABLE IF NOT EXISTS Doctor (
	Employee_ID INT PRIMARY KEY,
	Position INT NOT NULL CHECK (Position = 1),
	Specialization VARCHAR(50) NOT NULL,
	Certificate_number VARCHAR(14) UNIQUE CHECK (Certificate_number ~ '^\d{6} \d{7}$'),
	Academic_degree VARCHAR(50) NOT NULL,
	Qualification INT NOT NULL CHECK (Qualification IN (1,2,3)), -- 1 первая, 2 вторая, 3 высшая
	Rank VARCHAR(50) NOT NULL, -- должность (зав. отделения, глав врач и прочие)
	FOREIGN KEY (Employee_ID, Position) REFERENCES Employee (Employee_ID, Position) ON DELETE CASCADE
);
CREATE OR REPLACE VIEW Employee_Doctor AS 
SELECT
	e.Employee_ID,
	e.Name,
	e.Patronymic,
	e.Surname,
	e.Gender,
	e.Date_of_birth,
	e.Phone_number,
	e.Position,
	e.Department_ID,
	e.Passport_number,
	d.Specialization,
	d.Certificate_number,
	d.Academic_degree,
	d.Qualification,
	d.Rank
FROM Employee e JOIN Doctor d ON e.Employee_ID = d.Employee_ID;

CREATE TABLE IF NOT EXISTS Nurse (
	Employee_ID INT PRIMARY KEY,
	Position INT NOT NULL CHECK (Position = 2),
	Certificate_number VARCHAR(14) UNIQUE CHECK (Certificate_number ~ '^\d{6} \d{7}$'),
	Qualification INT NOT NULL CHECK (Qualification IN (1,2,3)), -- 1 первая, 2 вторая, 3 высшая
	Rank VARCHAR(50) NOT NULL, -- должность
	FOREIGN KEY (Employee_ID, Position) REFERENCES Employee (Employee_ID, Position) ON DELETE CASCADE
);

CREATE OR REPLACE VIEW Employee_Nurse AS 
SELECT
	e.Employee_ID,
	e.Name,
	e.Patronymic,
	e.Surname,
	e.Gender,
	e.Date_of_birth,
	e.Phone_number,
	e.Position,
	e.Department_ID,
	e.Passport_number,
	n.Certificate_number,
	n.Qualification,
	n.Rank
FROM Employee e JOIN Nurse n ON e.Employee_ID = n.Employee_ID;

CREATE TABLE IF NOT EXISTS Sanitar (
	Employee_ID INT PRIMARY KEY,
	Position INT NOT NULL CHECK (Position = 3),
	Admission BIT NOT NULL,
	FOREIGN KEY (Employee_ID, Position) REFERENCES Employee (Employee_ID, Position) ON DELETE CASCADE
);

CREATE OR REPLACE VIEW Employee_Sanitar AS 
SELECT
	e.Employee_ID,
	e.Name,
	e.Patronymic,
	e.Surname,
	e.Gender,
	e.Date_of_birth,
	e.Phone_number,
	e.Position,
	e.Department_ID,
	e.Passport_number,
	s.Admission
FROM Employee e JOIN Sanitar s ON e.Employee_ID = s.Employee_ID;

CREATE TABLE IF NOT EXISTS Ward (
	Ward_ID SERIAL PRIMARY KEY,
	Bed_count INT NOT NULL,
	VIP_status BIT NOT NULL, -- 1 VIP, 0 нет
	Isolation_status VARCHAR(50) NOT NULL,
	Ward_number INT NOT NULL,
	Department_ID INT NOT NULL,
	FOREIGN KEY (Department_ID) REFERENCES Department (Department_ID) ON DELETE CASCADE,
	UNIQUE (Department_ID, Ward_number)
);

CREATE TABLE IF NOT EXISTS Work_schedule (
	Schedule_ID SERIAL PRIMARY KEY,
	Employee_ID INT NOT NULL,
	Schedule JSONB NOT NULL,
	FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Patient (
	Patient_ID SERIAL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Surname VARCHAR(50) NOT NULL,
	Patronymic VARCHAR(50),
	Gender BIT NOT NULL, -- 1 - мужчина, 0 - женщина
	Date_of_birth DATE NOT NULL,
	Polys_number VARCHAR(16) CHECK (Polys_number ~ '^\d{16}$'),
	SNILS VARCHAR(14) UNIQUE CHECK (snils ~ '^\d{3}-\d{3}-\d{3}-\d{2}$'),
	Passport_number VARCHAR(11) NOT NULL UNIQUE CHECK (passport_number ~ '^\d{4} \d{6}$')
);

CREATE TABLE IF NOT EXISTS Anamnesis (
	Anamnesis_ID SERIAL PRIMARY KEY,
	Date_of_arrive DATE NOT NULL,
	Date_of_discharge DATE NULL,
	Medical_history TEXT NOT NULL,
	Complaints TEXT NOT NULL,
	Allergies JSONB NOT NULL,
	Bad_habits JSONB NOT NULL,
	Blood_pressure_low INT NOT NULL,
	Blood_pressure_high INT NOT NULL,
	Pulse INT NOT NULL,
	Saturation INT NOT NULL,
	Skin TEXT NOT NULL,
	Mucosal TEXT NOT NULL,
	Thermometry NUMERIC(3,1) NOT NULL,
	Ward_ID INT NULL,
	Admitting_doctor_ID INT NOT NULL,
	Attending_doctor_ID INT NOT NULL,
	Patient_ID INT NOT NULL,
	FOREIGN KEY (Ward_ID) REFERENCES Ward (Ward_ID) ON DELETE CASCADE,
	FOREIGN KEY (Admitting_doctor_ID) REFERENCES Doctor(Employee_ID) ON DELETE CASCADE,
	FOREIGN KEY (Attending_doctor_ID) REFERENCES Doctor(Employee_ID) ON DELETE CASCADE,
	FOREIGN KEY (Patient_ID) REFERENCES Patient(Patient_ID) ON DELETE CASCADE
);

INSERT INTO Department (Floor_number, Inner_phone, Department_name) VALUES
(1, '+7-901-100-11-11', 'Кардиологическое отделение'),
(2, '+7-901-100-22-22', 'Неврологическое отделение'),
(3, '+7-901-100-33-33', 'Травматологическое отделение'),
(4, '+7-901-100-44-44', 'Хирургическое отделение'),
(1, '+7-901-100-55-55', 'Терапевтическое отделение'),
(2, '+7-901-100-66-66', 'Детское отделение'),
(3, '+7-901-100-77-77', 'Гинекологическое отделение'),
(4, '+7-901-100-88-88', 'Урологическое отделение'),
(1, '+7-901-100-99-99', 'Офтальмологическое отделение'),
(2, '+7-901-200-00-00', 'Отоларингологическое отделение'),
(3, '+7-901-200-11-11', 'Реанимационное отделение');

DO $$
DECLARE
    dept RECORD;
    ward_num INT;
    bed_count INT;
    vip BIT;
BEGIN
    FOR dept IN SELECT Department_ID FROM Department LOOP
        FOR ward_num IN 1..(3 + floor(random() * 3)) LOOP
            bed_count := 2 + (random() * 4)::INT;
            vip := CASE WHEN random() > 0.8 THEN B'1' ELSE B'0' END;
            
            INSERT INTO Ward (Bed_count, VIP_status, Isolation_status, Ward_number, Department_ID)
            VALUES (
                bed_count, 
                vip, 
                CASE (random() * 3)::INT
                    WHEN 0 THEN 'Нет'
                    WHEN 1 THEN 'Низкая'
                    WHEN 2 THEN 'Средняя'
                    ELSE 'Высокая'
                END,
                ward_num,
                dept.Department_ID
            );
        END LOOP;
    END LOOP;
END $$;

DO $$
DECLARE
    i INT;
    names TEXT[] := ARRAY['Александр', 'Дмитрий', 'Максим', 'Сергей', 'Андрей', 'Алексей', 'Владимир', 'Евгений', 'Михаил', 'Николай', 'Иван', 'Петр', 'Павел', 'Роман', 'Артем', 'Денис', 'Вячеслав', 'Григорий', 'Юрий', 'Василий'];
    surnames TEXT[] := ARRAY['Иванов', 'Смирнов', 'Кузнецов', 'Попов', 'Васильев', 'Петров', 'Соколов', 'Михайлов', 'Новиков', 'Федоров', 'Морозов', 'Волков', 'Алексеев', 'Лебедев', 'Семенов', 'Егоров', 'Павлов', 'Козлов', 'Степанов', 'Николаев'];
    patronymics TEXT[] := ARRAY['Иванович', 'Петрович', 'Сергеевич', 'Александрович', 'Владимирович', 'Дмитриевич', 'Алексеевич', 'Михайлович', 'Николаевич', 'Андреевич'];
    f_names TEXT[] := ARRAY['Анна', 'Елена', 'Мария', 'Татьяна', 'Ольга', 'Наталья', 'Светлана', 'Ирина', 'Юлия', 'Екатерина', 'Евгения', 'Валентина', 'Людмила', 'Надежда', 'Вера', 'Ксения', 'Виктория', 'Анастасия', 'Дарья', 'Полина'];
    f_surnames TEXT[] := ARRAY['Иванова', 'Смирнова', 'Кузнецова', 'Попова', 'Васильева', 'Петрова', 'Соколова', 'Михайлова', 'Новикова', 'Федорова', 'Морозова', 'Волкова', 'Алексеева', 'Лебедева', 'Семенова', 'Егорова', 'Павлова', 'Козлова', 'Степанова', 'Николаева'];
    f_patronymics TEXT[] := ARRAY['Ивановна', 'Петровна', 'Сергеевна', 'Александровна', 'Владимировна', 'Дмитриевна', 'Алексеевна', 'Михайловна', 'Николаевна', 'Андреевна'];
    is_male BOOLEAN;
    gender_bit BIT;
    pos INT;
    emp_id INT;
BEGIN
    FOR i IN 1..60 LOOP
        is_male := random() > 0.4;
        gender_bit := CASE WHEN is_male THEN B'1' ELSE B'0' END;
        pos := 1;
        
        INSERT INTO Employee (Name, Patronymic, Surname, Gender, Date_of_birth, Phone_number, Position, Department_ID, Passport_number)
        VALUES (
            CASE WHEN is_male THEN names[1 + (random() * 19)::INT] ELSE f_names[1 + (random() * 19)::INT] END,
            CASE WHEN is_male THEN patronymics[1 + (random() * 9)::INT] ELSE f_patronymics[1 + (random() * 9)::INT] END,
            CASE WHEN is_male THEN surnames[1 + (random() * 19)::INT] ELSE f_surnames[1 + (random() * 19)::INT] END,
            gender_bit,
            DATE '1960-01-01' + (random() * 14600)::INT,
            '+7-9' || LPAD((10000000 + (random() * 90000000)::INT)::TEXT, 9, '0'),
            pos,
            (SELECT Department_ID FROM Department ORDER BY random() LIMIT 1),
            LPAD((random() * 9999)::INT::TEXT, 4, '0') || ' ' || LPAD((random() * 999999)::INT::TEXT, 6, '0')
        ) RETURNING Employee_ID INTO emp_id;
        
        INSERT INTO Doctor (Employee_ID, Position, Specialization, Certificate_number, Academic_degree, Qualification, Rank)
        VALUES (
            emp_id,
            1,
            CASE (random() * 5)::INT
                WHEN 0 THEN 'Кардиолог'
                WHEN 1 THEN 'Невролог'
                WHEN 2 THEN 'Травматолог'
                WHEN 3 THEN 'Хирург'
                WHEN 4 THEN 'Терапевт'
                ELSE 'Офтальмолог'
            END,
            LPAD((random() * 999999)::INT::TEXT, 6, '0') || ' ' || LPAD((random() * 9999999)::INT::TEXT, 7, '0'),
            CASE (random() * 2)::INT
                WHEN 0 THEN 'Кандидат медицинских наук'
                ELSE 'Доктор медицинских наук'
            END,
            (random() * 2)::INT + 1,
            CASE (random() * 3)::INT
                WHEN 0 THEN 'Врач'
                WHEN 1 THEN 'Заведующий отделением'
                ELSE 'Главный врач отделения'
            END
        );
    END LOOP;

    FOR i IN 1..100 LOOP
        is_male := random() > 0.85;
        gender_bit := CASE WHEN is_male THEN B'1' ELSE B'0' END;
        pos := 2;
        
        INSERT INTO Employee (Name, Patronymic, Surname, Gender, Date_of_birth, Phone_number, Position, Department_ID, Passport_number)
        VALUES (
            CASE WHEN is_male THEN names[1 + (random() * 19)::INT] ELSE f_names[1 + (random() * 19)::INT] END,
            CASE WHEN is_male THEN patronymics[1 + (random() * 9)::INT] ELSE f_patronymics[1 + (random() * 9)::INT] END,
            CASE WHEN is_male THEN surnames[1 + (random() * 19)::INT] ELSE f_surnames[1 + (random() * 19)::INT] END,
            gender_bit,
            DATE '1970-01-01' + (random() * 14600)::INT,
            '+7-9' || LPAD((10000000 + (random() * 90000000)::INT)::TEXT, 9, '0'),
            pos,
            (SELECT Department_ID FROM Department ORDER BY random() LIMIT 1),
            LPAD((random() * 9999)::INT::TEXT, 4, '0') || ' ' || LPAD((random() * 999999)::INT::TEXT, 6, '0')
        ) RETURNING Employee_ID INTO emp_id;
        
        INSERT INTO Nurse (Employee_ID, Position, Certificate_number, Qualification, Rank)
        VALUES (
            emp_id,
            2,
            LPAD((random() * 999999)::INT::TEXT, 6, '0') || ' ' || LPAD((random() * 9999999)::INT::TEXT, 7, '0'),
            (random() * 2)::INT + 1,
            CASE (random() * 2)::INT
                WHEN 0 THEN 'Медсестра'
                ELSE 'Старшая медсестра'
            END
        );
    END LOOP;
    FOR i IN 1..50 LOOP
        is_male := random() > 0.5;
        gender_bit := CASE WHEN is_male THEN B'1' ELSE B'0' END;
        pos := 3;
        
        INSERT INTO Employee (Name, Patronymic, Surname, Gender, Date_of_birth, Phone_number, Position, Department_ID, Passport_number)
        VALUES (
            CASE WHEN is_male THEN names[1 + (random() * 19)::INT] ELSE f_names[1 + (random() * 19)::INT] END,
            CASE WHEN is_male THEN patronymics[1 + (random() * 9)::INT] ELSE f_patronymics[1 + (random() * 9)::INT] END,
            CASE WHEN is_male THEN surnames[1 + (random() * 19)::INT] ELSE f_surnames[1 + (random() * 19)::INT] END,
            gender_bit,
            DATE '1975-01-01' + (random() * 14600)::INT,
            '+7-9' || LPAD((10000000 + (random() * 90000000)::INT)::TEXT, 9, '0'),
            pos,
            (SELECT Department_ID FROM Department ORDER BY random() LIMIT 1),
            LPAD((random() * 9999)::INT::TEXT, 4, '0') || ' ' || LPAD((random() * 999999)::INT::TEXT, 6, '0')
        ) RETURNING Employee_ID INTO emp_id;
        
        INSERT INTO Sanitar (Employee_ID, Position, Admission)
        VALUES (emp_id, 3, CASE WHEN random() > 0.1 THEN B'1' ELSE B'0' END);
    END LOOP;
END $$;
DO $$
DECLARE
    i INT;
    names TEXT[] := ARRAY['Александр', 'Дмитрий', 'Максим', 'Сергей', 'Андрей', 'Алексей', 'Владимир', 'Евгений', 'Михаил', 'Николай', 'Иван', 'Петр', 'Павел', 'Роман', 'Артем', 'Денис', 'Вячеслав', 'Григорий', 'Юрий', 'Василий'];
    surnames TEXT[] := ARRAY['Иванов', 'Смирнов', 'Кузнецов', 'Попов', 'Васильев', 'Петров', 'Соколов', 'Михайлов', 'Новиков', 'Федоров', 'Морозов', 'Волков', 'Алексеев', 'Лебедев', 'Семенов', 'Егоров', 'Павлов', 'Козлов', 'Степанов', 'Николаев'];
    patronymics TEXT[] := ARRAY['Иванович', 'Петрович', 'Сергеевич', 'Александрович', 'Владимирович', 'Дмитриевич', 'Алексеевич', 'Михайлович', 'Николаевич', 'Андреевич'];
    f_names TEXT[] := ARRAY['Анна', 'Елена', 'Мария', 'Татьяна', 'Ольга', 'Наталья', 'Светлана', 'Ирина', 'Юлия', 'Екатерина', 'Евгения', 'Валентина', 'Людмила', 'Надежда', 'Вера', 'Ксения', 'Виктория', 'Анастасия', 'Дарья', 'Полина'];
    f_surnames TEXT[] := ARRAY['Иванова', 'Смирнова', 'Кузнецова', 'Попова', 'Васильева', 'Петрова', 'Соколова', 'Михайлова', 'Новикова', 'Федорова', 'Морозова', 'Волкова', 'Алексеева', 'Лебедева', 'Семенова', 'Егорова', 'Павлова', 'Козлова', 'Степанова', 'Николаева'];
    f_patronymics TEXT[] := ARRAY['Ивановна', 'Петровна', 'Сергеевна', 'Александровна', 'Владимировна', 'Дмитриевна', 'Алексеевна', 'Михайловна', 'Николаевна', 'Андреевна'];
    is_male BOOLEAN;
    gender_bit BIT;
    polys_number TEXT;
    snils TEXT;
BEGIN
    FOR i IN 1..50000 LOOP
        is_male := random() > 0.48;
        gender_bit := CASE WHEN is_male THEN B'1' ELSE B'0' END;
        
        polys_number := LPAD((random() * 9999999999999999)::BIGINT::TEXT, 16, '0');
        
        snils := LPAD((random() * 999)::INT::TEXT, 3, '0') || '-' ||
                 LPAD((random() * 999)::INT::TEXT, 3, '0') || '-' ||
                 LPAD((random() * 999)::INT::TEXT, 3, '0') || '-' ||
                 LPAD((random() * 99)::INT::TEXT, 2, '0');
        
        INSERT INTO Patient (Name, Surname, Patronymic, Gender, Date_of_birth, Polys_number, SNILS, Passport_number)
        VALUES (
            CASE WHEN is_male THEN names[1 + (random() * 19)::INT] ELSE f_names[1 + (random() * 19)::INT] END,
            CASE WHEN is_male THEN surnames[1 + (random() * 19)::INT] ELSE f_surnames[1 + (random() * 19)::INT] END,
            CASE WHEN is_male THEN patronymics[1 + (random() * 9)::INT] ELSE f_patronymics[1 + (random() * 9)::INT] END,
            gender_bit,
            DATE '1930-01-01' + (random() * 30000)::INT,
            polys_number,
            snils,
            LPAD((random() * 9999)::INT::TEXT, 4, '0') || ' ' || LPAD((random() * 999999)::INT::TEXT, 6, '0')
        );
    END LOOP;
END $$;

DO $$
DECLARE
    patient RECORD;
    anamnesis_count INT;
    v_ward_id INT;
    admitting_doctor_id INT;
    attending_doctor_id INT;
    allergies_json JSONB;
    bad_habits_json JSONB;
    allergies_list TEXT[] := ARRAY['Пыльца', 'Пенициллин', 'Орехи', 'Лактоза', 'Цитрусовые', 'Кошачья шерсть', 'Домашняя пыль', 'Яйца', 'Морепродукты', 'Шоколад'];
    bad_habits_list TEXT[] := ARRAY['Курение', 'Алкоголь', 'Наркотики', 'Переедание', 'Малоподвижный образ жизни'];
    skin_conditions TEXT[] := ARRAY['Чистая', 'Сухая', 'Влажная', 'Высыпания', 'Покраснения', 'Цианоз', 'Желтушность'];
    mucosal_conditions TEXT[] := ARRAY['Влажные', 'Сухие', 'Гиперемированы', 'Цианотичные', 'Бледные', 'Налет'];
    i INT;
    selected_allergies TEXT[];
    selected_habits TEXT[];
    arrive_date DATE;
    discharge_date DATE;
    last_arrive_date DATE := CURRENT_DATE - 730;
    available_wards INT[];
    ward_index INT;
BEGIN
    FOR patient IN SELECT Patient_ID FROM Patient LOOP
        anamnesis_count := 1 + (random() * 2)::INT;
        
        FOR i IN 1..anamnesis_count LOOP
            IF i = anamnesis_count AND random() > 0.3 THEN
                SELECT array_agg(Ward_ID) INTO available_wards
                FROM (
                    SELECT w.Ward_ID
                    FROM Ward w
                    LEFT JOIN Anamnesis a ON w.Ward_ID = a.Ward_ID AND a.Date_of_discharge IS NULL
                    GROUP BY w.Ward_ID, w.Bed_count
                    HAVING COUNT(a.Anamnesis_ID) < w.Bed_count
                ) sub;
                
                IF available_wards IS NOT NULL AND array_length(available_wards, 1) > 0 THEN
                    ward_index := 1 + (random() * (array_length(available_wards, 1) - 1))::INT;
                    v_ward_id := available_wards[ward_index];
                ELSE
                    v_ward_id := NULL;
                END IF;
                
                arrive_date := last_arrive_date + (random() * 30)::INT;
                discharge_date := NULL;
            ELSE
                SELECT Ward_ID INTO v_ward_id FROM Ward ORDER BY random() LIMIT 1;
                arrive_date := last_arrive_date + (random() * 60)::INT;
                discharge_date := arrive_date + (random() * 30)::INT + 1;
            END IF;
            
            last_arrive_date := arrive_date;
            
            SELECT Employee_ID INTO admitting_doctor_id FROM Doctor ORDER BY random() LIMIT 1;
            SELECT Employee_ID INTO attending_doctor_id FROM Doctor ORDER BY random() LIMIT 1;
            
            SELECT array_agg(allergen) INTO selected_allergies
            FROM unnest(allergies_list) AS allergen
            WHERE random() < 0.3
            LIMIT (random() * 3)::INT + 1;
            
            IF selected_allergies IS NULL THEN
                allergies_json := '[]'::JSONB;
            ELSE
                allergies_json := to_jsonb(selected_allergies);
            END IF;
            
            SELECT array_agg(habit) INTO selected_habits
            FROM unnest(bad_habits_list) AS habit
            WHERE random() < 0.4
            LIMIT (random() * 2)::INT + 1;
            
            IF selected_habits IS NULL THEN
                bad_habits_json := '[]'::JSONB;
            ELSE
                bad_habits_json := to_jsonb(selected_habits);
            END IF;
            
            INSERT INTO Anamnesis (
                Date_of_arrive, Date_of_discharge, Medical_history, Complaints, 
                Allergies, Bad_habits, Blood_pressure_low, Blood_pressure_high, 
                Pulse, Saturation, Skin, Mucosal, Thermometry,
                Ward_ID, Admitting_doctor_ID, Attending_doctor_ID, Patient_ID
            ) VALUES (
                arrive_date,
                discharge_date,
                CASE (random() * 4)::INT
                    WHEN 0 THEN 'Гипертоническая болезнь 2 ст.'
                    WHEN 1 THEN 'Ишемическая болезнь сердца'
                    WHEN 2 THEN 'Острый бронхит'
                    WHEN 3 THEN 'Внебольничная пневмония'
                    ELSE 'Остеохондроз позвоночника'
                END,
                CASE (random() * 4)::INT
                    WHEN 0 THEN 'Жалобы на головные боли, слабость'
                    WHEN 1 THEN 'Кашель, одышка, температура 38'
                    WHEN 2 THEN 'Боли в грудной клетке, сердцебиение'
                    WHEN 3 THEN 'Тошнота, головокружение'
                    ELSE 'Ломота в теле, утомляемость'
                END,
                allergies_json,
                bad_habits_json,
                100 + (random() * 40)::INT,
                60 + (random() * 50)::INT,
                60 + (random() * 40)::INT,
                90 + (random() * 8)::INT,
                skin_conditions[1 + (random() * 6)::INT],
                mucosal_conditions[1 + (random() * 5)::INT],
                36.0 + (random() * 2.5),
                v_ward_id,
                admitting_doctor_id,
                attending_doctor_id,
                patient.Patient_ID
            );
        END LOOP;
    END LOOP;
END $$;

SELECT 'Department' AS table_name, COUNT(*) FROM Department
UNION ALL SELECT 'Employee', COUNT(*) FROM Employee
UNION ALL SELECT 'Doctor', COUNT(*) FROM Doctor
UNION ALL SELECT 'Nurse', COUNT(*) FROM Nurse
UNION ALL SELECT 'Sanitar', COUNT(*) FROM Sanitar
UNION ALL SELECT 'Ward', COUNT(*) FROM Ward
UNION ALL SELECT 'Patient', COUNT(*) FROM Patient
UNION ALL SELECT 'Anamnesis', COUNT(*) FROM Anamnesis;

-- Расширение для триграммного поиска
CREATE EXTENSION IF NOT EXISTS pg_trgm;

-- ========== Индексы для Employee ==========
CREATE INDEX idx_employee_surname ON Employee (Surname);
CREATE INDEX idx_employee_passport ON Employee (Passport_number);
CREATE INDEX idx_employee_department ON Employee (Department_ID);
CREATE INDEX idx_employee_position ON Employee (Position);

-- Триграммные индексы для поиска по ФИО
CREATE INDEX idx_employee_surname_trgm ON Employee USING GIN (Surname gin_trgm_ops);
CREATE INDEX idx_employee_name_trgm ON Employee USING GIN (Name gin_trgm_ops);

-- ========== Индексы для Patient ==========
CREATE INDEX idx_patient_surname ON Patient (Surname);
CREATE INDEX idx_patient_passport_trgm ON Patient USING GIN (Passport_number gin_trgm_ops);
CREATE INDEX idx_patient_snils ON Patient (SNILS);

-- Триграммные индексы для поиска по ФИО
CREATE INDEX idx_patient_surname_trgm ON Patient USING GIN (Surname gin_trgm_ops);
CREATE INDEX idx_patient_name_trgm ON Patient USING GIN (Name gin_trgm_ops);
CREATE INDEX idx_patient_patronymic_trgm ON Patient USING GIN (Patronymic gin_trgm_ops);

-- ========== Индексы для Anamnesis ==========
CREATE INDEX idx_anamnesis_patient ON Anamnesis (Patient_ID);
CREATE INDEX idx_anamnesis_ward ON Anamnesis (Ward_ID);
CREATE INDEX idx_anamnesis_discharge ON Anamnesis (Date_of_discharge);
CREATE INDEX idx_anamnesis_date_arrive ON Anamnesis (Date_of_arrive);
CREATE INDEX idx_anamnesis_ward_discharge ON Anamnesis (Ward_ID, Date_of_discharge);
CREATE INDEX idx_anamnesis_admitting_doctor ON Anamnesis (Admitting_doctor_ID);
CREATE INDEX idx_anamnesis_attending_doctor ON Anamnesis (Attending_doctor_ID);

-- JSONB индекс для поиска по аллергиям
CREATE INDEX idx_anamnesis_allergies ON Anamnesis USING GIN (Allergies);

-- ========== Индексы для Ward ==========
CREATE INDEX idx_ward_department ON Ward (Department_ID);

-- ========== Индексы для Work_schedule ==========
CREATE INDEX idx_workschedule_employee ON Work_schedule (Employee_ID);

/*
DROP INDEX IF EXISTS idx_employee_surname;
DROP INDEX IF EXISTS idx_employee_passport;
DROP INDEX IF EXISTS idx_employee_department;
DROP INDEX IF EXISTS idx_employee_position;
DROP INDEX IF EXISTS idx_patient_surname;
DROP INDEX IF EXISTS idx_patient_passport_trgm;
DROP INDEX IF EXISTS idx_patient_snils;
DROP INDEX IF EXISTS idx_anamnesis_patient;
DROP INDEX IF EXISTS idx_anamnesis_ward;
DROP INDEX IF EXISTS idx_anamnesis_discharge;
DROP INDEX IF EXISTS idx_anamnesis_date_arrive;
DROP INDEX IF EXISTS idx_anamnesis_ward_discharge;
DROP INDEX IF EXISTS idx_anamnesis_admitting_doctor;
DROP INDEX IF EXISTS idx_anamnesis_attending_doctor;
DROP INDEX IF EXISTS idx_anamnesis_allergies;
DROP INDEX IF EXISTS idx_ward_department;
DROP INDEX IF EXISTS idx_workschedule_employee;
DROP INDEX IF EXISTS idx_patient_surname_trgm;
DROP INDEX IF EXISTS idx_patient_name_trgm;
DROP INDEX IF EXISTS idx_patient_patronymic_trgm;
DROP INDEX IF EXISTS idx_employee_surname_trgm;
DROP INDEX IF EXISTS idx_employee_name_trgm;
*/

EXPLAIN (ANALYZE, BUFFERS, TIMING) 
SELECT 
    e.Employee_ID,
    e.Surname,
    e.Name,
    e.Patronymic,
    CASE WHEN e.Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Gender,
    e.Date_of_birth,
    e.Phone_number,
    CASE e.Position 
        WHEN 1 THEN 'Доктор' 
        WHEN 2 THEN 'Медсестра' 
        WHEN 3 THEN 'Санитар' 
    END AS Position,
    d.Department_name,
    e.Passport_number
FROM Employee e
JOIN Department d ON e.Department_ID = d.Department_ID
ORDER BY e.Surname, e.Name;

EXPLAIN (ANALYZE, BUFFERS, TIMING) 
SELECT 
    e.Employee_ID,
    e.Surname,
    e.Name,
    e.Patronymic,
    CASE WHEN e.Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Gender,
    e.Date_of_birth,
    e.Phone_number,
    CASE e.Position 
        WHEN 1 THEN 'Доктор' 
        WHEN 2 THEN 'Медсестра' 
        WHEN 3 THEN 'Санитар' 
    END AS Position,
    d.Department_name,
    e.Passport_number
FROM Employee e
JOIN Department d ON e.Department_ID = d.Department_ID
WHERE e.Surname ILIKE '%ов%'
ORDER BY e.Surname, e.Name;

EXPLAIN (ANALYZE, BUFFERS, TIMING) 
SELECT 
    Surname,
    Name,
    Patronymic,
    CASE WHEN Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Gender,
    Date_of_birth,
    Polys_number,
    SNILS,
    Passport_number
FROM Patient
ORDER BY Surname, Name;

EXPLAIN (ANALYZE, BUFFERS, TIMING) 
SELECT 
    Surname,
    Name,
    Patronymic,
    CASE WHEN Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Gender,
    Date_of_birth,
    Polys_number,
    SNILS,
    Passport_number
FROM Patient
WHERE Surname ILIKE '%иван%' 
   OR Name ILIKE '%иван%' 
   OR Patronymic ILIKE '%иван%'
ORDER BY Surname, Name;

EXPLAIN (ANALYZE, BUFFERS, TIMING) 
SELECT 
    Surname,
    Name,
    Patronymic,
    CASE WHEN Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Gender,
    Date_of_birth,
    Polys_number,
    SNILS,
    Passport_number
FROM Patient
WHERE Passport_number ILIKE '%1234%';
--TRUNCATE Department, Employee, Doctor, Nurse, Sanitar, Ward, Work_Schedule, Anamnesis, Patient RESTART IDENTITY CASCADE;
/*

ALTER TABLE Employee 
DROP CONSTRAINT employee_department_id_fkey,
ADD CONSTRAINT employee_department_id_fkey 
FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID) ON DELETE CASCADE;


-- Department → Ward
ALTER TABLE Ward 
DROP CONSTRAINT ward_department_id_fkey,
ADD CONSTRAINT ward_department_id_fkey 
FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID) ON DELETE CASCADE;

-- Employee → Work_schedule
ALTER TABLE Work_schedule 
DROP CONSTRAINT work_schedule_employee_id_fkey,
ADD CONSTRAINT work_schedule_employee_id_fkey 
FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID) ON DELETE CASCADE;

-- Ward → Anamnesis
ALTER TABLE Anamnesis 
DROP CONSTRAINT anamnesis_ward_id_fkey,
ADD CONSTRAINT anamnesis_ward_id_fkey 
FOREIGN KEY (Ward_ID) REFERENCES Ward(Ward_ID) ON DELETE CASCADE;

-- Doctor → Anamnesis (Admitting_doctor_ID)
ALTER TABLE Anamnesis 
-- DROP CONSTRAINT anamnesis_admitting_doctor_id_fkey,
ADD CONSTRAINT anamnesis_admitting_doctor_id_fkey 
FOREIGN KEY (Admitting_doctor_ID) REFERENCES Doctor(Employee_ID) ON DELETE CASCADE;

-- Doctor → Anamnesis (Attending_doctor_ID)
ALTER TABLE Anamnesis 
--DROP CONSTRAINT anamnesis_attending_doctor_id_fkey,
ADD CONSTRAINT anamnesis_attending_doctor_id_fkey 
FOREIGN KEY (Attending_doctor_ID) REFERENCES Doctor(Employee_ID) ON DELETE CASCADE;

-- Patient → Anamnesis
ALTER TABLE Anamnesis 
DROP CONSTRAINT anamnesis_patient_id_fkey,
ADD CONSTRAINT anamnesis_patient_id_fkey 
FOREIGN KEY (Patient_ID) REFERENCES Patient(Patient_ID) ON DELETE CASCADE;

TRUNCATE Department, Employee, Doctor, Nurse, Sanitar, Ward, Work_Schedule, Anamnesis, Patient RESTART IDENTITY CASCADE;
*/