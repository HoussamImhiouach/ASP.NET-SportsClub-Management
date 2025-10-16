# 🏋️‍♂️ ASP.NET Sports Club Management (Web Forms)

A role-based **ASP.NET Web Forms** application designed to streamline the management of a sports club.  
It features **member management**, **training assignments**, **payments**, **messaging**, and **role-specific dashboards** — all wrapped in a professional, database-driven web interface.

---

## ✨ Key Highlights

### 🔐 Role-Based Access
Each role has a custom dashboard and permissions:
- **Admin** — Full control over members, trainings, payments, and communications.
- **Trainer (Entraîneur)** — Create, edit, and assign training sessions to members.
- **President** — Oversee club activity with a high-level dashboard.
- **Member** — View assigned trainings, received messages, and payment confirmations.

### 💪 Core Features
- **Member Management:** Add, edit, delete, and list members with relevant details.
- **Training Management:** Create and manage training sessions, assign/unassign members, and view assignments.
- **Messaging System:** In-app inbox/outbox with send, read, and reply functionality.
- **Payment System:** Full payment workflow with success/cancel states.
- **Chatbot Page:** Simple assistance chatbot integrated in `Chatbot.aspx`.
- **Authentication:** Secure login/signup with role detection.
- **SQL Integration:** Includes `.sql` scripts to generate and seed the club database.

---

## 🧩 Application Structure

| Section | Key Pages | Description |
|----------|------------|-------------|
| **Authentication & Layout** | `loginsport.aspx`, `signupsport.aspx`, `Site.Master` | Login, registration, and shared layout. |
| **Admin Dashboard** | `AdminDashboard.aspx` | Central hub for managing all club data. |
| **Trainer Dashboard** | `EntraineurDashboard.aspx`, `AssignTraining.aspx`, `UnassignMember.aspx` | Manage training sessions and member assignments. |
| **President Dashboard** | `PresidentDashboard.aspx` | Overview of the club's performance. |
| **Member Dashboard** | `MemberDashboard.aspx` | View assigned trainings and messages. |
| **Messaging** | `SendMessage.aspx`, `ReadMessage.aspx`, `ReplyMessage.aspx`, `ViewMessages.aspx` | Full in-app communication between users. |
| **Payments** | `Payment.aspx`, `PaymentSuccess.aspx`, `PaymentCancel.aspx` | Payment initiation and status tracking. |
| **Chatbot** | `Chatbot.aspx` | Quick guidance and user assistance. |

---

## 🧱 Technology Stack

- **Framework:** ASP.NET Web Forms (C#)
- **Database:** SQL Server / LocalDB
- **Language:** C# (Code-Behind) and ASP.NET (UI)
- **IDE:** Visual Studio 2022 (Community Edition)
- **Configuration:** `Web.config` for connection strings and environment settings

---

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 (or later)
- .NET Framework Developer Pack
- SQL Server / LocalDB instance

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/HoussamImhiouach/ASP.NET-SportsClub-Management.git
```

### 2️⃣ Open in Visual Studio
- Open the solution file:  
  `ProjetSportFinalHoussamEddneImhiouach.sln`
- Wait for NuGet packages to restore automatically.

### 3️⃣ Configure the Database
1. Open **SQL Server Object Explorer** in Visual Studio.
2. Create a new database named `ClubManagementDB`.
3. Run the provided SQL scripts (`SQLQuery1.sql`, `SQLQuery2.sql`, `SQLQuery3.sql`).
4. Update your `Web.config` connection string as needed.

### 4️⃣ Run the Project
- Select **IIS Express** as the launch option.
- Press **F5** or click ▶ **Start Debugging**.
- The website will launch in your browser (`https://localhost:xxxx/`).

---

## 🧭 Directory Layout

```
ASP.NET-SportsClub-Management/
├─ App_Code/                       # C# classes (Database connections, logic, helpers)
├─ *.aspx / *.aspx.cs              # Web pages and code-behind
├─ *.aspx.designer.cs              # Auto-generated UI code
├─ SQLQuery1.sql / SQLQuery2.sql   # Database schema and seed data
├─ Site.Master                     # Shared layout
├─ Web.config                      # Configuration file (database, auth, etc.)
├─ packages.config                 # NuGet dependencies
└─ ProjetSportFinalHoussamEddneImhiouach.sln  # Solution entry point
```

---

## 🧾 Feature Overview

### 👥 Members
- Add new members with full details.
- Edit, view, or delete existing members.
- Accessible via `ManageMembers.aspx`, `EditMember.aspx`, `DeleteMember.aspx`.

### 🏋️ Trainings
- Create and manage training sessions.
- Assign or unassign members to specific sessions.
- Accessible via `ManageTraining.aspx`, `AssignTraining.aspx`, `UnassignMember.aspx`.

### 💬 Messaging
- In-app chat system.
- Compose, read, and reply to messages between users.
- Accessible via `SendMessage.aspx`, `ViewMessages.aspx`, `ReadMessage.aspx`, `ReplyMessage.aspx`.

### 💳 Payments
- Initiate payments (`Payment.aspx`).
- Display transaction results (`PaymentSuccess.aspx` / `PaymentCancel.aspx`).

### 🤖 Chatbot
- Interactive assistant for users within `Chatbot.aspx`.

### 🧍 Roles
- **Admin:** Complete management of members, trainings, and messages.
- **Trainer:** Create and assign training sessions.
- **President:** View dashboards for global statistics.
- **Member:** Check assignments, send messages, and track payments.

---

## 🧰 Development Notes

- Avoid committing `bin/`, `obj/`, `.vs/`, and other build artifacts (already handled by `.gitignore`).
- Store sensitive data (API keys, DB credentials) securely in `Web.config` or environment variables.
- The project follows a modular Web Forms structure with reusable controls and consistent naming conventions.

---

## 🧑‍💻 Author

**Houssam‑Eddine Imhiouach**  
📍 Montréal, QC, Canada  
💼 [GitHub Profile](https://github.com/HoussamImhiouach)

---

## 🪪 License

This project is released for educational and portfolio purposes.  
You may adapt and reuse it under the **MIT License**.

---

> “A complete ASP.NET Web Forms system demonstrating full-stack CRUD logic, multi-role dashboards, database integration, and in-app communication — all within a clean, production-like structure.”
