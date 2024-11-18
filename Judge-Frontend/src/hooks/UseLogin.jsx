import { useMutation } from '@tanstack/react-query';
import axios from 'axios';

export const useLogin = () => {
    // Create the mutation
    return useMutation({
        mutationFn: async ({ username, password }) => {
            const response = await axios.post('http://localhost:5143/Auth/login', {
                username,
                password,
            });
            return response.data; // Return the response data
        },
    });
};
