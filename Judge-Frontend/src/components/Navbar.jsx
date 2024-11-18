import { useState } from 'react';
import { Link, NavLink, useNavigate } from 'react-router-dom';
import { ImHammer2 } from 'react-icons/im';
import ResetPassword from './modals/ResetPassword';
import NiceModal from '@ebay/nice-modal-react';
import { useUser } from '../contexts/UserContext';

function Navbar() {
    const navigate = useNavigate();
    const [isProfileOpen, openProfile] = useState(false); // Profile Dropdown
    const { user } = useUser();

    // Open Reset Password Modal
    const showResetPasswordModal = () => {
        openProfile(!isProfileOpen);
        NiceModal.show(ResetPassword);
    };

    const handleLogout = () => {
        localStorage.removeItem('token');
        navigate('/login');
        openProfile(false);
    };

    return (
        <div className="navbar bg-base-200 px-8 py-4">
            {/* Left Navbar */}
            <div className="flex-1">
                <a className="text-xl btn-ghost btn font-semibold flex gap-4">
                    <ImHammer2 className="text-[1.95rem]" />
                    <span className="select-none">Judge System</span>
                </a>
            </div>

            {/* Right Navbar */}
            <div className="flex-1 flex justify-end">
                {/* Navigation Links */}
                <ul className="menu menu-horizontal px-1 flex gap-1">
                    <li>
                        <NavLink to={'/'}>Home</NavLink>
                    </li>
                    <li>
                        <NavLink to={'/scoreboard'}>Scoreboard</NavLink>
                    </li>
                </ul>

                {/* Profile Dropdown */}
                <div className="dropdown dropdown-end">
                    <div role="button" className="btn btn-ghost btn-circle  ">
                        <div
                            onClick={() => openProfile(!isProfileOpen)}
                            className=" flex items-center justify-center w-10 h-10 rounded-full bg-primary"
                        >
                            <h1>{user ? user.username.charAt(0).toUpperCase() : ''}</h1>
                        </div>
                    </div>

                    {/* Profile Dropdown Functionality */}
                    {isProfileOpen && (
                        <ul className="absolute right-0 menu menu-sm bg-base-100 rounded-box z-[1] mt-3 w-52 p-2 shadow">
                            <li>
                                <a onClick={showResetPasswordModal}>Reset Password</a>
                            </li>
                            <li>
                                <div onClick={handleLogout}>Logout</div>
                            </li>
                        </ul>
                    )}
                </div>
            </div>
        </div>
    );
}

export default Navbar;
