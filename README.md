- [ITM350 - IT Management and DevOps](#itm350---it-management-and-devops)
  - [NetCoreContosoUniversityApp Generated Solution](#netcorecontosouniversityapp-generated-solution)
- [Final Project Instructions](#final-project-instructions)
  - [Table of Contents](#table-of-contents)
  - [Overview](#overview)
  - [Purpose](#purpose)
  - [Objectives](#objectives)
  - [Tasks](#tasks)
    - [Core Goal](#core-goal)
    - [Repository Requirements](#repository-requirements)
    - [Minimum Technical Requirements](#minimum-technical-requirements)
  - [Submission Requirements](#submission-requirements)
    - [Report must include](#report-must-include)
  - [Rubric](#rubric)
    - [1. Scope (30 pts)](#1-scope-30-pts)
    - [2. Automation (30 pts)](#2-automation-30-pts)
    - [3. Quality Assurance (20 pts)](#3-quality-assurance-20-pts)
    - [4. Source Control (20 pts)](#4-source-control-20-pts)
    - [Total](#total)
  - [Original Instructions](#original-instructions)

---

![class-cover](ITM-350.png)

# ITM350 - IT Management and DevOps

- Winter 2026
- Student: Carlos Mercado
- Instructor: [Matthew Jensen](https://www.linkedin.com/in/matthewfjensen/)

---

## NetCoreContosoUniversityApp Generated Solution

Based on template: <https://github.com/carloswm85/dotnet-template-kit> (look for correct branch)

Find documentation reference at: [./docs/onboarding/README.md](./docs/onboarding/README.md)

---

# Final Project Instructions

## Table of Contents

- [Overview](#overview)
- [Purpose](#purpose)
- [Objectives](#objectives)
- [Tasks](#tasks)
- [Submission Requirements](#submission-requirements)
- [Rubric](#rubric)

---

## Overview

**Week 14 – Final Project**

- **Due:** Apr 11, 11:59 PM
- **Points:** 100
- **Submission:** File upload
- **Duration:** Weeks 12–14

---

## Purpose

Apply all DevOps principles learned throughout the course by:

- Building a **team project**
- Deploying it to **AWS**
- **Without logging into AWS manually**

---

## Objectives

By completing this project, students will be able to:

- Use **Git** effectively (branching, PRs, collaboration)
- Implement **automated unit & integration testing**
- Work with **containerized applications**
- Design **CI/CD pipelines**
- Apply **Infrastructure as Code (IaC)**

---

## Tasks

### Core Goal

Build and release your application **fully automated**, without manually accessing AWS.

---

### Repository Requirements

- Create a **team repository**
- Use **GitHub**

---

### Minimum Technical Requirements

- Unit and integration tests included
- Docker image published to **Docker Hub**
- **Build pipeline**
- **Release pipeline**
- **Infrastructure as Code (IaC)**
  - Must run inside the release pipeline

---

## Submission Requirements

Submit a **final project report** (professional format, like an internship deliverable).

### Report must include

- Project description
  - Problem being solved

- AWS deployment:
  - EC2 URL where app is running
  - Screenshot of running application

- Links:
  - Source code repository
  - Docker Hub image

- Lessons learned

---

## Rubric

### 1. Scope (30 pts)

| Level       | Description                | Points |
| ----------- | -------------------------- | ------ |
| Exceptional | Large open-source project  | 30     |
| Good        | Simple open-source project | 27     |
| Acceptable  | < 10 files                 | 21     |
| Developing  | < 2 files                  | 15     |
| Missing     | Empty repository           | 0      |

---

### 2. Automation (30 pts)

| Level       | Description                 | Points |
| ----------- | --------------------------- | ------ |
| Exceptional | 100% automated              | 30     |
| Good        | 1 minor manual task         | 27     |
| Acceptable  | 1 major manual task         | 21     |
| Developing  | Multiple major manual tasks | 15     |
| Missing     | No automation               | 0      |

---

### 3. Quality Assurance (20 pts)

| Level       | Description                                    | Points |
| ----------- | ---------------------------------------------- | ------ |
| Exceptional | Unit + integration tests automated and passing | 20     |
| Good        | Tests exist but some failing                   | 18     |
| Acceptable  | No tests, but build passes                     | 14     |
| Developing  | No tests and build failing                     | 10     |
| Missing     | No testing                                     | 0      |

---

### 4. Source Control (20 pts)

| Level       | Description                               | Points |
| ----------- | ----------------------------------------- | ------ |
| Exceptional | All changes via PR, main branch protected | 20     |
| Good        | Most changes via PR, main protected       | 18     |
| Acceptable  | Few PRs, main may not be protected        | 14     |
| Developing  | < 2 pull requests                         | 10     |
| Missing     | No PRs, main not protected                | 0      |

---

### Total

- **100 Points**

---

## Original Instructions

```txt
== WEEK 12-14 - FINAL PROJECT ==

== PURPOSE =================================================

Apply all principles within the course to the team repository by building a team
project and deploying it to AWS without logging into AWS. Upon completion of this
project, students will be able to:

- Demonstrate proficiency in Git for version control by effectively implementing
  branching strategies, conducting code reviews, and collaborating in a team
  environment.
- Implement automated unit and integration testing to enhance software quality,
  maintainability, and long-term reliability.
- Create, deploy, and manage containerized applications in a cloud environment
  to improve scalability, reliability, and resource efficiency.
- Design and implement automated Continuous Integration & Continuous Deployment
  (CI/CD) pipelines to streamline software delivery and deployment processes.
- Utilize Infrastructure as Code (IaC) to define, provision, and manage cloud
  infrastructure programmatically

== TASKS ===================================================

Your goal is to build and release your application without logging into AWS.

Do the following in your team repositories

- Create a team repository
- Minimum requirements:
  - Use Github
  - Includes unit and integration tests
  - Docker image pushed to Docker Hub
  - Build pipeline
  - Release pipeline
  - Infrastructure as code (this should be ran in the release pipeline). Submit
    a final project report (this should be written as if you were submitting this
    to your boss at the end of an internship). Report should include the
    following:
    - Detailed description of your project and the problem that it is solving
    - URL of your EC2 where your application is successfully running
    - Screenshot of your application successfully running
    - URL of your code base
    - URL of your docker image in docker hub
    - Lessons Learned
```
