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