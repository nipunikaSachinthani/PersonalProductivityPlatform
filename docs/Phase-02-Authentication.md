# Phase 02 - Authentication & Authorization

## Purpose

Authentication is one of the most important parts of any modern application.

This phase will teach how users prove their identity and how the system controls access to resources.

This module should be implemented using industry-standard security practices.

---

# Business Requirement

Users must be able to:

- Register
- Login
- Logout
- Access protected resources
- Refresh expired access tokens
- Reset forgotten passwords

Administrators must be able to:

- Manage users
- Manage roles
- Control permissions

---

# Learning Objectives

After completing this phase you should understand:

## Security Fundamentals

- Authentication vs Authorization
- Identity Management
- OWASP Top 10 basics
- Common security vulnerabilities

## ASP.NET Core

- ASP.NET Identity concepts
- JWT Authentication
- Authorization Policies
- Middleware pipeline

## Database Design

- User management tables
- Role management tables
- Refresh token storage

## Frontend

- Login forms
- Protected routes
- Token storage
- Session management

---

# Deliverables

Frontend:

- Login Page
- Registration Page
- Forgot Password Page
- Protected Routes

Backend:

- JWT Authentication
- Refresh Tokens
- User Management APIs
- Role Management APIs

Database:

- Users
- Roles
- UserRoles
- RefreshTokens

---

# Recommended Database Design

Users

- Id
- FirstName
- LastName
- Email
- PasswordHash
- IsActive
- CreatedDate

Roles

- Id
- Name

UserRoles

- UserId
- RoleId

RefreshTokens

- Id
- UserId
- Token
- ExpiryDate
- RevokedDate

---

# Learning Priority

Priority 1 (Must Know)

- JWT Authentication
- Password Hashing
- Claims
- Roles
- Authorization

Priority 2

- Refresh Tokens
- Password Reset
- Security Headers

Priority 3

- Multi-factor Authentication
- External Login Providers

---

# Development Tasks

## Task 1 - Create Identity Database Structure

Learning Focus

- Relational Design
- Primary Keys
- Foreign Keys

Expected Outcome

Database ready for authentication.

---

## Task 2 - User Registration

Features

- Create account
- Validate input
- Hash password

Learning Focus

- Validation
- DTOs
- Security

Expected Outcome

User can successfully register.

---

## Task 3 - User Login

Features

- Verify credentials
- Generate JWT token

Learning Focus

- JWT
- Claims
- Token generation

Expected Outcome

User can login successfully.

---

## Task 4 - Protect APIs

Features

- Require authentication
- Role-based authorization

Learning Focus

- Authorization Policies
- Claims-based Security

Expected Outcome

Unauthorized users cannot access secured endpoints.

---

## Task 5 - Refresh Token Flow

Features

- Access token expiration
- Refresh token generation
- Refresh token validation

Learning Focus

- Secure Session Management

Expected Outcome

Users remain logged in without frequent reauthentication.

---

## Task 6 - Frontend Authentication

Features

- Login Screen
- Registration Screen
- Route Guards

Learning Focus

- React Forms
- API Integration
- State Management

Expected Outcome

Frontend fully integrated with backend authentication.

---

# API Endpoints

POST /api/auth/register

POST /api/auth/login

POST /api/auth/refresh-token

POST /api/auth/logout

POST /api/auth/forgot-password

POST /api/auth/reset-password

GET /api/users/me

---

# Best Practices

Always:

- Hash passwords
- Use HTTPS
- Validate inputs
- Store secrets outside source control
- Use short-lived access tokens

Never:

- Store plain text passwords
- Expose internal errors
- Trust client-side validation

---

# Common Mistakes

Mistake 1

Storing passwords directly.

Why Wrong

Massive security risk.

Correct Approach

Use password hashing.

---

Mistake 2

Using only frontend authorization.

Why Wrong

Users can bypass UI restrictions.

Correct Approach

Enforce authorization in backend.

---

Mistake 3

Using long-lived JWT tokens.

Why Wrong

Security exposure if stolen.

Correct Approach

Use refresh tokens.

---

# Stretch Goals

After completing the core module:

- Email verification
- Google Login
- Microsoft Login
- MFA
- Audit Logging

---

# Interview Questions

1. What is the difference between authentication and authorization?

2. How does JWT work?

3. What information should be stored inside a JWT?

4. Why are refresh tokens required?

5. How would you revoke a user's session?

6. What are claims?

7. What is the difference between Roles and Claims?

8. Why should passwords never be stored in plain text?

9. What security risks exist in authentication systems?

10. How would you secure a public API?

---

# Review Checklist

Before moving to Phase 03:

Backend

[ ] Registration working

[ ] Login working

[ ] JWT authentication working

[ ] Role authorization working

[ ] Refresh token implemented

Frontend

[ ] Login page completed

[ ] Registration page completed

[ ] Protected routes implemented

Database

[ ] User tables created

[ ] Roles created

[ ] Refresh token table created

Security

[ ] Password hashing implemented

[ ] Secrets protected

[ ] APIs secured

---

# Success Criteria

You should be able to:

- Explain JWT end-to-end
- Design a secure authentication flow
- Implement authorization policies
- Secure APIs using best practices
- Build production-ready authentication systems

