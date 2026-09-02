# 🏛️ MunicipalityConnect

A Windows Forms application designed to provide residents with a simple and user-friendly way to report municipal issues and request services.

---

## 📌 Project Overview

**MunicipalityConnect** is a C# Windows Forms application developed to improve communication between residents and their municipality.

The application allows users to submit municipal issues or service requests by providing relevant information such as the location, category, incident date, description, and supporting attachments.

The project focuses on providing a clean and accessible interface while demonstrating the use of **object-oriented programming, data structures, file handling, validation, and event-driven programming**.

---

## ✨ Features

### 📝 Report an Issue / Request a Service

Users can provide:

- Request type
  - Report an Issue
  - Request a Service
- Location
- Issue category
- Incident date
- Description
- Supporting attachments

### 📎 File Attachments

Users can attach supporting files to their report.

Attached files are:

- Displayed in the application before submission
- Removable before submission
- Copied into the application's `Attachments` directory when the report is submitted
- Stored inside a folder associated with the generated query code

Example:

```text
Attachments/
└── MC-2026-0001/
    ├── image.jpg
    └── document.pdf
