import { useRef, useState } from 'react';
import { useUser } from '../../contexts/UserContext';
import { useLogin } from '../../hooks/UseLogin';
import { useNavigate } from 'react-router-dom';

export default function Login() {
    const { user, updateUser } = useUser();
    const username_input = useRef();
    const password_input = useRef();
    const navigate = useNavigate();

    const { mutate, error } = useLogin(); // Call the hook inside the component

    const handleLogin = (e) => {
        e.preventDefault(); // Prevent default form submission behavior

        // Trigger the login mutation
        mutate(
            {
                username: username_input.current.value,
                password: password_input.current.value,
            },
            {
                onSuccess: (data) => {
                    console.log('Login successful:', data);
                    updateUser(data); // Update user context or state
                    navigate('/');
                },
                onError: (error) => {
                    console.error('Login failed:', error.response?.data || error.message);
                },
            }
        );
    };

    return (
        <div className="hero bg-base-200 py-20 h-[60vh]">
            <div className="hero-content flex-col lg:flex-row-reverse flex gap-20">
                <div className="text-center lg:text-left">
                    <h1 className="text-5xl font-bold">Login!</h1>
                    <h3 className=" mt-3 text-base">Judge System</h3>
                    <p className="py-6">
                        Lorem ipsum dolor sit, amet consectetur adipisicing elit. Commodi iure laboriosam porro nostrum
                        blanditiis adipisci non rem distinctio quae! Amet repellendus assumenda esse cumque magni
                        provident numquam nam, iusto eum?
                    </p>
                </div>
                <div className="card bg-base-100 w-full max-w-sm shrink-0 shadow-2xl">
                    <form className="card-body">
                        <div className="form-control">
                            <label className="label">
                                <span className="label-text">Username</span>
                            </label>
                            <input
                                ref={username_input}
                                type="text"
                                placeholder="Enter text here..."
                                className="input input-bordered"
                                required
                            />
                        </div>
                        <div className="form-control">
                            <label className="label">
                                <span className="label-text">Password</span>
                            </label>
                            <input
                                ref={password_input}
                                type="password"
                                placeholder="Enter text here..."
                                className="input input-bordered"
                                required
                            />
                            <label className="label">
                                <a href="#" className="label-text-alt link link-hover">
                                    Forgot password?
                                </a>
                            </label>
                            <h3 className="text-error text-xs text-center">{error?.response?.data}</h3>
                        </div>
                        <div className="form-control mt-6">
                            <div onClick={handleLogin} className="btn btn-primary">
                                Login
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}
