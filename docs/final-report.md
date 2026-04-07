# ITM 350 Final Project Report
## Group A | Ethan Trent | April 2026

---

## 1. Project Description

### What is the Project?

The **Contoso University** web application is a production-quality, open-source ASP.NET Core MVC application built on .NET 10. It serves as a university student and course management system, enabling administrators to manage students, instructors, courses, and departments through a web-based interface backed by a relational SQL database.

### Problem It Solves

Universities face a real operational challenge: managing the enrollment lifecycle of students across multiple departments, courses, and instructors using disconnected spreadsheets or legacy systems. Contoso University solves this by providing a centralized, web-based platform where:

- **Students** can be enrolled, tracked, and graduated
- **Instructors** can be assigned to courses and departments
- **Courses** can be created, modified, and linked to departments
- **Departments** can be managed with budget and instructor assignments

The DevOps challenge this project solved was automating the full lifecycle from code commit to live production deployment on AWS — without ever requiring a developer to manually log into Docker Hub or AWS. Every code change automatically builds, tests, packages into a Docker image, and deploys the updated image to an EC2 instance using Terraform Infrastructure as Code.

---

## 2. Live Application URL

**EC2 Endpoint:** http://ec2-54-90-130-47.compute-1.amazonaws.com

The application is deployed to AWS EC2 (us-east-1) via automated Terraform provisioning triggered by the Release to AWS GitHub Actions pipeline.

---

## 3. Screenshot of Application Running

The application runs as a Docker container on AWS EC2, serving the Contoso University MVC interface on port 80. The pipeline run confirming successful deployment is available at:

https://github.com/byui-devops/netcore-app-groupA-final/actions?query=workflow%3A%22Release+to+AWS%22

