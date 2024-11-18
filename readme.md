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

#### Structure

```
_
├── eslint.config.js
├── index.html
├── package-lock.json
├── package.json
├── postcss.config.js
├── src
│   ├── components       >> Reusable Components
│   │   └── modals       >> Modals called from
│   ├── contexts
│   ├── main.jsx
│   └── pages
│       └── Auth
├── tailwind.config.js
└── vite.config.js
```

#### Dependencies

-   daisyUI
-   tailwindcss
-   react-router-dom
-   headless-ui
-   react-icons

### Backend

#### Dependencies

-   BCrypt.Net-Next (Version 4.0.3)
-   Microsoft.AspNetCore.Authentication.Cookies (Version 2.2.0)
-   Microsoft.AspNetCore.OpenApi (Version 8.0.10)
-   Microsoft.EntityFrameworkCore.Design (Version 9.0.0)
-   Microsoft.EntityFrameworkCore.SqlServer (Version 9.0.0)
-   Microsoft.EntityFrameworkCore.Tools (Version 9.0.0)
-   Swashbuckle.AspNetCore (Version 6.6.2)
