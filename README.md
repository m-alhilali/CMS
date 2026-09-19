# 🏥 Clinic Management System (CMS)

A desktop **Clinic Management System** developed to manage the main operations of a medical clinic, including patients, doctors, appointments, consultations, prescriptions, and basic financial transactions.

The project was built with a focus on **clean architecture, data integrity, validation, and practical business rules**.

---

## 📌 About the Project

**CMS (Clinic Management System)** is a desktop application designed to simplify and organize the daily operations of a medical clinic.

The system provides functionality for managing:

- 👤 Patients
- 👨‍⚕️ Doctors
- 📅 Appointments
- 🩺 Consultations
- 💊 Prescriptions
- 💰 Financial transactions
- 🔐 Users and access roles

The project was developed using **C#**, **SQL Server**, **ADO.NET**, and **3-Tier Architecture**.

---

## 🚀 Main Features

### 👤 Patient Management

- Add new patients
- Edit patient information
- Search for patients
- View patient details
- Soft Delete using `IsActive`
- Prevent duplicate patient records

### 👨‍⚕️ Doctor Management

- Add and edit doctors
- Manage doctor specializations
- Activate / deactivate doctors
- Prevent appointments for inactive doctors

### 📅 Appointment Management

- Create new appointments
- Select patient, doctor, and appointment type
- Store the appointment price at the time of booking
- Prevent booking two appointments for the same doctor at the same time
- Prevent appointments with inactive doctors
- Prevent selecting inactive appointment types
- Manage appointment status

### 🩺 Consultation Management

- Attend scheduled appointments
- Create consultation records
- Store diagnosis and notes
- Record consultation date
- Add additional fees
- Link the consultation to the correct appointment

### 💊 Prescription Management

- Add multiple medicines to a consultation
- Select medicines from the available medicines
- Prevent adding inactive medicines
- Store:
  - Dosage
  - Duration
  - Special Instructions
  - Paid Fees
- Support optional dosage and duration values

### 💰 Financial Management

The system provides simplified financial handling based on the actual services provided.

The invoice amount can be calculated from:

```text
Consultation Fee
        +
Total Medicine Fees
        +
Additional Fees