![Build Pipeline Success](https://img.shields.io/badge/Build%20Pipeline-Passing-brightgreen)
![Release Pipeline Success](https://img.shields.io/badge/Release%20Pipeline-Passing-brightgreen)

> **Note:** Screenshot of the live application at http://ec2-54-90-130-47.compute-1.amazonaws.com — the application serves the ASP.NET Core Contoso University interface including Students, Courses, Departments, and Instructors management pages.

---

## 4. Codebase URL

**GitHub Repository:** https://github.com/byui-devops/netcore-app-groupA-final

### Repository Structure

```
netcore-app-groupA-final/
├── .github/
│   └── workflows/
│       ├── build.yml          # CI: Build, test, push to Docker Hub
│       └── release.yml        # CD: Terraform deploy to AWS EC2
├── docs/
│   └── final-report.md        # This report
├── src/
│   ├── NetCoreContosoUniversityApp.Web.MVC/     # Main ASP.NET Core app
│   ├── NetCoreContosoUniversityApp.Tests/       # Unit tests (xUnit)
│   └── NetCoreContosoUniversityApp.IntegrationTests/  # Integration tests
├── terraform/
│   ├── main.tf                # EC2 + security group IaC
│   ├── variables.tf           # Input variables
│   └── outputs.tf             # EC2 URL outputs
└── Dockerfile                 # Multi-stage build
```

All changes to `main` were made through **feature branches and pull requests**:
- `feature/devops-pipeline` → PR #3 (Dockerfile, CI/CD, Terraform)
- `feature/integration-tests` → PR #4 (Integration test project, 5 HTTP tests)

---

## 5. Docker Hub Image URL

**Docker Hub:** https://hub.docker.com/r/ethantrent/netcore-contoso-university

The Docker image is automatically built and pushed to Docker Hub on every successful merge to `main`. The image is publicly accessible and tagged `latest`.

**Image:** `ethantrent/netcore-contoso-university:latest`

The Dockerfile uses a **multi-stage build**:
1. **Build stage** — Uses `mcr.microsoft.com/dotnet/sdk:10.0` to compile and publish the app
2. **Runtime stage** — Uses `mcr.microsoft.com/dotnet/aspnet:10.0` as a lightweight runtime image

---

## 6. Build Pipeline

**Workflow:** `.github/workflows/build.yml`
**Trigger:** Push to any branch, or pull request targeting `main`

| Step | Description |
|------|-------------|
| Checkout | Pulls source from GitHub |
| Setup .NET | Configures .NET 10.0 SDK |
| Restore | Runs `dotnet restore` |
| Build | Compiles with `dotnet build` |
| Unit Tests | Runs `NetCoreContosoUniversityApp.Tests` |
| Integration Tests | Runs 5 HTTP route tests in `NetCoreContosoUniversityApp.IntegrationTests` |
| Docker Build & Push | Builds image and pushes to Docker Hub (main branch only) |

---

## 7. Release Pipeline with Infrastructure as Code

**Workflow:** `.github/workflows/release.yml`
**Trigger:** Automatically after Build pipeline succeeds on `main`

All AWS infrastructure is defined in the `terraform/` directory and provisioned automatically — **no manual AWS login required**.

| Step | Description |
|------|-------------|
| Configure AWS Credentials | Uses GitHub Secrets (no login required) |
| Terraform Init | Initializes Terraform providers |
| Import existing security group | Idempotent: handles pre-existing SG |
| Terraform Plan | Computes required infrastructure changes |
| Terraform Apply | Provisions EC2 + security group, runs Docker via user_data |

**Terraform Resources:**
- `aws_security_group` — Opens port 80 (HTTP) and 22 (SSH)
- `aws_instance` — t2.micro EC2, runs Docker container from Docker Hub image on boot

---

## 8. Lessons Learned

### 1. Terraform State Management in CI/CD is Complex
Running Terraform in a stateless CI environment (GitHub Actions) without a remote backend means state is never persisted between runs. This caused `InvalidGroup.Duplicate` errors when the security group already existed from a previous pipeline run. The fix was to use `terraform import` to bring existing resources into state before applying. Going forward, using an S3 backend for remote state would be the production-correct solution.

### 2. EC2 user_data Only Runs Once at Launch
AWS EC2 user_data scripts only execute on the first boot of an instance. When Terraform imported an existing EC2 instance and made no changes, the Docker container from user_data was never re-run. Adding `user_data_replace_on_change = true` to the Terraform resource forces Terraform to destroy and recreate the instance when user_data changes — ensuring a fresh, clean deployment every time.

### 3. Docker Port Mapping Requires Matching Application Configuration
The ASP.NET Core application must be configured to listen on the same port that Docker maps externally. Setting `ENV ASPNETCORE_URLS=http://+:80` in the Dockerfile ensures the app binds to port 80, matching the `-p 80:80` Docker run mapping. A mismatch between these causes connection refused errors even when the container is running.

### 4. Branch Protection Requires Organization Admin Permissions
Setting up branch protection rules (requiring pull requests before merging to `main`) requires organization admin privileges. As a repository contributor rather than org admin, this setting was not configurable through the UI. In a professional environment, requesting admin rights or working with the org owner to enable protection rules would be the first step in a DevOps engagement.

### 5. Automated Testing in CI Catches Regressions Early
Integrating both unit and integration tests directly into the build pipeline (running on every push and PR) provided immediate feedback when changes broke application routes. The 5 HTTP integration tests covering all major routes (`/`, `/Students`, `/Courses`, `/Departments`, `/Instructors`) gave confidence that the deployed Docker image served all expected endpoints before it was ever pushed to production.

### 6. Infrastructure as Code Enables Reproducible Deployments
Defining the entire AWS environment in Terraform (EC2 instance type, security group rules, AMI selection, Docker startup) meant the infrastructure could be recreated from scratch in any AWS account by simply updating secrets and re-running the pipeline. This is the core DevOps principle of treating infrastructure like software — versioned, reviewed, and automated.

---

## Summary

| Requirement | Status | Evidence |
|---|---|---|
| GitHub Repository | ✅ Complete | https://github.com/byui-devops/netcore-app-groupA-final |
| Unit Tests | ✅ Complete | `src/NetCoreContosoUniversityApp.Tests/` — xUnit |
| Integration Tests (5) | ✅ Complete | `src/NetCoreContosoUniversityApp.IntegrationTests/` |
| Docker Image on Docker Hub | ✅ Complete | `ethantrent/netcore-contoso-university:latest` |
| Build Pipeline (CI) | ✅ Complete | `.github/workflows/build.yml` — 15+ runs |
| Release Pipeline (CD) | ✅ Complete | `.github/workflows/release.yml` — auto-triggered |
| IaC in Release Pipeline | ✅ Complete | Terraform provisions EC2 + SG on AWS |
| No Manual AWS Login | ✅ Complete | All credentials stored as GitHub Secrets |
| Feature Branches & PRs | ✅ Complete | PR #3 and PR #4 merged to main |
| Final Report | ✅ Complete | This document |
