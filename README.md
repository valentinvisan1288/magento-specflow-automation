# QA Assignment for Magento page

## Setup and Execution Guide

### 1. Install Prerequisites
- Install Visual Studio 2022 or newer with the ".NET desktop development" workload.
- Install .NET 6.0 SDK or later.
- Install Google Chrome (for Selenium tests).

### 2. Clone the Repository
```bash
git clone https://github.com/your-org/magento-specflow-automation.git
cd magento-specflow-automation
```

### 3. Open in Visual Studio
- Open the `.sln` file using Visual Studio.
- Restore NuGet packages via Tools > NuGet Package Manager > Manage NuGet Packages for Solution.

### 4. Required NuGet Packages
Go to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution**.
Ensure the following packages are installed:
- SpecFlow
- SpecFlow.NUnit
- Selenium.WebDriver
- Selenium.WebDriver.ChromeDriver
- Newtonsoft.Json

### 5. Run BDD Test Cases
- Build using **Build > Build Solution**
- Open **Test Explorer** (Test > Test Explorer)
- Click **Run All Tests**