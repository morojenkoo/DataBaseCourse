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
	FOREIGN KEY (Department_ID) REFERENCES Department(Department_ID),
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
	Isolation_status INT NOT NULL, -- по уровню изоляции от 0 (не изоляции) до N (максимальная изоляция)
	Ward_number INT NOT NULL,
	Department_ID INT NOT NULL,
	FOREIGN KEY (Department_ID) REFERENCES Department (Department_ID),
	UNIQUE (Department_ID, Ward_number)
);

CREATE TABLE IF NOT EXISTS Work_schedule (
	Schedule_ID SERIAL PRIMARY KEY,
	Employee_ID INT NOT NULL,
	Schedule JSONB NOT NULL,
	FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
);

CREATE TABLE IF NOT EXISTS Patient (
	Patient_ID SERIAL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Surname VARCHAR(50) NOT NULL,
	Patronymic VARCHAR(50),
	Gender BIT NOT NULL,
	Date_of_birth DATE NOT NULL,
	Polys_number VARCHAR(16) CHECK (Polys_number ~ '^\d{16}$'),
	SNILS VARCHAR(14) UNIQUE CHECK (snils ~ '^\d{3}-\d{3}-\d{3}-\d{2}$'),
	Passport_number VARCHAR(11) NOT NULL UNIQUE CHECK (passport_number ~ '^\d{4} \d{6}$')
);

CREATE TABLE IF NOT EXISTS Anamnesis (
	Anamnesis_ID SERIAL PRIMARY KEY,
	Date_of_arrive DATE NOT NULL,
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
	Ward_ID INT NOT NULL,
	Admitting_doctor_ID INT NOT NULL,
	Attending_doctor_ID INT NOT NULL,
	Patient_ID INT NOT NULL,
	FOREIGN KEY (Ward_ID) REFERENCES Ward (Ward_ID),
	FOREIGN KEY (Admitting_doctor_ID) REFERENCES Doctor(Employee_ID),
	FOREIGN KEY (Attending_doctor_ID) REFERENCES Doctor(Employee_ID),
	FOREIGN KEY (Patient_ID) REFERENCES Patient(Patient_ID)
);
TRUNCATE Department, Employee, Doctor, Nurse, Sanitar, Ward, Work_Schedule, Anamnesis, Patient RESTART IDENTITY CASCADE;
/*
TRUNCATE Department, Employee, Doctor, Nurse, Sanitar, Ward, Work_Schedule, Anamnesis, Patient RESTART IDENTITY CASCADE;


INSERT INTO Department (Floor_number, Inner_phone, Department_name) VALUES
	(1, '+7-901-000-00-00', 'Хирургическое отделение'),
	(1, '+7-902-000-00-00', 'Детское отделение');
	
INSERT INTO Employee (Name, Patronymic, Surname, Gender, Date_of_birth, Phone_number, 
	Position, Department_ID, Passport_number) VALUES
	('Дмитрий', 'Сергеевич', 'Козинец', '1', '2006-02-15', '+7-968-412-73-88', 1, 1, '4619 693139'),
	('Беляев', 'Игорь', 'Евгеньевич', '0', '2005-05-04', '+7-911-111-11-11', 2, 1, '1234 123456'),
	('Амбросий', 'Николай', 'Евгеньевич', '1', '2005-10-11', '+7-922-222-22-22', 3, 2, '4321 654321');
	
INSERT INTO Doctor (Employee_ID, Position, Specialization, Certificate_number, Academic_degree, 
	Qualification, Rank) VALUES
	(1, 1, 'Хирург-травмотолог', '000000 0000000', 'Доктор наук', 3, 'Глав-врач');

INSERT INTO Nurse (Employee_ID, Position, Certificate_number, Qualification, Rank) VALUES
	(2, 2, '111111 1111111', 3, 'Старшая медсестра');

INSERT INTO Sanitar (Employee_ID, Position, Admission) VALUES
	(3, 3, '1');

INSERT INTO Ward (Bed_count, VIP_status, Isolation_status, Ward_number, Department_ID) VALUES
	(2, '0', 0, 1, 1);

	
SELECT * FROM Employee_Doctor;
SELECT * FROM Employee_Nurse;
SELECT * FROM Employee_Sanitar;
SELECT * FROM Ward;
*/