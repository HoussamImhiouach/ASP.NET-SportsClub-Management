# 🏋️‍♂️ ASP.NET Sports Club Management System

A full-stack **ASP.NET Web Forms** application that streamlines how a sports club manages its operations.  
It supports **member registration**, **training session management**, **payments**, **messaging**, and **role-based dashboards** — all backed by an integrated SQL Server database.

---

## ✨ Highlights

### 🔐 Role-Based Access
- **Admin:** Full control over members, trainings, messages, and payments.  
- **Trainer (Entraîneur):** Create, edit, and assign training sessions to members.  
- **President:** Access an overview of all club activities and data.  
- **Member:** View assigned trainings, messages, and payment history.

### 💪 Core Modules
- **Member Management:** Add, edit, or remove club members.  
- **Training Management:** Create, assign, or unassign training sessions.  
- **Messaging:** In-app inbox/outbox system for user communication.  
- **Payments:** Integrated payment pages with success and cancel states.  
- **Chatbot:** Lightweight helper built into the interface for quick guidance.  
- **Authentication:** Login and signup with role-based redirection.  
- **Database Integration:** SQL scripts included for easy setup and testing.

---

## 🧱 Application Structure

| Section | Key Pages | Description |
|----------|------------|-------------|
| **Authentication & Layout** | `loginsport.aspx`, `signupsport.aspx`, `Site.Master` | Login, registration, and shared layout. |
| **Admin Dashboard** | `AdminDashboard.aspx` | Central management of all club operations. |
| **Trainer Dashboard** | `EntraineurDashboard.aspx`, `AssignTraining.aspx`, `UnassignMember.aspx` | Manage training sessions and member assignments. |
| **President Dashboard** | `PresidentDashboard.aspx` | High-level summary of club performance. |
| **Member Dashboard** | `MemberDashboard.aspx` | Member-specific training and messaging view. |
| **Messaging** | `SendMessage.aspx`, `ReadMessage.aspx`, `ReplyMessage.aspx`, `ViewMessages.aspx` | Two-way messaging between roles. |
| **Payments** | `Payment.aspx`, `PaymentSuccess.aspx`, `PaymentCancel.aspx` | Payment handling and status updates. |
| **Chatbot** | `Chatbot.aspx` | Built-in support assistant for users. |

---

## 🧩 Tech Stack

- **Frontend:** ASP.NET Web Forms  
- **Backend:** C# (Code-Behind)  
- **Database:** SQL Server / LocalDB  
- **IDE:** Visual Studio 2022  
- **Architecture:** Multi-tier Web Forms structure using master pages and reusable components  

---

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 or later (Community Edition or higher)  
- .NET Framework Developer Pack  
- SQL Server / LocalDB instance  

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/HoussamImhiouach/ASP.NET-SportsClub-Management.git
```

### 2️⃣ Open in Visual Studio
Open the solution file (the `.sln` file) and allow NuGet to restore any dependencies automatically.

### 3️⃣ Configure the Database
1. Open **SQL Server Object Explorer** in Visual Studio.  
2. Create a new database (e.g., `ClubManagementDB`).  
3. Run the provided SQL scripts (`SQLQuery1.sql`, `SQLQuery2.sql`, `SQLQuery3.sql`).  
4. Update the connection string in `Web.config` as needed.

### 4️⃣ Run the Application
- Set **IIS Express** as the startup option.  
- Press **F5** or click **Start Debugging**.  
- The site will launch at `https://localhost:<port>/`.

---

## 📂 Project Structure

```
ASP.NET-SportsClub-Management/
├─ App_Code/                     # Shared C# logic (database, utilities)
├─ *.aspx / *.aspx.cs            # Pages and their code-behind files
├─ *.aspx.designer.cs            # Auto-generated layout code
├─ SQLQuery1.sql / SQLQuery2.sql # Database schema and seed data
├─ Site.Master                   # Main site layout
├─ Web.config                    # Configuration (DB connections, auth, etc.)
├─ packages.config               # NuGet dependencies
└─ Solution (.sln) file          # Visual Studio entry point
```

---

## 🧾 Features Overview

### 👥 Members
Add, edit, list, or delete members via the Admin panel.  

### 🏋️ Trainings
Create and assign training sessions; view and manage assigned members.  

### 💬 Messaging
Compose, view, read, and reply to messages within the app.  

### 💳 Payments
Simulate or process payments through success/cancel pages.  

### 🤖 Chatbot
Provides quick assistance directly from the web interface.  

---

## 🧰 Development Notes

- The `.gitignore` already excludes `bin/`, `obj/`, `.vs/`, and other build artifacts.  
- For safety, store sensitive data like API keys and connection strings in `Web.config` or environment variables.  
- Designed to demonstrate CRUD operations, role-based access, and SQL-backed Web Forms logic.

---

## 👨‍💻 Project Info

Developed as part of a professional training project to demonstrate **ASP.NET full-stack capabilities** and **database-driven web architecture**.

---

## 🪪 License

Released for educational and portfolio purposes under the **MIT License**.

---

> 💡 *A complete ASP.NET Web Forms system showing multi-role dashboards, full CRUD logic, messaging, and payments — built with production-like structure and real database integration.*
