import { createContext, useContext, useState } from 'react';

// Creation of Context
export const UserContext = createContext(null);

// Custom Hook tto use the UserContext
export function useUser() {
    return useContext(UserContext);
}

export function UserProvider({ children }) {
    const [user, setUser] = useState(null);

    const updateUser = (newUser) => {
        console.log('Updating user:', newUser);
        setUser(newUser);
    };

    return <UserContext.Provider value={{ user, updateUser }}>{children}</UserContext.Provider>;
}
