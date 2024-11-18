# Judge System

## Project Overview

This repository is dedicated to refactoring the initial Judge System the WILL-I-AMS attempted to create. Though the projects development turned successful, best practices were not incorporated as well. Nor was the consideration of security emphasized enough.

This repository is an attempt to make this right. Creating an automated Judge System intended for my previous tertiary education provider.

Made with love, by students, for students.

## Project Notes

### Prettier

Below lists prettier code formatting settings issued

```
    "tabWidth": 4,            - Visual Width of Tabs
    "printWidth": 120,        - Max characters in line for readability
    "useTabs": false,         - Use spaces instead of tabs
    "semi": true,             - Add semicolons where appropriate
    "singleQuote": true,      - Turn instances of double quotes to singles
    "bracketSameLine": false, - Preference: Component Usage
    "bracketSpacing": true    - Preference: JSX import statements { }
```

### Frontend

#### File Structure

```
_
├── eslint.config.js    >> Configuration file for ESLint
├── index.html          >> The root HTML file for the frontend application
├── package-lock.json   >> Auto-generated file that locks dependency versions
├── package.json        >> Defines project metadata, scripts, and dependencies
├── postcss.config.js   >> Configuration file for PostCSS
├── src                 >> Main source folder where application code resides
│   ├── components      >> Folder containing reusable components
│   │   └── modals      >> Folder containing modal components for the app
│   ├── contexts        >> Folder for React Contexts, for global state management
│   ├── main.jsx        >> The main entry point of the React application
│   └── pages           >> Folder containing the different page components
│       └── Auth        >> Contains the authentication-related components
├── tailwind.config.js  >> Configuration file for Tailwind
└── vite.config.js      >> Configuration file for Vite
```

#### Dependencies

-   daisyUI
-   tailwindcss
-   react-router-dom
-   headless-ui
-   react-icons

### Backend

#### File Structure

```
_
│
├───Controllers >> Folder containing controllers that handle HTTP requests
├───Data        >> Folder where database-related files are stored
├───DTOs        >> Data Transfer Objects, used to transfer data (client & server)
├───Migrations  >> Folder containing migration files for Entity Framework
├───Models      >> Folder containing the models that define database tables
└───Services    >> Folder where the business logic and service classes reside
```

#### Dependencies

-   BCrypt.Net-Next (Version 4.0.3)
-   Microsoft.AspNetCore.Authentication.Cookies (Version 2.2.0)
-   Microsoft.AspNetCore.OpenApi (Version 8.0.10)
-   Microsoft.EntityFrameworkCore.Design (Version 9.0.0)
-   Microsoft.EntityFrameworkCore.SqlServer (Version 9.0.0)
-   Microsoft.EntityFrameworkCore.Tools (Version 9.0.0)
-   Swashbuckle.AspNetCore (Version 6.6.2)
